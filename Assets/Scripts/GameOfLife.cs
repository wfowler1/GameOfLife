using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class GameOfLife
{
    public struct Vector4i
    {
        public int x;
        public int y;
        public int z;
        public int w;

        public Vector4i(int x, int y, int z, int w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public override int GetHashCode()
        {
            return (x >> 1) ^ (~y >> 2) ^ z ^ ~(w << 1);
        }
    }

    private Vector4i _dimensions;
    public Vector4i dimensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return _dimensions;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            Resize(value);
        }
    }
    public int width
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return _dimensions.x;
        }
    }
    public int height
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return _dimensions.y;
        }
    }
    public int depth
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return _dimensions.z;
        }
    }
    public int colors
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return _dimensions.w;
        }
    }

    public int[] birth = new int[] { 3 };
    public int[] survival = new int[] { 2, 3 };
    public float initialPercentAlive = 0.25f;
    public bool wrap = false;
    public bool alwaysCountNeighbors = false;
    public bool alwaysUseChanges = false;
    public string currentBehavior = "None";
    
    public int numCells
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private set;
    }

    public int numAlive
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private set;
    }
    public int tickNum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private set;
    }
    
    public bool[,,,] cells;
    /// <summary>
    /// List of live cells. Updated when randomizing, and during cell update phase. Used in counting neighbor phase. Length is <see cref="numAlive"/>.
    /// </summary>
    public Vector4i[] liveCells;
    /// <summary>
    /// List of dead cells. Updated when randomizing, and during cell update phase. Used in counting neighbor phase. Length is <see cref="numCells"/> - <see cref="numAlive"/>.
    /// </summary>
    public Vector4i[] deadCells;
    /// <summary>
    /// List of changed cells. Updated during cell update phase, when <see cref="SetState(bool, Vector4i)"/> is called.  Used in counting neighbor phase. Length is <see cref="numChanges"/>.
    /// </summary>
    public Vector4i[] changes;
    public int numChanges
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private set;
    }
    
    private int[,,,] neighborCounts;

    public GameOfLife(int width, int height, int depth, int colors) : this(new Vector4i(width, height, depth, colors)) { }

    public GameOfLife(Vector4i dimensions)
    {
        Resize(dimensions);
    }

    /// <summary>
    /// Advances the simulation one step. Runs in two phases: First, count each cell's live neighbors. Second, update each cell based on live neighbor counts.
    /// </summary>
    /// <param name="force">Force a full recount of live neighbors for all cells on this step.</param>
    public void Tick(bool force = false)
    {
        ++tickNum;

        if (force)
        {
            numChanges = -1;
        }

        if (numChanges == 0 || numAlive == 0)
        {
            return;
        }

        // Neighbor counting phase
        GetNumLiveNeighborsForAll();
        // Cell update phase
        CalculateLife();
    }

    /// <summary>
    /// Updates the state of each cell based on the <see cref="neighborCounts"/> list, using the current birth and survival rules.
    /// </summary>
    private void CalculateLife()
    {
        if (liveCells == null)
        {
            liveCells = new Vector4i[numCells];
        }
        else
        {
            Array.Clear(liveCells, 0, liveCells.Length);
        }
        if (deadCells == null)
        {
            deadCells = new Vector4i[numCells];
        }
        else
        {
            Array.Clear(deadCells, 0, deadCells.Length);
        }

        int numLiveCells = 0;
        int numDeadCells = 0;

        for (int i = 0; i < _dimensions.x; ++i)
        {
            for (int j = 0; j < _dimensions.y; ++j)
            {
                for (int k = 0; k < _dimensions.z; ++k)
                {
                    for (int l = 0; l < _dimensions.w; ++l)
                    {
                        bool wasAlive = cells[i, j, k, l];
                        if (wasAlive)
                        {
                            if (ArrayContains(survival, neighborCounts[i, j, k, l]))
                            {
                                // Cell remains alive. Add to list, leave state.
                                liveCells[numLiveCells].x = i;
                                liveCells[numLiveCells].y = j;
                                liveCells[numLiveCells].z = k;
                                liveCells[numLiveCells++].w = l;
                            }
                            else
                            {
                                // Cell dies. Add to list, change state.
                                SetState(false, i, j, k, l);
                                deadCells[numDeadCells].x = i;
                                deadCells[numDeadCells].y = j;
                                deadCells[numDeadCells].z = k;
                                deadCells[numDeadCells++].w = l;
                            }
                        }
                        else
                        {
                            if (ArrayContains(birth, neighborCounts[i, j, k, l]))
                            {
                                // Cell is born. Add to list, change state.
                                liveCells[numLiveCells].x = i;
                                liveCells[numLiveCells].y = j;
                                liveCells[numLiveCells].z = k;
                                liveCells[numLiveCells++].w = l;
                                SetState(true, i, j, k, l);
                            }
                            else
                            {
                                // Cell remains dead. Add to list, leave state.
                                deadCells[numDeadCells].x = i;
                                deadCells[numDeadCells].y = j;
                                deadCells[numDeadCells].z = k;
                                deadCells[numDeadCells++].w = l;
                            }
                        }
                    }
                }
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool ArrayContains(int[] array, int val)
    {
        // Enumerable.Contains runs slow and creates garbage
        // Array.BinarySearch is slower than writing a linear search
        int l = 0;
        int r = array.Length - 1;
        while (l <= r)
        {
            int m = (l + r) / 2;
            if (array[m] < val)
            {
                l = m + 1;
            }
            else if (array[m] > val)
            {
                r = m - 1;
            }
            else
            {
                return true;
            }
        }

        return false;
    }

    private void GetNumLiveNeighborsForAll()
    {
        if (((numChanges > numAlive) || numChanges < 0 || alwaysCountNeighbors) && !alwaysUseChanges)
        {
            CountLiveNeighborsForAll();
        }
        else
        {
            ApplyNeighborChangesForAll();
        }

        numChanges = 0;
    }

    private void CountLiveNeighborsForAll()
    {
        // Do a full neighbor count from scratch
        Array.Clear(neighborCounts, 0, neighborCounts.Length);

        // If nothing is known, do a full refresh
        if (liveCells == null || deadCells == null)
        {
            liveCells = new Vector4i[numCells];
            deadCells = new Vector4i[numCells];
            for (int i = 0; i < _dimensions.x; ++i)
            {
                for (int j = 0; j < _dimensions.y; ++j)
                {
                    for (int k = 0; k < _dimensions.z; ++k)
                    {
                        for (int l = 0; l < _dimensions.w; ++l)
                        {
                            if (cells[i, j, k, l])
                            {
                                AddToNeighbors(i, j, k, l, false);
                            }
                        }
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < numAlive; ++i)
            {
                AddToNeighbors(liveCells[i], false);
            }
        }
    }

    private void ApplyNeighborChangesForAll()
    {
        // Only apply changes to neighbors from last tick
        for (int i = 0; i < numChanges; ++i)
        {
            Vector4i cell = changes[i];
            AddToNeighbors(cell, !cells[cell.x, cell.y, cell.z, cell.w]);
        }

        Array.Clear(changes, 0, numChanges);
    }

    private int[] neighborX = new int[] { 0, 0, 0 };
    private int[] neighborY = new int[] { 0, 0, 0 };
    private int[] neighborZ = new int[] { 0, 0, 0 };
    private int[] neighborW = new int[] { 0, 0, 0 };
    private void AddToNeighbors(int x, int y, int z, int w, bool subtract)
    {
        neighborX[1] = x;
        neighborY[1] = y;
        neighborZ[1] = z;
        neighborW[1] = w;

        if (wrap)
        {
            // We don't want to count the same cells more than once, even when wrapping
            WrappingClampAllNoDuplicates(neighborX, x, 0, _dimensions.x - 1);
            WrappingClampAllNoDuplicates(neighborY, y, 0, _dimensions.y - 1);
            WrappingClampAllNoDuplicates(neighborZ, z, 0, _dimensions.z - 1);
            WrappingClampAllNoDuplicates(neighborW, w, 0, _dimensions.w - 1);
        }
        else
        {
            neighborX[0] = x - 1;
            neighborX[2] = x + 1;
            neighborY[0] = y - 1;
            neighborY[2] = y + 1;
            neighborZ[0] = z - 1;
            neighborZ[2] = z + 1;
            neighborW[0] = w - 1;
            neighborW[2] = w + 1;
        }

        for (int i = 0; i < 3; ++i)
        {
            if (neighborX[i] < 0 || neighborX[i] >= _dimensions.x)
            {
                continue;
            }
            for (int j = 0; j < 3; ++j)
            {
                if (neighborY[j] < 0 || neighborY[j] >= _dimensions.y)
                {
                    continue;
                }
                for (int k = 0; k < 3; ++k)
                {
                    if (neighborZ[k] < 0 || neighborZ[k] >= _dimensions.z)
                    {
                        continue;
                    }
                    for (int l = 0; l < 3; ++l)
                    {
                        if (neighborW[l] < 0 || neighborW[l] >= _dimensions.w)
                        {
                            continue;
                        }
                        if (i == 1 && j == 1 && k == 1 && l == 1)
                        {
                            continue;
                        }

                        if (subtract)
                        {
                            --neighborCounts[neighborX[i], neighborY[j], neighborZ[k], neighborW[l]];
                        }
                        else
                        {
                            ++neighborCounts[neighborX[i], neighborY[j], neighborZ[k], neighborW[l]];
                        }
                    }
                }
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void AddToNeighbors(Vector4i cell, bool subtract)
    {
        AddToNeighbors(cell.x, cell.y, cell.z, cell.w, subtract);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void WrappingClampAllNoDuplicates(int[] array, int val, int min, int max)
    {
        array[0] = WrappingClamp(val - 1, min, max);
        if (array[0] == array[1])
        {
            array[0] = -1;
            array[2] = -1;
        }
        else
        {
            array[2] = WrappingClamp(val + 1, min, max);
            if (array[0] == array[2])
            {
                array[2] = -1;
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int WrappingClamp(int val, int min, int max)
    {
        if (val < min)
        {
            return max;
        }
        else if (val > max)
        {
            return min;
        }

        return val;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Resize(int width, int height, int depth, int colors)
    {
        Resize(new Vector4i(width, height, depth, colors));
    }

    public void Resize(Vector4i newDimensions)
    {
        if (cells != null &&
            _dimensions.x == newDimensions.x &&
            _dimensions.y == newDimensions.y &&
            _dimensions.z == newDimensions.z &&
            _dimensions.w == newDimensions.w &&
            cells.GetLength(0) == newDimensions.x &&
            cells.GetLength(1) == newDimensions.y &&
            cells.GetLength(2) == newDimensions.z &&
            cells.GetLength(3) == newDimensions.w)
        {
            Clear();
            return;
        }
        
        tickNum = 0;
        numAlive = 0;
        numChanges = 0;

        numCells = newDimensions.x * newDimensions.y * newDimensions.z * newDimensions.w;

        _dimensions.x = newDimensions.x;
        _dimensions.y = newDimensions.y;
        _dimensions.z = newDimensions.z;
        _dimensions.w = newDimensions.w;

        // Resize arrays
        cells = new bool[newDimensions.x, newDimensions.y, newDimensions.z, newDimensions.w];
        neighborCounts = new int[newDimensions.x, newDimensions.y, newDimensions.z, newDimensions.w];
        changes = new Vector4i[numCells];
        liveCells = new Vector4i[numCells];
        deadCells = new Vector4i[numCells];
    }

    public void Randomize(int seed = 0)
    {
        Clear();
        Random rng;
        if (seed != 0)
        {
            rng = new Random(seed);
        }
        else
        {
            rng = new Random();
        }

        currentBehavior = "Random " + (initialPercentAlive * 100).ToString("#0.##") + "%";
        int deadCellCount = 0;
        for (int i = 0; i < _dimensions.x; ++i)
        {
            for (int j = 0; j < _dimensions.y; ++j)
            {
                for (int k = 0; k < _dimensions.z; ++k)
                {
                    for (int l = 0; l < _dimensions.w; ++l)
                    {
                        bool alive = rng.NextDouble() <= initialPercentAlive;
                        if (alive)
                        {
                            liveCells[numAlive].x = i;
                            liveCells[numAlive].y = j;
                            liveCells[numAlive].z = k;
                            liveCells[numAlive].w = l;
                            SetState(true, i, j, k, l);
                        }
                        else
                        {
                            deadCells[deadCellCount].x = i;
                            deadCells[deadCellCount].y = j;
                            deadCells[deadCellCount].z = k;
                            deadCells[deadCellCount++].w = l;
                        }
                    }
                }
            }
        }
    }

    public void Clear()
    {
        tickNum = 0;
        numAlive = 0;
        Array.Clear(cells, 0, cells.Length);
        Array.Clear(neighborCounts, 0, neighborCounts.Length);
        numChanges = 0;
        Array.Clear(changes, 0, changes.Length);
        if (liveCells == null)
        {
            liveCells = new Vector4i[numCells];
        }
        else
        {
            Array.Clear(liveCells, 0, liveCells.Length);
        }
        if (deadCells == null)
        {
            deadCells = new Vector4i[numCells];
        }
        else
        {
            Array.Clear(deadCells, 0, deadCells.Length);
        }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SetState(bool alive, Vector4i cell)
    {
        SetState(alive, cell.x, cell.y, cell.z, cell.w);
    }

    public void SetState(bool alive, int x, int y, int z, int w)
    {
        if (alive != cells[x, y, z, w])
        {
            cells[x, y, z, w] = alive;
            numAlive += alive ? 1 : -1;
            changes[numChanges++] = new Vector4i() { x = x, y = y, z = z, w = w };
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ToggleState(Vector4i cell)
    {
        ToggleState(cell.x, cell.y, cell.z, cell.w);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ToggleState(int x, int y, int z, int w)
    {
        SetState(!cells[x, y, z, w], x, y, z, w);
    }

    public override int GetHashCode()
    {
        int hash = 0x53248B7C;

        // Hash rules
        int birthHash = birth.Length << survival.Length % 5;
        for (int i = 0; i < birth.Length; ++i)
        {
            birthHash += birth[i] << ((i * 7) % 23);
        }
        int survivalHash = survival.Length << birth.Length % 3;
        for (int i = 0; i < survival.Length; ++i)
        {
            survivalHash += survival[i] << ((i * 11) % 19);
        }
        hash ^= (birthHash ^ ~survivalHash) ^ (wrap ? 1 << 31 : 1 << 15);

        // Hash world
        hash ^= dimensions.GetHashCode();

        // Hash population
        for (int i = 0; i < _dimensions.x; ++i)
        {
            for (int j = 0; j < _dimensions.y; ++j)
            {
                for (int k = 0; k < _dimensions.z; ++k)
                {
                    for (int l = 0; l < _dimensions.w; ++l)
                    {
                        if (cells[i, j, k, l])
                        {
                            hash ^= 1 << (i + (j * 2) + (k * 4) + (l * 8)) % 32;
                        }
                        else
                        {
                            hash ^= 1 << ((i * 8) + (j * 5) + (k * 3) + (l * 2)) % 32;
                        }
                    }
                }
            }
        }

        return hash;
    }
}
