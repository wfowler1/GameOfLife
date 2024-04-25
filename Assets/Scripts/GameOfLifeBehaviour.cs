using System;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLifeBehaviour : MonoBehaviour
{
    public GameObject cell;

    public GameOfLife game;
    
    private Renderer[,,,] cells;
    private ObjectPool cellPool;
    private List<Material> materials;
    private float tickTimer = 0;
    public bool paused = true;
    public float tickTime = 0.1f;
    public bool forceFullUpdateNextTick = false;
    private float _hue = 0.333f;

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

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {
        game = new GameOfLife(64, 64, 1, 1);
        game.ConwayRules();

        cellPool = GetComponent<ObjectPool>();
        if (cellPool == null)
        {
            cellPool = gameObject.AddComponent<ObjectPool>();
        }
        cellPool.poolObject = cell;

        SizeChanged();
        Randomize();

        paused = true;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        if (game.width != cells.GetLength(0) || game.height != cells.GetLength(1) || game.depth != cells.GetLength(2) || game.colors != cells.GetLength(3))
        {
            SizeChanged();
        }

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

    public void Tick()
    {
        game.Tick(forceFullUpdateNextTick);
        UpdateFromChanges();
        forceFullUpdateNextTick = false;
    }

    public void Randomize(int seed = 0)
    {
        game.Randomize(seed);
        Refresh();
    }

    public void Clear()
    {
        game.Clear();
        Refresh();
    }

    public void Refresh()
    {
        if (game.width != cells.GetLength(0) || game.height != cells.GetLength(1) || game.depth != cells.GetLength(2) || game.colors != cells.GetLength(3))
        {
            SizeChanged();
        }

        for (int i = 0; i < game.width; ++i)
        {
            for (int j = 0; j < game.height; ++j)
            {
                for (int k = 0; k < game.depth; ++k)
                {
                    for (int l = 0; l < game.colors; ++l)
                    {
                        cells[i, j, k, l].enabled = game.liveCells[i, j, k, l];
                    }
                }
            }
        }
    }

    public void UpdateFromChanges()
    {
        if (game.numChanges > 0)
        {
            for (int i = 0; i < game.numChanges; ++i)
            {
                GameOfLife.Vector4i cell = game.changes[i];
                cells[cell.x, cell.y, cell.z, cell.w].enabled = game.liveCells[cell.x, cell.y, cell.z, cell.w];
            }
        }
    }

    public void Resize(int width, int height, int depth, int colors)
    {
        game.Resize(new GameOfLife.Vector4i(width, height, depth, colors));
        SizeChanged();
    }

    public void SizeChanged()
    {
        if (cells != null && game.width == cells.GetLength(0) && game.height == cells.GetLength(1) && game.depth == cells.GetLength(2) && game.colors == cells.GetLength(3))
        {
            return;
        }

        Renderer[,,,] oldCells = cells;
        cells = new Renderer[game.width, game.height, game.depth, game.colors];

        // Pool any unneeded cells
        if (oldCells != null)
        {
            if (oldCells.Length >= cells.Length)
            {
                Array.Copy(oldCells, cells, cells.Length);
                Renderer[,,,] cellsToPool = new Renderer[oldCells.Length - cells.Length, 1, 1, 1];
                Array.Copy(oldCells, cells.Length, cellsToPool, 0, cellsToPool.GetLength(0));
                for (int i = 0; i < cellsToPool.GetLength(0); ++i)
                {
                    cellPool.PoolObject(cellsToPool[i, 0, 0, 0].gameObject);
                }
            }
            else
            {
                Array.Copy(oldCells, cells, oldCells.Length);
            }
        }

        // Set up materials
        SetUpMaterials();

        // Set up new cells
        SetUpCells();
    }

    private void SetUpMaterials()
    {
        if (materials == null)
        {
            materials = new List<Material>();
        }

        Shader shader = Shader.Find("Standard");
        for (int i = 0; i < game.colors; ++i)
        {
            if (materials.Count <= i)
            {
                Material material = new Material(shader);
                materials.Add(material);
                materials[i].SetFloat("_Metallic", 1);
                materials[i].SetFloat("_Glossiness", 0.1f);
            }
        }

        ChangeColors();
    }

    private void SetUpCells()
    {
        for (int i = 0; i < game.width; ++i)
        {
            for (int j = 0; j < game.height; ++j)
            {
                for (int k = 0; k < game.depth; ++k)
                {
                    for (int l = 0; l < game.colors; ++l)
                    {
                        GameObject cell;
                        if (cells[i, j, k, l] == null)
                        {
                            cell = cellPool.GetObject();
                        }
                        else
                        {
                            cell = cells[i, j, k, l].gameObject;
                        }
                        
                        cell.transform.position = new Vector3(i - (game.width - 1) / 2f, j - (game.height - 1) / 2f, k - (game.depth - 1) / 2f);
                        cell.transform.rotation = Quaternion.identity;

                        // Apply some rotation as well to prevent Z-fighting
                        cell.transform.Rotate(Vector3.one, l * 120 / (float)game.colors);
                        MeshRenderer renderer = cell.GetComponent<MeshRenderer>();
                        renderer.material = materials[l];

                        cell.isStatic = true;
                        renderer.enabled = game.liveCells[i, j, k, l];
                        cells[i, j, k, l] = renderer;
                    }
                }
            }
        }
    }

    private void ChangeColors()
    {
        for (int i = 0; i < materials.Count; ++i)
        {
            materials[i].SetColor("_Color", Color.HSVToRGB((_hue + (i / (float)game.colors)) % 1f, 1, 1));
        }
    }
}
