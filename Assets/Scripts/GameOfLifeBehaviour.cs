using System;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLifeBehaviour : MonoBehaviour
{
    public GameObject cellPrefab;

    public GameOfLife game;
    
    private Renderer[,,,] cellRenderers;
    private ObjectPool _cellPool;
    private List<Material> materials;
    private float tickTimer = 0;
    public bool paused = true;
    public float tickTime = 0.1f;
    public bool forceFullUpdateNextTick = false;
    public bool alwaysCountNeighbors = false;
    public bool alwaysUseChanges = false;
    private float _hue = 0.333f;
    [NonSerialized] public int numCubesInScene = 0; // Not pooled

    public bool debug = false;
    [NonSerialized] public float debugTickTime = 0;
    [NonSerialized] public float debugRefreshTime = 0;

    public float Hue
    {
        get
        {
            return _hue;
        }
        set
        {
            _hue = value;
            ChangeColors();
        }
    }

    public ObjectPool cellPool
    {
        get
        {
            if (_cellPool == null && !TryGetComponent<ObjectPool>(out _cellPool))
            {
                _cellPool = gameObject.AddComponent<ObjectPool>();
            }

            return _cellPool;
        }
    }

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    private void Start()
    {
        game = new GameOfLife(64, 64, 1, 1);
        game.ConwayRules();

        cellPool.poolObject = cellPrefab;

        SizeChanged();
        Randomize();

        paused = true;
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    private void Update()
    {
        if (!paused)
        {
            tickTimer += Time.deltaTime;
            if (tickTimer >= tickTime)
            {
                Tick();
                tickTimer = 0;
            }
        }
    }

    // Game management
    public void Tick()
    {
        game.alwaysUseChanges = alwaysUseChanges;
        game.alwaysCountNeighbors = alwaysCountNeighbors;
        if (debug)
        {
            DateTime start = DateTime.Now;
            game.Tick(forceFullUpdateNextTick);
            DateTime tickFinishTime = DateTime.Now;
            debugTickTime = (float)(tickFinishTime - start).TotalSeconds;
            RefreshChanged();
            debugRefreshTime = (float)(DateTime.Now - tickFinishTime).TotalSeconds;
        }
        else
        {
            game.Tick(forceFullUpdateNextTick);
            RefreshChanged();
        }

        forceFullUpdateNextTick = false;
    }

    public void Randomize(int seed = 0)
    {
        game.Randomize(seed);
        RefreshAll();
    }

    public void Resize(int width, int height, int depth, int colors)
    {
        game.Resize(new GameOfLife.Vector4i(width, height, depth, colors));
        SizeChanged();
    }

    public void Clear()
    {
        game.Clear();
        RefreshAll();
    }

    // Renderer setup
    private void SizeChanged()
    {
        if (cellRenderers != null && game.dimensions.x == cellRenderers.GetLength(0) && game.dimensions.y == cellRenderers.GetLength(1) && game.dimensions.z == cellRenderers.GetLength(2) && game.dimensions.w == cellRenderers.GetLength(3))
        {
            return;
        }

        PoolAll();

        cellRenderers = new Renderer[game.dimensions.x, game.dimensions.y, game.dimensions.z, game.dimensions.w];
        SetUpMaterials();
    }

    private void SetUpMaterials()
    {
        if (materials == null)
        {
            materials = new List<Material>();
        }

        Shader shader = Shader.Find("Standard");
        for (int i = materials.Count; i < game.dimensions.w; ++i)
        {
            Material material = new Material(shader);
            materials.Add(material);
            materials[i].SetFloat("_Metallic", 1);
            materials[i].SetFloat("_Glossiness", 0.1f);
        }

        ChangeColors();
    }

    private void ChangeColors()
    {
        for (int i = 0; i < game.dimensions.w; ++i)
        {
            materials[i].SetColor("_Color", Color.HSVToRGB((_hue + (i / (float)game.dimensions.w)) % 1f, 1, 1));
        }
    }

    // Rendering
    /// <summary>
    /// Pools all currently live cells, and resets the entire scene from scratch.
    /// Use <see cref="RefreshAll"/> instead, unless the game's <see cref="GameOfLife.liveCells"/> and/or <see cref="GameOfLife.deadCells"/> lists are untrustworthy for some reason.
    /// </summary>
    public void RefreshFromCells()
    {
        if (game.dimensions.x != cellRenderers.GetLength(0) || game.dimensions.y != cellRenderers.GetLength(1) || game.dimensions.z != cellRenderers.GetLength(2) || game.dimensions.w != cellRenderers.GetLength(3))
        {
            SizeChanged();
        }
        else
        {
            PoolAll();
        }

        for (int i = 0; i < game.dimensions.x; ++i)
        {
            for (int j = 0; j < game.dimensions.y; ++j)
            {
                for (int k = 0; k < game.dimensions.z; ++k)
                {
                    for (int l = 0; l < game.dimensions.w; ++l)
                    {
                        if (game.cells[i, j, k, l])
                        {
                            EnableCell(i, j, k, l);
                        }
                    }
                }
            }
        }
    }

    public void RefreshAll()
    {
        if (game.liveCells == null)
        {
            RefreshFromCells();
            return;
        }

        if (game.dimensions.x != cellRenderers.GetLength(0) || game.dimensions.y != cellRenderers.GetLength(1) || game.dimensions.z != cellRenderers.GetLength(2) || game.dimensions.w != cellRenderers.GetLength(3))
        {
            SizeChanged();
        }
        else
        {
            PoolAll();
        }

        for (int i = 0; i < game.numAlive; ++i)
        {
            GameOfLife.Vector4i cell = game.liveCells[i];
            EnableCell(cell.x, cell.y, cell.z, cell.w);
        }

    }

    public void RefreshChanged()
    {
        if (game.changes == null)
        {
            RefreshAll();
            return;
        }

        for (int i = 0; i < game.numChanges; ++i)
        {
            GameOfLife.Vector4i cell = game.changes[i];
            if (game.cells[cell.x, cell.y, cell.z, cell.w])
            {
                EnableCell(cell.x, cell.y, cell.z, cell.w);
            }
            else
            {
                DisableCell(cell.x, cell.y, cell.z, cell.w);
            }
        }
    }

    private void PoolAll()
    {
        numCubesInScene = 0;

        if (cellRenderers == null)
        {
            return;
        }

        for (int i = 0; i < cellRenderers.GetLength(0); ++i)
        {
            for (int j = 0; j < cellRenderers.GetLength(1); ++j)
            {
                for (int k = 0; k < cellRenderers.GetLength(2); ++k)
                {
                    for (int l = 0; l < cellRenderers.GetLength(3); ++l)
                    {
                        if (cellRenderers[i, j, k, l] != null)
                        {
                            cellRenderers[i, j, k, l].enabled = false;
                            cellPool.PoolObject(cellRenderers[i, j, k, l].gameObject);
                            cellRenderers[i, j, k, l] = null;
                        }
                    }
                }
            }
        }
    }

    private void EnableCell(int x, int y, int z, int w)
    {
        if (cellRenderers[x, y, z, w] != null)
        {
            cellRenderers[x, y, z, w].enabled = true;
            return;
        }

        GameObject cell = cellPool.GetObject();
        ++numCubesInScene;

        cell.transform.position = new Vector3(x - (game.dimensions.x - 1) / 2f, y - (game.dimensions.y - 1) / 2f, z - (game.dimensions.z - 1) / 2f);
        cell.transform.rotation = Quaternion.identity;

        // Apply some rotation as well to prevent Z-fighting
        cell.transform.Rotate(Vector3.one, w * 120 / (float)game.dimensions.w);
        MeshRenderer renderer = cell.GetComponent<MeshRenderer>();
        renderer.material = materials[w];

        cell.isStatic = true;
        renderer.enabled = true;
        cellRenderers[x, y, z, w] = renderer;
    }

    private void DisableCell(int x, int y, int z, int w)
    {
        if (cellRenderers[x, y, z, w] == null)
        {
            return;
        }

        GameObject cell = cellRenderers[x, y, z, w].gameObject;
        cellRenderers[x, y, z, w].enabled = false;

        // Pool dead cells rather than leave them in place.
        // Cubes representing dead cells can then be repurposed to another live cell somewhere, so a new cube won't need to be instantiated.
        // This will save memory, but every time a cell is born a cube will have to be set up again
        cellPool.PoolObject(cell);
        --numCubesInScene;
        cellRenderers[x, y, z, w] = null;
    }

}
