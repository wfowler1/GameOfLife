using UnityEngine.Animations;

public static class Presets
{
    public static void ConwayRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 3 };
        gol.survival = new int[] { 2, 3 };
        gol.wrap = false;
        gol.initialPercentAlive = 0.5f;
    }

    public static void LifeWithoutDeathRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 3 };
        gol.survival = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        gol.wrap = false;
        gol.initialPercentAlive = 0.025f;
    }

    public static void HighLifeRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 3, 6 };
        gol.survival = new int[] { 2, 3 };
        gol.wrap = false;
        gol.initialPercentAlive = 0.2f;
    }

    public static void AssimilationRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 3, 4, 5 };
        gol.survival = new int[] { 4, 5, 6, 7 };
        gol.wrap = true;
        gol.initialPercentAlive = 0.2f;
    }

    public static void FredkinRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 1, 3, 5, 7 };
        gol.survival = new int[] { 1, 3, 5, 7 };
        gol.wrap = false;
        gol.initialPercentAlive = 0.001f;
    }

    public static void SeedsRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 2 };
        gol.survival = new int[] { };
        gol.wrap = true;
        gol.initialPercentAlive = 0.01f;
    }

    public static void ThreeFourRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 3, 4 };
        gol.survival = new int[] { 3, 4 };
        gol.wrap = false;
        gol.initialPercentAlive = 0.15f;
    }

    public static void MorleyRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 3, 6, 8 };
        gol.survival = new int[] { 2, 4, 5 };
        gol.wrap = true;
        gol.initialPercentAlive = 0.5f;
    }

    public static void AnnealRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 4, 6, 7, 8 };
        gol.survival = new int[] { 3, 5, 6, 7, 8 };
        gol.wrap = true;
        gol.initialPercentAlive = 0.5f;
    }

    public static void RiversRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 5, 6, 7 };
        gol.survival = new int[] { 4, 5, 6, 7, 8 };
        gol.wrap = true;
        gol.initialPercentAlive = 0.5f;
    }

    public static void CitiesRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 4, 5, 6, 7, 8 };
        gol.survival = new int[] { 2, 3, 4, 5 };
        gol.wrap = false;
        gol.initialPercentAlive = 0.2f;
    }

    public static void Bays5766Rules(this GameOfLife gol)
    {
        gol.birth = new int[] { 6 };
        gol.survival = new int[] { 5, 6, 7 };
        gol.wrap = true;
        gol.initialPercentAlive = 0.2f;
    }

    public static void Bays4555Rules(this GameOfLife gol)
    {
        gol.birth = new int[] { 5 };
        gol.survival = new int[] { 4, 5 };
        gol.wrap = true;
        gol.initialPercentAlive = 0.15f;
    }

    public static void Bays10211021Rules(this GameOfLife gol)
    {
        gol.birth = new int[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 };
        gol.survival = new int[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 };
        gol.wrap = true;
        gol.initialPercentAlive = 0.2675f;
    }

    public static void BaysB5S47Rules(this GameOfLife gol)
    {
        gol.birth = new int[] { 5 };
        gol.survival = new int[] { 4, 7 };
        gol.wrap = true;
        gol.initialPercentAlive = 0.2f;
    }

    public static void B78S5678Rules(this GameOfLife gol)
    {
        gol.birth = new int[] { 7, 8 };
        gol.survival = new int[] { 5, 6, 7, 8 };
        gol.wrap = true;
        gol.initialPercentAlive = 0.2f;
    }

    public static void Wallace1Rules(this GameOfLife gol)
    {
        gol.birth = new int[] { 5 };
        gol.survival = new int[] { 5, 6, 7, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 };
        gol.wrap = true;
        gol.initialPercentAlive = 0.05f;
    }

    public static void Wallace2Rules(this GameOfLife gol)
    {
        gol.birth = new int[] { 14, 15, 16, 17, 18, 19 };
        gol.survival = new int[] { 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 };
        gol.wrap = true;
        gol.initialPercentAlive = 0.5f;
    }

    public static void EvansRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 4 };
        gol.survival = new int[] { 5, 6 };
        gol.wrap = true;
        gol.initialPercentAlive = 0.25f;
    }

    public static void LifeWithoutDeath3DRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 7, 8 };
        gol.survival = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 };
        gol.wrap = false;
        gol.initialPercentAlive = 0.05f;
    }

    public static void B2123S10224DRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 21, 22, 23 };
        gol.survival = new int[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22 };
        gol.wrap = false;
        gol.initialPercentAlive = 0.3f;
    }

    public static void B4163S40804DRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63 };
        gol.survival = new int[] { 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80 };
        gol.wrap = true;
        gol.initialPercentAlive = 0.5f;
    }

    public static void SimpleGlider(this GameOfLife gol, int xAxis = 0, int yAxis = 1)
    {
        gol.ConwayRules();
        gol.SetDimensions(xAxis, 20, yAxis, 15);
        gol.wrap = true;

        gol.Clear();

        gol.SetStateByAxes(true, xAxis, 1, yAxis, 11);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 10);
        gol.SetStateByAxes(true, xAxis, 0, yAxis, 9);
        gol.SetStateByAxes(true, xAxis, 1, yAxis, 9);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 9);

        gol.currentBehavior = "Simple glider";
    }
    
    public static void SpaceShips(this GameOfLife gol, int xAxis = 0, int yAxis = 1)
    {
        gol.ConwayRules();
        gol.SetDimensions(xAxis, 20, yAxis, 15);
        gol.wrap = true;

        gol.Clear();

        gol.SetStateByAxes(true, xAxis, 1, yAxis, 1);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 1);
        gol.SetStateByAxes(true, xAxis, 3, yAxis, 1);
        gol.SetStateByAxes(true, xAxis, 4, yAxis, 1);
        gol.SetStateByAxes(true, xAxis, 0, yAxis, 2);
        gol.SetStateByAxes(true, xAxis, 4, yAxis, 2);
        gol.SetStateByAxes(true, xAxis, 4, yAxis, 3);
        gol.SetStateByAxes(true, xAxis, 0, yAxis, 4);
        gol.SetStateByAxes(true, xAxis, 3, yAxis, 4);

        gol.SetStateByAxes(true, xAxis, 1, yAxis, 8);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 8);
        gol.SetStateByAxes(true, xAxis, 3, yAxis, 8);
        gol.SetStateByAxes(true, xAxis, 4, yAxis, 8);
        gol.SetStateByAxes(true, xAxis, 5, yAxis, 8);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 8);
        gol.SetStateByAxes(true, xAxis, 0, yAxis, 9);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 9);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 10);
        gol.SetStateByAxes(true, xAxis, 0, yAxis, 11);
        gol.SetStateByAxes(true, xAxis, 5, yAxis, 11);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 12);
        gol.SetStateByAxes(true, xAxis, 3, yAxis, 12);

        gol.currentBehavior = "Space ship gliders";
    }
    
    public static void Pulsar(this GameOfLife gol, int xAxis = 0, int yAxis = 1)
    {
        gol.ConwayRules();
        gol.SetDimensions(xAxis, 17, yAxis, 17);

        gol.Clear();

        gol.SetStateByAxes(true, xAxis, 4, yAxis, 2);
        gol.SetStateByAxes(true, xAxis, 5, yAxis, 2);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 2);
        gol.SetStateByAxes(true, xAxis, 10, yAxis, 2);
        gol.SetStateByAxes(true, xAxis, 11, yAxis, 2);
        gol.SetStateByAxes(true, xAxis, 12, yAxis, 2);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 4);
        gol.SetStateByAxes(true, xAxis, 7, yAxis, 4);
        gol.SetStateByAxes(true, xAxis, 9, yAxis, 4);
        gol.SetStateByAxes(true, xAxis, 14, yAxis, 4);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 5);
        gol.SetStateByAxes(true, xAxis, 7, yAxis, 5);
        gol.SetStateByAxes(true, xAxis, 9, yAxis, 5);
        gol.SetStateByAxes(true, xAxis, 14, yAxis, 5);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 6);
        gol.SetStateByAxes(true, xAxis, 7, yAxis, 6);
        gol.SetStateByAxes(true, xAxis, 9, yAxis, 6);
        gol.SetStateByAxes(true, xAxis, 14, yAxis, 6);
        gol.SetStateByAxes(true, xAxis, 4, yAxis, 7);
        gol.SetStateByAxes(true, xAxis, 5, yAxis, 7);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 7);
        gol.SetStateByAxes(true, xAxis, 10, yAxis, 7);
        gol.SetStateByAxes(true, xAxis, 11, yAxis, 7);
        gol.SetStateByAxes(true, xAxis, 12, yAxis, 7);
        gol.SetStateByAxes(true, xAxis, 4, yAxis, 9);
        gol.SetStateByAxes(true, xAxis, 5, yAxis, 9);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 9);
        gol.SetStateByAxes(true, xAxis, 10, yAxis, 9);
        gol.SetStateByAxes(true, xAxis, 11, yAxis, 9);
        gol.SetStateByAxes(true, xAxis, 12, yAxis, 9);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 10);
        gol.SetStateByAxes(true, xAxis, 7, yAxis, 10);
        gol.SetStateByAxes(true, xAxis, 9, yAxis, 10);
        gol.SetStateByAxes(true, xAxis, 14, yAxis, 10);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 11);
        gol.SetStateByAxes(true, xAxis, 7, yAxis, 11);
        gol.SetStateByAxes(true, xAxis, 9, yAxis, 11);
        gol.SetStateByAxes(true, xAxis, 14, yAxis, 11);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 12);
        gol.SetStateByAxes(true, xAxis, 7, yAxis, 12);
        gol.SetStateByAxes(true, xAxis, 9, yAxis, 12);
        gol.SetStateByAxes(true, xAxis, 14, yAxis, 12);
        gol.SetStateByAxes(true, xAxis, 4, yAxis, 14);
        gol.SetStateByAxes(true, xAxis, 5, yAxis, 14);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 14);
        gol.SetStateByAxes(true, xAxis, 10, yAxis, 14);
        gol.SetStateByAxes(true, xAxis, 11, yAxis, 14);
        gol.SetStateByAxes(true, xAxis, 12, yAxis, 14);
        
        gol.currentBehavior = "Pulsar";
    }

    public static void PentaDecathlon(this GameOfLife gol, int xAxis = 0, int yAxis = 1)
    {
        gol.ConwayRules();
        gol.SetDimensions(xAxis, 10, yAxis, 18);

        gol.Clear();

        gol.SetStateByAxes(true, xAxis, 4, yAxis, 5);
        gol.SetStateByAxes(true, xAxis, 5, yAxis, 5);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 5);
        gol.SetStateByAxes(true, xAxis, 4, yAxis, 6);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 6);
        gol.SetStateByAxes(true, xAxis, 4, yAxis, 7);
        gol.SetStateByAxes(true, xAxis, 5, yAxis, 7);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 7);
        gol.SetStateByAxes(true, xAxis, 4, yAxis, 8);
        gol.SetStateByAxes(true, xAxis, 5, yAxis, 8);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 8);
        gol.SetStateByAxes(true, xAxis, 4, yAxis, 9);
        gol.SetStateByAxes(true, xAxis, 5, yAxis, 9);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 9);
        gol.SetStateByAxes(true, xAxis, 4, yAxis, 10);
        gol.SetStateByAxes(true, xAxis, 5, yAxis, 10);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 10);
        gol.SetStateByAxes(true, xAxis, 4, yAxis, 11);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 11);
        gol.SetStateByAxes(true, xAxis, 4, yAxis, 12);
        gol.SetStateByAxes(true, xAxis, 5, yAxis, 12);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 12);
        
        gol.currentBehavior = "Pentadecathlon";
    }

    public static void GosperGun(this GameOfLife gol, int xAxis = 0, int yAxis = 1)
    {
        int height = 29;
        gol.ConwayRules();
        gol.SetDimensions(xAxis, 44, yAxis, height);

        gol.Clear();
        
        gol.SetStateByAxes(true, xAxis, 25, yAxis, height - 2);
        gol.SetStateByAxes(true, xAxis, 23, yAxis, height - 3);
        gol.SetStateByAxes(true, xAxis, 25, yAxis, height - 3);
        gol.SetStateByAxes(true, xAxis, 13, yAxis, height - 4);
        gol.SetStateByAxes(true, xAxis, 14, yAxis, height - 4);
        gol.SetStateByAxes(true, xAxis, 21, yAxis, height - 4);
        gol.SetStateByAxes(true, xAxis, 22, yAxis, height - 4);
        gol.SetStateByAxes(true, xAxis, 35, yAxis, height - 4);
        gol.SetStateByAxes(true, xAxis, 36, yAxis, height - 4);
        gol.SetStateByAxes(true, xAxis, 12, yAxis, height - 5);
        gol.SetStateByAxes(true, xAxis, 16, yAxis, height - 5);
        gol.SetStateByAxes(true, xAxis, 21, yAxis, height - 5);
        gol.SetStateByAxes(true, xAxis, 22, yAxis, height - 5);
        gol.SetStateByAxes(true, xAxis, 35, yAxis, height - 5);
        gol.SetStateByAxes(true, xAxis, 36, yAxis, height - 5);
        gol.SetStateByAxes(true, xAxis, 1, yAxis, height - 6);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, height - 6);
        gol.SetStateByAxes(true, xAxis, 11, yAxis, height - 6);
        gol.SetStateByAxes(true, xAxis, 17, yAxis, height - 6);
        gol.SetStateByAxes(true, xAxis, 21, yAxis, height - 6);
        gol.SetStateByAxes(true, xAxis, 22, yAxis, height - 6);
        gol.SetStateByAxes(true, xAxis, 1, yAxis, height - 7);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, height - 7);
        gol.SetStateByAxes(true, xAxis, 11, yAxis, height - 7);
        gol.SetStateByAxes(true, xAxis, 15, yAxis, height - 7);
        gol.SetStateByAxes(true, xAxis, 17, yAxis, height - 7);
        gol.SetStateByAxes(true, xAxis, 18, yAxis, height - 7);
        gol.SetStateByAxes(true, xAxis, 23, yAxis, height - 7);
        gol.SetStateByAxes(true, xAxis, 25, yAxis, height - 7);
        gol.SetStateByAxes(true, xAxis, 11, yAxis, height - 8);
        gol.SetStateByAxes(true, xAxis, 17, yAxis, height - 8);
        gol.SetStateByAxes(true, xAxis, 25, yAxis, height - 8);
        gol.SetStateByAxes(true, xAxis, 12, yAxis, height - 9);
        gol.SetStateByAxes(true, xAxis, 16, yAxis, height - 9);
        gol.SetStateByAxes(true, xAxis, 13, yAxis, height - 10);
        gol.SetStateByAxes(true, xAxis, 14, yAxis, height - 10);

        gol.currentBehavior = "Gosper Gun";
    }

    public static void Acorn(this GameOfLife gol, int xAxis = 0, int yAxis = 1)
    {
        gol.ConwayRules();
        gol.SetDimensions(xAxis, 174, yAxis, 222);

        gol.Clear();

        gol.SetStateByAxes(true, xAxis, 118, yAxis, 89);
        gol.SetStateByAxes(true, xAxis, 119, yAxis, 89);
        gol.SetStateByAxes(true, xAxis, 122, yAxis, 89);
        gol.SetStateByAxes(true, xAxis, 123, yAxis, 89);
        gol.SetStateByAxes(true, xAxis, 124, yAxis, 89);
        gol.SetStateByAxes(true, xAxis, 119, yAxis, 91);
        gol.SetStateByAxes(true, xAxis, 121, yAxis, 90);

        gol.currentBehavior = "Acorn";
    }

    public static void SimpleGlider3D(this GameOfLife gol, int xAxis = 0, int yAxis = 1, int zAxis = 2)
    {
        gol.Bays5766Rules();
        gol.SetDimensions(xAxis, 20, yAxis, 15, zAxis, 4);
        gol.wrap = true;

        gol.Clear();

        gol.SetStateByAxes(true, xAxis, 1, yAxis, 11, zAxis, 1);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 10, zAxis, 1);
        gol.SetStateByAxes(true, xAxis, 0, yAxis, 9, zAxis, 1);
        gol.SetStateByAxes(true, xAxis, 1, yAxis, 9, zAxis, 1);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 9, zAxis, 1);
        gol.SetStateByAxes(true, xAxis, 1, yAxis, 11, zAxis, 2);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 10, zAxis, 2);
        gol.SetStateByAxes(true, xAxis, 0, yAxis, 9, zAxis, 2);
        gol.SetStateByAxes(true, xAxis, 1, yAxis, 9, zAxis, 2);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 9, zAxis, 2);

        gol.currentBehavior = "Simple glider 3D";
    }

    public static void Glider4555(this GameOfLife gol, int xAxis = 0, int yAxis = 1, int zAxis = 2)
    {
        gol.Bays4555Rules();
        gol.SetDimensions(xAxis, 15, yAxis, 20, zAxis, 15);
        gol.wrap = true;

        gol.Clear();

        gol.SetStateByAxes(true, xAxis, 7, yAxis, 0, zAxis, 0);
        gol.SetStateByAxes(true, xAxis, 8, yAxis, 0, zAxis, 0);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 1, zAxis, 0);
        gol.SetStateByAxes(true, xAxis, 7, yAxis, 1, zAxis, 1);
        gol.SetStateByAxes(true, xAxis, 8, yAxis, 1, zAxis, 1);
        gol.SetStateByAxes(true, xAxis, 9, yAxis, 1, zAxis, 0);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 2, zAxis, 0);
        gol.SetStateByAxes(true, xAxis, 7, yAxis, 2, zAxis, 1);
        gol.SetStateByAxes(true, xAxis, 8, yAxis, 2, zAxis, 1);
        gol.SetStateByAxes(true, xAxis, 9, yAxis, 2, zAxis, 0);

        gol.SetStateByAxes(true, xAxis, 0, yAxis, 10, zAxis, 7);
        gol.SetStateByAxes(true, xAxis, 0, yAxis, 10, zAxis, 8);
        gol.SetStateByAxes(true, xAxis, 0, yAxis, 11, zAxis, 6);
        gol.SetStateByAxes(true, xAxis, 1, yAxis, 11, zAxis, 7);
        gol.SetStateByAxes(true, xAxis, 1, yAxis, 11, zAxis, 8);
        gol.SetStateByAxes(true, xAxis, 0, yAxis, 11, zAxis, 9);
        gol.SetStateByAxes(true, xAxis, 0, yAxis, 12, zAxis, 6);
        gol.SetStateByAxes(true, xAxis, 1, yAxis, 12, zAxis, 7);
        gol.SetStateByAxes(true, xAxis, 1, yAxis, 12, zAxis, 8);
        gol.SetStateByAxes(true, xAxis, 0, yAxis, 12, zAxis, 9);

        gol.currentBehavior = "B5/S4,5 Glider";
    }

    public static void GliderB5S47(this GameOfLife gol, int xAxis = 0, int yAxis = 1, int zAxis = 2)
    {
        gol.BaysB5S47Rules();
        gol.SetDimensions(xAxis, 20, yAxis, 20, zAxis, 8);
        gol.wrap = true;

        gol.Clear();
        
        gol.SetStateByAxes(true, xAxis, 5, yAxis, 3, zAxis, 0);
        gol.SetStateByAxes(true, xAxis, 5, yAxis, 4, zAxis, 0);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 3, zAxis, 1);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 4, zAxis, 1);
        gol.SetStateByAxes(true, xAxis, 4, yAxis, 2, zAxis, 2);
        gol.SetStateByAxes(true, xAxis, 5, yAxis, 2, zAxis, 2);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 2, zAxis, 2);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 3, zAxis, 2);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 4, zAxis, 2);
        gol.SetStateByAxes(true, xAxis, 4, yAxis, 5, zAxis, 2);
        gol.SetStateByAxes(true, xAxis, 5, yAxis, 5, zAxis, 2);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 5, zAxis, 2);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 1, zAxis, 3);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 2, zAxis, 3);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 2, zAxis, 3);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 3, zAxis, 3);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 4, zAxis, 3);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 5, zAxis, 3);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 5, zAxis, 3);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 6, zAxis, 3);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 1, zAxis, 4);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 2, zAxis, 4);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 2, zAxis, 4);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 3, zAxis, 4);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 4, zAxis, 4);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 5, zAxis, 4);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 5, zAxis, 4);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 6, zAxis, 4);
        gol.SetStateByAxes(true, xAxis, 4, yAxis, 2, zAxis, 5);
        gol.SetStateByAxes(true, xAxis, 5, yAxis, 2, zAxis, 5);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 2, zAxis, 5);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 3, zAxis, 5);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 4, zAxis, 5);
        gol.SetStateByAxes(true, xAxis, 4, yAxis, 5, zAxis, 5);
        gol.SetStateByAxes(true, xAxis, 5, yAxis, 5, zAxis, 5);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 5, zAxis, 5);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 3, zAxis, 6);
        gol.SetStateByAxes(true, xAxis, 6, yAxis, 4, zAxis, 6);
        gol.SetStateByAxes(true, xAxis, 5, yAxis, 3, zAxis, 7);
        gol.SetStateByAxes(true, xAxis, 5, yAxis, 4, zAxis, 7);
        
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 12, zAxis, 1);
        gol.SetStateByAxes(true, xAxis, 3, yAxis, 12, zAxis, 1);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 13, zAxis, 1);
        gol.SetStateByAxes(true, xAxis, 3, yAxis, 13, zAxis, 1);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 14, zAxis, 1);
        gol.SetStateByAxes(true, xAxis, 3, yAxis, 14, zAxis, 1);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 11, zAxis, 2);
        gol.SetStateByAxes(true, xAxis, 3, yAxis, 11, zAxis, 2);
        gol.SetStateByAxes(true, xAxis, 4, yAxis, 12, zAxis, 2);
        gol.SetStateByAxes(true, xAxis, 4, yAxis, 14, zAxis, 2);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 15, zAxis, 2);
        gol.SetStateByAxes(true, xAxis, 3, yAxis, 15, zAxis, 2);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 11, zAxis, 3);
        gol.SetStateByAxes(true, xAxis, 3, yAxis, 11, zAxis, 3);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 15, zAxis, 3);
        gol.SetStateByAxes(true, xAxis, 3, yAxis, 15, zAxis, 3);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 11, zAxis, 4);
        gol.SetStateByAxes(true, xAxis, 3, yAxis, 11, zAxis, 4);
        gol.SetStateByAxes(true, xAxis, 4, yAxis, 12, zAxis, 4);
        gol.SetStateByAxes(true, xAxis, 4, yAxis, 14, zAxis, 4);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 15, zAxis, 4);
        gol.SetStateByAxes(true, xAxis, 3, yAxis, 15, zAxis, 4);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 12, zAxis, 5);
        gol.SetStateByAxes(true, xAxis, 3, yAxis, 12, zAxis, 5);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 13, zAxis, 5);
        gol.SetStateByAxes(true, xAxis, 3, yAxis, 13, zAxis, 5);
        gol.SetStateByAxes(true, xAxis, 2, yAxis, 14, zAxis, 5);
        gol.SetStateByAxes(true, xAxis, 3, yAxis, 14, zAxis, 5);

        gol.currentBehavior = "B5/S4,7 Glider";
    }

    private static void SetDimensions(this GameOfLife gol, int xAxis, int x, int yAxis = -1, int y = 1, int zAxis = -1, int z = 1, int wAxis = -1, int w = 1)
    {
        int width = 1;
        int height = 1;
        int depth = 1;
        int colors = 1;

        switch (xAxis)
        {
            case 0: {
                width = x;
                break;
            }
            case 1: {
                height = x;
                break;
            }
            case 2: {
                depth = x;
                break;
            }
            case 3: {
                colors = x;
                break;
            }
        }
        switch (yAxis)
        {
            case 0: {
                width = y;
                break;
            }
            case 1: {
                height = y;
                break;
            }
            case 2: {
                depth = y;
                break;
            }
            case 3: {
                colors = y;
                break;
            }
        }
        switch (zAxis)
        {
            case 0: {
                width = z;
                break;
            }
            case 1: {
                height = z;
                break;
            }
            case 2: {
                depth = z;
                break;
            }
            case 3: {
                colors = z;
                break;
            }
        }
        switch (wAxis)
        {
            case 0: {
                width = w;
                break;
            }
            case 1: {
                height = w;
                break;
            }
            case 2: {
                depth = w;
                break;
            }
            case 3: {
                colors = w;
                break;
            }
        }

        gol.Resize(new GameOfLife.Vector4i(width, height, depth, colors));
    }

    private static void SetStateByAxes(this GameOfLife gol, bool alive, int xAxis, int x, int yAxis = -1, int y = 0, int zAxis = -1, int z = 0, int wAxis = -1, int w = 0)
    {
        int[] indices = new int[4];
        if (xAxis >= 0)
        {
            indices[xAxis] = x;
        }
        if (yAxis >= 0)
        {
            indices[yAxis] = y;
        }
        if (zAxis >= 0)
        {
            indices[zAxis] = z;
        }
        if (wAxis >= 0)
        {
            indices[wAxis] = w;
        }
        gol.SetState(alive, indices[0], indices[1], indices[2], indices[3]);
    }

}
