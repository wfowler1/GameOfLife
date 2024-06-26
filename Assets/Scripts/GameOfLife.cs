using System;
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
    
    public bool[,,,] liveCells;
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

        GetNumLiveNeighborsForAll();
        CalculateLife();
    }

    private void CalculateLife()
    {
        for (int i = 0; i < _dimensions.x; ++i)
        {
            for (int j = 0; j < _dimensions.y; ++j)
            {
                for (int k = 0; k < _dimensions.z; ++k)
                {
                    for (int l = 0; l < _dimensions.w; ++l)
                    {
                        bool wasLive = liveCells[i, j, k, l];
                        // Enumerable.Contains runs slow and creates garbage
                        if (wasLive && !ArrayContains(survival, neighborCounts[i, j, k, l]))
                        {
                            SetState(false, i, j, k, l);
                        }
                        else if (ArrayContains(birth, neighborCounts[i, j, k, l]))
                        {
                            SetState(true, i, j, k, l);
                        }
                    }
                }
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool ArrayContains(int[] array, int val)
    {
        for (int i = 0; i < array.Length; ++i)
        {
            if (array[i] == val)
            {
                return true;
            }
        }

        return false;
    }

    private void GetNumLiveNeighborsForAll()
    {
        if (numChanges > numAlive || numChanges < 0)
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

        for (int i = 0; i < _dimensions.x; ++i)
        {
            for (int j = 0; j < _dimensions.y; ++j)
            {
                for (int k = 0; k < _dimensions.z; ++k)
                {
                    for (int l = 0; l < _dimensions.w; ++l)
                    {
                        if (liveCells[i, j, k, l])
                        {
                            AddToNeighbors(i, j, k, l, false);
                        }
                    }
                }
            }
        }
    }

    private void ApplyNeighborChangesForAll()
    {
        // Only apply changes to neighbors from last tick
        for (int i = 0; i < numChanges; ++i)
        {
            Vector4i cell = changes[i];
            AddToNeighbors(cell.x, cell.y, cell.z, cell.w, !liveCells[cell.x, cell.y, cell.z, cell.w]);
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
        if (liveCells != null &&
            _dimensions.x == newDimensions.x &&
            _dimensions.y == newDimensions.y &&
            _dimensions.z == newDimensions.z &&
            _dimensions.w == newDimensions.w &&
            liveCells.GetLength(0) == newDimensions.x &&
            liveCells.GetLength(1) == newDimensions.y &&
            liveCells.GetLength(2) == newDimensions.z &&
            liveCells.GetLength(3) == newDimensions.w)
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
        liveCells = new bool[newDimensions.x, newDimensions.y, newDimensions.z, newDimensions.w];
        neighborCounts = new int[newDimensions.x, newDimensions.y, newDimensions.z, newDimensions.w];
        changes = new Vector4i[numCells];
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
        for (int i = 0; i < _dimensions.x; ++i)
        {
            for (int j = 0; j < _dimensions.y; ++j)
            {
                for (int k = 0; k < _dimensions.z; ++k)
                {
                    for (int l = 0; l < _dimensions.w; ++l)
                    {
                        bool alive = rng.NextDouble() <= initialPercentAlive;
                        SetState(alive, i, j, k, l);
                    }
                }
            }
        }
    }

    public void Clear()
    {
        tickNum = 0;
        numAlive = 0;
        Array.Clear(liveCells, 0, liveCells.Length);
        Array.Clear(neighborCounts, 0, neighborCounts.Length);
        numChanges = 0;
        Array.Clear(changes, 0, changes.Length);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SetState(bool alive, Vector4i cell)
    {
        SetState(alive, cell.x, cell.y, cell.z, cell.w);
    }

    public void SetState(bool alive, int x, int y, int z, int w)
    {
        if (alive != liveCells[x, y, z, w])
        {
            liveCells[x, y, z, w] = alive;
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
        SetState(!liveCells[x, y, z, w], x, y, z, w);
    }
}
