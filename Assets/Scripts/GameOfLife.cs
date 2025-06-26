using System;
using System.Runtime.CompilerServices;

public class GameOfLife
{
    public struct Vector4i : IEquatable<Vector4i>
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

        public readonly bool Equals(Vector4i other)
        {
            return x == other.x && other.y == y && other.z == z && other.w == w;
        }

        public override readonly int GetHashCode()
        {
            return ~x ^ 
                ((y << 8) | (y >> (24))) ^
                ~((z << 16) | (z >> (16))) ^
                ((w << 24) | (w >> (8)));
        }

        public override readonly string ToString()
        {
            return "(" + x + ", " + y + ", " + z + ", " + w + ")";
        }
    }

    // World properties
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
    public bool wrap = false;
    public float initialPercentAlive = 0.25f;

    // Rules
    public int[] birth = new int[] { 3 };
    public int[] survival = new int[] { 2, 3 };

    // World state
    /// <summary>
    /// Current states of all cells.
    /// </summary>
    public bool[,,,] cells;
    private byte[,,,] neighborCounts;
    /// <summary>
    /// List of live cells. Updated when randomizing, and during cell update phase. Used in counting neighbor phase. Length is <see cref="numAlive"/>.
    /// </summary>
    public Vector4i[] liveCells;
    /// <summary>
    /// List of dead cells. Updated when randomizing, and during cell update phase. Used in counting neighbor phase. Length is <see cref="numCells"/> - <see cref="numAlive"/>.
    /// </summary>
    //public Vector4i[] deadCells;
    /// <summary>
    /// List of changed cells since last generation. Updated during cell update phase, when <see cref="SetState(bool, Vector4i)"/> is called.<br/>
    /// Used in counting neighbor phase. Length is <see cref="numChanges"/>. Length is <see cref="numChanges"/>.
    /// </summary>
    public Vector4i[] changes;

    /// <summary>
    /// Current total count of cells in the world.
    /// </summary>
    public int numCells
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private set;
    }

    /// <summary>
    /// Current count of live cells in the world. De facto length of <see cref="liveCells"/>.
    /// </summary>
    public int numAlive
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private set;
    }

    /// <summary>
    /// Count of cells that have changed since last generation. De facto length of <see cref="changes"/>.
    /// </summary>
    public int numChanges
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private set;
    }

    /// <summary>
    /// Current generation.
    /// </summary>
    public int tickNum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private set;
    }

    // Settings
    public bool alwaysCountNeighbors = false;
    public bool alwaysUseChanges = false;
    
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

        if (numChanges == 0)
        {
            return;
        }

        // Neighbor counting phase
        UpdateNumLiveNeighborsForAll();
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
        //if (deadCells == null)
        //{
        //    deadCells = new Vector4i[numCells];
        //}

        int numLiveCells = 0;
        //int numDeadCells = 0;

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
                            if (IndexOf(survival, neighborCounts[i, j, k, l]) >= 0)
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
                                SetState(i, j, k, l, false);
                                //deadCells[numDeadCells].x = i;
                                //deadCells[numDeadCells].y = j;
                                //deadCells[numDeadCells].z = k;
                                //deadCells[numDeadCells++].w = l;
                            }
                        }
                        else
                        {
                            if (IndexOf(birth, neighborCounts[i, j, k, l]) >= 0)
                            {
                                // Cell is born. Add to list, change state.
                                liveCells[numLiveCells].x = i;
                                liveCells[numLiveCells].y = j;
                                liveCells[numLiveCells].z = k;
                                liveCells[numLiveCells++].w = l;
                                SetState(i, j, k, l, true);
                            }
                            //else
                            //{
                            //    // Cell remains dead. Add to list, leave state.
                            //    deadCells[numDeadCells].x = i;
                            //    deadCells[numDeadCells].y = j;
                            //    deadCells[numDeadCells].z = k;
                            //    deadCells[numDeadCells++].w = l;
                            //}
                        }
                    }
                }
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int IndexOf(int[] array, int val)
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
                return m;
            }
        }

        return -1;
    }

    private void UpdateNumLiveNeighborsForAll()
    {
        if ((numAlive < numChanges && !alwaysUseChanges) || alwaysCountNeighbors || numChanges < 0 || changes == null)
        {
            if (liveCells == null)
            {
                liveCells = new Vector4i[numCells];
                //deadCells = new Vector4i[numCells];
                CountLiveNeighborsForAll();
            }
            else
            {
                ApplyLiveNeighborsForAll();
            }
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
                            UpdateNeighbors(i, j, k, l);
                        }
                    }
                }
            }
        }
    }

    private void ApplyLiveNeighborsForAll()
    {
        // Do a full neighbor count from scratch
        Array.Clear(neighborCounts, 0, neighborCounts.Length);
        for (int i = 0; i < numAlive; ++i)
        {
            UpdateNeighbors(liveCells[i]);
        }
    }

    private void ApplyNeighborChangesForAll()
    {
        // Only apply changes to neighbors from last tick
        for (int i = 0; i < numChanges; ++i)
        {
            UpdateNeighbors(changes[i]);
        }

        Array.Clear(changes, 0, numChanges);
    }

    /// <summary>
    /// Updates the live neighbor lists for all neighbors of a cell, based on the state of a the cell.
    /// </summary>
    /// <param name="cell">The cell.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void UpdateNeighbors(Vector4i cell)
    {
        UpdateNeighbors(cell.x, cell.y, cell.z, cell.w);
    }

    // Allocate arrays for neighbor indices to update here. Prevents garbage generation.
    private int[] neighborX = new int[] { 0, 0, 0 };
    private int[] neighborY = new int[] { 0, 0, 0 };
    private int[] neighborZ = new int[] { 0, 0, 0 };
    private int[] neighborW = new int[] { 0, 0, 0 };
    /// <summary>
    /// Updates the live neighbor lists for all neighbors of a cell, based on the state of a the cell.
    /// </summary>
    /// <param name="x">X coordinate of the cell.</param>
    /// <param name="y">Y coordinate of the cell.</param>
    /// <param name="z">Z coordinate of the cell.</param>
    /// <param name="w">W coordinate of the cell.</param>
    private void UpdateNeighbors(int x, int y, int z, int w)
    {
        neighborX[1] = x;
        neighborY[1] = y;
        neighborZ[1] = z;
        neighborW[1] = w;

        if (wrap)
        {
            // We don't want to count the same cells more than once, even when wrapping (like when one of the dimensions is 2 wide).
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

                        neighborCounts[neighborX[i], neighborY[j], neighborZ[k], neighborW[l]] += (byte)(cells[x, y, z, w] ? 1 : -1);
                    }
                }
            }
        }
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

    /// <summary>
    /// Resize the world to the given size.
    /// </summary>
    /// <param name="newWidth">New width.</param>
    /// <param name="newHeight">New height.</param>
    /// <param name="newDepth">New depth.</param>
    /// <param name="newColors">New colors.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Resize(int newWidth, int newHeight, int newDepth, int newColors)
    {
        if (cells != null &&
            _dimensions.x == newWidth &&
            _dimensions.y == newHeight &&
            _dimensions.z == newDepth &&
            _dimensions.w == newColors &&
            cells.GetLength(0) == newWidth &&
            cells.GetLength(1) == newHeight &&
            cells.GetLength(2) == newDepth &&
            cells.GetLength(3) == newColors)
        {
            Clear();
            return;
        }

        tickNum = 0;
        numAlive = 0;
        numChanges = 0;

        numCells = newWidth * newHeight * newDepth * newColors;

        _dimensions.x = newWidth;
        _dimensions.y = newHeight;
        _dimensions.z = newDepth;
        _dimensions.w = newColors;

        // Resize arrays
        cells = new bool[newWidth, newHeight, newDepth, newColors];
        neighborCounts = new byte[newWidth, newHeight, newDepth, newColors];
        changes = new Vector4i[numCells];
        liveCells = new Vector4i[numCells];
        //deadCells = new Vector4i[numCells];
    }

    /// <summary>
    /// Resize the world to the given size.
    /// </summary>
    /// <param name="newDimensions">New size.</param>
    public void Resize(Vector4i newDimensions)
    {
        Resize(newDimensions.x, newDimensions.y, newDimensions.z, newDimensions.w);
    }

    /// <summary>
    /// Randomly generates a new world. A seed can be provided to generate a world consistently.
    /// </summary>
    /// <param name="seed">Optional seed for random generation.</param>
    public void Randomize(int seed = 0)
    {
        Clear();
        numChanges = 0;
        Random rng;
        if (seed != 0)
        {
            rng = new Random(seed);
        }
        else
        {
            rng = new Random();
        }

        //int deadCellCount = 0;
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
                            SetState(i, j, k, l, true);
                        }
                        //else
                        //{
                        //    deadCells[deadCellCount].x = i;
                        //    deadCells[deadCellCount].y = j;
                        //    deadCells[deadCellCount].z = k;
                        //    deadCells[deadCellCount++].w = l;
                        //}
                    }
                }
            }
        }
    }

    /// <summary>
    /// Resets the current state of the world to empty.
    /// </summary>
    public void Clear()
    {
        tickNum = 0;

        numChanges = numAlive;
        Array.Copy(liveCells, changes, numAlive);

        numAlive = 0;
        Array.Clear(cells, 0, cells.Length);
        Array.Clear(neighborCounts, 0, neighborCounts.Length);
        if (liveCells == null)
        {
            liveCells = new Vector4i[numCells];
        }
        else
        {
            Array.Clear(liveCells, 0, liveCells.Length);
        }
        //if (deadCells == null)
        //{
        //    deadCells = new Vector4i[numCells];
        //}
        //else
        //{
        //    Array.Clear(deadCells, 0, deadCells.Length);
        //}
    }

    /// <summary>
    /// Sets the state of a given cell. Does nothing if cell state is not changed. Do not use more than once for the same cell in a tick.
    /// </summary>
    /// <param name="cell">The cell.</param>
    /// <param name="alive">New state for the cell.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SetState(Vector4i cell, bool alive)
    {
        SetState(cell.x, cell.y, cell.z, cell.w, alive);
    }

    /// <summary>
    /// Sets the state of a given cell. Does nothing if cell state is not changed. Do not use more than once for the same cell in a tick.
    /// </summary>
    /// <param name="x">X coordinate of the cell.</param>
    /// <param name="y">Y coordinate of the cell.</param>
    /// <param name="z">Z coordinate of the cell.</param>
    /// <param name="w">W coordinate of the cell.</param>
    /// <param name="alive">New state for the cell.</param>
    public void SetState(int x, int y, int z, int w, bool alive)
    {
        if (alive != cells[x, y, z, w])
        {
            cells[x, y, z, w] = alive;
            numAlive += alive ? 1 : -1;
            changes[numChanges++] = new Vector4i() { x = x, y = y, z = z, w = w };
        }
    }

    /// <summary>
    /// Toggles the state of a given cell. Do not use more than once for the same cell in a tick.
    /// </summary>
    /// <param name="cell">The cell.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ToggleState(Vector4i cell)
    {
        ToggleState(cell.x, cell.y, cell.z, cell.w);
    }

    /// <summary>
    /// Toggles the state of a given cell. Do not use more than once for the same cell in a tick.
    /// </summary>
    /// <param name="x">X coordinate of the cell.</param>
    /// <param name="y">Y coordinate of the cell.</param>
    /// <param name="z">Z coordinate of the cell.</param>
    /// <param name="w">W coordinate of the cell.</param>
    /// <param name="alive">New state for the cell.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ToggleState(int x, int y, int z, int w)
    {
        SetState(x, y, z, w, !cells[x, y, z, w]);
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

        // Hash dimensions
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
