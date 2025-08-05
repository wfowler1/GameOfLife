using System;

public static class Presets
{
    public static void ConwayRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 3 };
        gol.survival = new int[] { 2, 3 };
        gol.dimensions = new GameOfLife.Vector4i(Math.Abs(gol.dimensions.x), Math.Abs(gol.dimensions.y), Math.Abs(gol.dimensions.z), Math.Abs(gol.dimensions.w));
        gol.initialPercentAlive = 0.4f;
    }

    public static void LifeWithoutDeathRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 3 };
        gol.survival = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        gol.dimensions = new GameOfLife.Vector4i(Math.Abs(gol.dimensions.x), Math.Abs(gol.dimensions.y), Math.Abs(gol.dimensions.z), Math.Abs(gol.dimensions.w));
        gol.initialPercentAlive = 0.0225f;
    }

    public static void HighLifeRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 3, 6 };
        gol.survival = new int[] { 2, 3 };
        gol.dimensions = new GameOfLife.Vector4i(Math.Abs(gol.dimensions.x), Math.Abs(gol.dimensions.y), Math.Abs(gol.dimensions.z), Math.Abs(gol.dimensions.w));
        gol.initialPercentAlive = 0.4f;
    }

    public static void AssimilationRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 3, 4, 5 };
        gol.survival = new int[] { 4, 5, 6, 7 };
        gol.dimensions = new GameOfLife.Vector4i(-Math.Abs(gol.dimensions.x), -Math.Abs(gol.dimensions.y), -Math.Abs(gol.dimensions.z), -Math.Abs(gol.dimensions.w));
        gol.initialPercentAlive = 0.16f;
    }

    public static void FredkinRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 1, 3, 5, 7 };
        gol.survival = new int[] { 1, 3, 5, 7 };
        gol.dimensions = new GameOfLife.Vector4i(Math.Abs(gol.dimensions.x), Math.Abs(gol.dimensions.y), Math.Abs(gol.dimensions.z), Math.Abs(gol.dimensions.w));
        gol.initialPercentAlive = 0.001f;
    }

    public static void SeedsRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 2 };
        gol.survival = new int[] { };
        gol.dimensions = new GameOfLife.Vector4i(-Math.Abs(gol.dimensions.x), -Math.Abs(gol.dimensions.y), -Math.Abs(gol.dimensions.z), -Math.Abs(gol.dimensions.w));
        gol.initialPercentAlive = 0.01f;
    }

    public static void ThreeFourRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 3, 4 };
        gol.survival = new int[] { 3, 4 };
        gol.dimensions = new GameOfLife.Vector4i(Math.Abs(gol.dimensions.x), Math.Abs(gol.dimensions.y), Math.Abs(gol.dimensions.z), Math.Abs(gol.dimensions.w));
        gol.initialPercentAlive = 0.1f;
    }

    public static void MorleyRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 3, 6, 8 };
        gol.survival = new int[] { 2, 4, 5 };
        gol.dimensions = new GameOfLife.Vector4i(-Math.Abs(gol.dimensions.x), -Math.Abs(gol.dimensions.y), -Math.Abs(gol.dimensions.z), -Math.Abs(gol.dimensions.w));
        gol.initialPercentAlive = 0.4f;
    }

    public static void AnnealRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 4, 6, 7, 8 };
        gol.survival = new int[] { 3, 5, 6, 7, 8 };
        gol.dimensions = new GameOfLife.Vector4i(-Math.Abs(gol.dimensions.x), -Math.Abs(gol.dimensions.y), -Math.Abs(gol.dimensions.z), -Math.Abs(gol.dimensions.w));
        gol.initialPercentAlive = 0.5f;
    }

    public static void RiversRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 5, 6, 7, 8 };
        gol.survival = new int[] { 4, 5, 6, 7, 8 };
        gol.dimensions = new GameOfLife.Vector4i(-Math.Abs(gol.dimensions.x), -Math.Abs(gol.dimensions.y), -Math.Abs(gol.dimensions.z), -Math.Abs(gol.dimensions.w));
        gol.initialPercentAlive = 0.5f;
    }

    public static void CitiesRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 4, 5, 6, 7, 8 };
        gol.survival = new int[] { 2, 3, 4, 5 };
        gol.dimensions = new GameOfLife.Vector4i(Math.Abs(gol.dimensions.x), Math.Abs(gol.dimensions.y), Math.Abs(gol.dimensions.z), Math.Abs(gol.dimensions.w));
        gol.initialPercentAlive = 0.2f;
    }

    public static void Bays5766Rules(this GameOfLife gol)
    {
        gol.birth = new int[] { 6 };
        gol.survival = new int[] { 5, 6, 7 };
        gol.dimensions = new GameOfLife.Vector4i(-Math.Abs(gol.dimensions.x), -Math.Abs(gol.dimensions.y), -Math.Abs(gol.dimensions.z), -Math.Abs(gol.dimensions.w));
        gol.initialPercentAlive = 0.25f;
    }

    public static void Bays4555Rules(this GameOfLife gol)
    {
        gol.birth = new int[] { 5 };
        gol.survival = new int[] { 4, 5 };
        gol.dimensions = new GameOfLife.Vector4i(-Math.Abs(gol.dimensions.x), -Math.Abs(gol.dimensions.y), -Math.Abs(gol.dimensions.z), -Math.Abs(gol.dimensions.w));
        gol.initialPercentAlive = 0.22f;
    }

    public static void Bays10211021Rules(this GameOfLife gol)
    {
        gol.birth = new int[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 };
        gol.survival = new int[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 };
        gol.dimensions = new GameOfLife.Vector4i(-Math.Abs(gol.dimensions.x), -Math.Abs(gol.dimensions.y), -Math.Abs(gol.dimensions.z), -Math.Abs(gol.dimensions.w));
        gol.initialPercentAlive = 0.2675f;
    }

    public static void BaysB5S47Rules(this GameOfLife gol)
    {
        gol.birth = new int[] { 5 };
        gol.survival = new int[] { 4, 7 };
        gol.dimensions = new GameOfLife.Vector4i(-Math.Abs(gol.dimensions.x), -Math.Abs(gol.dimensions.y), -Math.Abs(gol.dimensions.z), -Math.Abs(gol.dimensions.w));
        gol.initialPercentAlive = 0.2f;
    }

    public static void B78S5678Rules(this GameOfLife gol)
    {
        gol.birth = new int[] { 7, 8 };
        gol.survival = new int[] { 5, 6, 7, 8 };
        gol.dimensions = new GameOfLife.Vector4i(-Math.Abs(gol.dimensions.x), -Math.Abs(gol.dimensions.y), -Math.Abs(gol.dimensions.z), -Math.Abs(gol.dimensions.w));
        gol.initialPercentAlive = 0.2f;
    }

    public static void Wallace1Rules(this GameOfLife gol)
    {
        gol.birth = new int[] { 5 };
        gol.survival = new int[] { 5, 6, 7, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 };
        gol.dimensions = new GameOfLife.Vector4i(-Math.Abs(gol.dimensions.x), -Math.Abs(gol.dimensions.y), -Math.Abs(gol.dimensions.z), -Math.Abs(gol.dimensions.w));
        gol.initialPercentAlive = 0.05f;
    }

    public static void Wallace2Rules(this GameOfLife gol)
    {
        gol.birth = new int[] { 14, 15, 16, 17, 18, 19 };
        gol.survival = new int[] { 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 };
        gol.dimensions = new GameOfLife.Vector4i(-Math.Abs(gol.dimensions.x), -Math.Abs(gol.dimensions.y), -Math.Abs(gol.dimensions.z), -Math.Abs(gol.dimensions.w));
        gol.initialPercentAlive = 0.5f;
    }

    public static void EvansRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 4 };
        gol.survival = new int[] { 5, 6 };
        gol.dimensions = new GameOfLife.Vector4i(-Math.Abs(gol.dimensions.x), -Math.Abs(gol.dimensions.y), -Math.Abs(gol.dimensions.z), -Math.Abs(gol.dimensions.w));
        gol.initialPercentAlive = 0.025f;
    }

    public static void LifeWithoutDeath3DRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 7, 8 };
        gol.survival = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 };
        gol.dimensions = new GameOfLife.Vector4i(Math.Abs(gol.dimensions.x), Math.Abs(gol.dimensions.y), Math.Abs(gol.dimensions.z), Math.Abs(gol.dimensions.w));
        gol.initialPercentAlive = 0.05f;
    }

    public static void Fredkin3DRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25 };
        gol.survival = new int[] { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25 };
        gol.dimensions = new GameOfLife.Vector4i(Math.Abs(gol.dimensions.x), Math.Abs(gol.dimensions.y), Math.Abs(gol.dimensions.z), Math.Abs(gol.dimensions.w));
        gol.initialPercentAlive = 0.0001f;
    }

    public static void B2123S10224DRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 21, 22, 23 };
        gol.survival = new int[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22 };
        gol.dimensions = new GameOfLife.Vector4i(Math.Abs(gol.dimensions.x), Math.Abs(gol.dimensions.y), Math.Abs(gol.dimensions.z), Math.Abs(gol.dimensions.w));
        gol.initialPercentAlive = 0.3f;
    }

    public static void B4163S40804DRules(this GameOfLife gol)
    {
        gol.birth = new int[] { 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63 };
        gol.survival = new int[] { 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80 };
        gol.dimensions = new GameOfLife.Vector4i(-Math.Abs(gol.dimensions.x), -Math.Abs(gol.dimensions.y), -Math.Abs(gol.dimensions.z), -Math.Abs(gol.dimensions.w));
        gol.initialPercentAlive = 0.5f;
    }

    public static void SimpleGlider(this GameOfLife gol, int xAxis = 0, int yAxis = 1)
    {
        gol.ConwayRules();
        gol.SetDimensions(xAxis, -20, yAxis, -15);

        gol.Clear();

        int currentIndex = 0;
        gol.SetAliveByAxes(currentIndex++, xAxis, 1, yAxis, 11);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 10);
        gol.SetAliveByAxes(currentIndex++, xAxis, 0, yAxis, 9);
        gol.SetAliveByAxes(currentIndex++, xAxis, 1, yAxis, 9);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 9);
    }
    
    public static void SpaceShips(this GameOfLife gol, int xAxis = 0, int yAxis = 1)
    {
        gol.ConwayRules();
        gol.SetDimensions(xAxis, -20, yAxis, 15);

        gol.Clear();

        int currentIndex = 0;
        gol.SetAliveByAxes(currentIndex++, xAxis, 1, yAxis, 1);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 1);
        gol.SetAliveByAxes(currentIndex++, xAxis, 3, yAxis, 1);
        gol.SetAliveByAxes(currentIndex++, xAxis, 4, yAxis, 1);
        gol.SetAliveByAxes(currentIndex++, xAxis, 0, yAxis, 2);
        gol.SetAliveByAxes(currentIndex++, xAxis, 4, yAxis, 2);
        gol.SetAliveByAxes(currentIndex++, xAxis, 4, yAxis, 3);
        gol.SetAliveByAxes(currentIndex++, xAxis, 0, yAxis, 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 3, yAxis, 4);

        gol.SetAliveByAxes(currentIndex++, xAxis, 1, yAxis, 8);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 8);
        gol.SetAliveByAxes(currentIndex++, xAxis, 3, yAxis, 8);
        gol.SetAliveByAxes(currentIndex++, xAxis, 4, yAxis, 8);
        gol.SetAliveByAxes(currentIndex++, xAxis, 5, yAxis, 8);
        gol.SetAliveByAxes(currentIndex++, xAxis, 6, yAxis, 8);
        gol.SetAliveByAxes(currentIndex++, xAxis, 0, yAxis, 9);
        gol.SetAliveByAxes(currentIndex++, xAxis, 6, yAxis, 9);
        gol.SetAliveByAxes(currentIndex++, xAxis, 6, yAxis, 10);
        gol.SetAliveByAxes(currentIndex++, xAxis, 0, yAxis, 11);
        gol.SetAliveByAxes(currentIndex++, xAxis, 5, yAxis, 11);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 12);
        gol.SetAliveByAxes(currentIndex++, xAxis, 3, yAxis, 12);
    }
    
    public static void Pulsar(this GameOfLife gol, int xAxis = 0, int yAxis = 1)
    {
        gol.ConwayRules();
        gol.SetDimensions(xAxis, 17, yAxis, 17);

        gol.Clear();

        int currentIndex = 0;
        gol.SetAliveByAxes(currentIndex++, xAxis, 4, yAxis, 2);
        gol.SetAliveByAxes(currentIndex++, xAxis, 5, yAxis, 2);
        gol.SetAliveByAxes(currentIndex++, xAxis, 6, yAxis, 2);
        gol.SetAliveByAxes(currentIndex++, xAxis, 10, yAxis, 2);
        gol.SetAliveByAxes(currentIndex++, xAxis, 11, yAxis, 2);
        gol.SetAliveByAxes(currentIndex++, xAxis, 12, yAxis, 2);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 7, yAxis, 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 9, yAxis, 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 14, yAxis, 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 5);
        gol.SetAliveByAxes(currentIndex++, xAxis, 7, yAxis, 5);
        gol.SetAliveByAxes(currentIndex++, xAxis, 9, yAxis, 5);
        gol.SetAliveByAxes(currentIndex++, xAxis, 14, yAxis, 5);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 6);
        gol.SetAliveByAxes(currentIndex++, xAxis, 7, yAxis, 6);
        gol.SetAliveByAxes(currentIndex++, xAxis, 9, yAxis, 6);
        gol.SetAliveByAxes(currentIndex++, xAxis, 14, yAxis, 6);
        gol.SetAliveByAxes(currentIndex++, xAxis, 4, yAxis, 7);
        gol.SetAliveByAxes(currentIndex++, xAxis, 5, yAxis, 7);
        gol.SetAliveByAxes(currentIndex++, xAxis, 6, yAxis, 7);
        gol.SetAliveByAxes(currentIndex++, xAxis, 10, yAxis, 7);
        gol.SetAliveByAxes(currentIndex++, xAxis, 11, yAxis, 7);
        gol.SetAliveByAxes(currentIndex++, xAxis, 12, yAxis, 7);
        gol.SetAliveByAxes(currentIndex++, xAxis, 4, yAxis, 9);
        gol.SetAliveByAxes(currentIndex++, xAxis, 5, yAxis, 9);
        gol.SetAliveByAxes(currentIndex++, xAxis, 6, yAxis, 9);
        gol.SetAliveByAxes(currentIndex++, xAxis, 10, yAxis, 9);
        gol.SetAliveByAxes(currentIndex++, xAxis, 11, yAxis, 9);
        gol.SetAliveByAxes(currentIndex++, xAxis, 12, yAxis, 9);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 10);
        gol.SetAliveByAxes(currentIndex++, xAxis, 7, yAxis, 10);
        gol.SetAliveByAxes(currentIndex++, xAxis, 9, yAxis, 10);
        gol.SetAliveByAxes(currentIndex++, xAxis, 14, yAxis, 10);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 11);
        gol.SetAliveByAxes(currentIndex++, xAxis, 7, yAxis, 11);
        gol.SetAliveByAxes(currentIndex++, xAxis, 9, yAxis, 11);
        gol.SetAliveByAxes(currentIndex++, xAxis, 14, yAxis, 11);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 12);
        gol.SetAliveByAxes(currentIndex++, xAxis, 7, yAxis, 12);
        gol.SetAliveByAxes(currentIndex++, xAxis, 9, yAxis, 12);
        gol.SetAliveByAxes(currentIndex++, xAxis, 14, yAxis, 12);
        gol.SetAliveByAxes(currentIndex++, xAxis, 4, yAxis, 14);
        gol.SetAliveByAxes(currentIndex++, xAxis, 5, yAxis, 14);
        gol.SetAliveByAxes(currentIndex++, xAxis, 6, yAxis, 14);
        gol.SetAliveByAxes(currentIndex++, xAxis, 10, yAxis, 14);
        gol.SetAliveByAxes(currentIndex++, xAxis, 11, yAxis, 14);
        gol.SetAliveByAxes(currentIndex++, xAxis, 12, yAxis, 14);
    }

    public static void PentaDecathlon(this GameOfLife gol, int xAxis = 0, int yAxis = 1)
    {
        gol.ConwayRules();
        gol.SetDimensions(xAxis, 18, yAxis, 9);

        gol.Clear();

        int currentIndex = 0;
        gol.SetAliveByAxes(currentIndex++, xAxis, 7, yAxis, 3);
        gol.SetAliveByAxes(currentIndex++, xAxis, 12, yAxis, 3);
        gol.SetAliveByAxes(currentIndex++, xAxis, 5, yAxis, 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 6, yAxis, 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 8, yAxis, 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 9, yAxis, 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 10, yAxis, 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 11, yAxis, 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 13, yAxis, 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 14, yAxis, 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 7, yAxis, 5);
        gol.SetAliveByAxes(currentIndex++, xAxis, 12, yAxis, 5);
    }

    public static void GosperGun(this GameOfLife gol, int xAxis = 0, int yAxis = 1)
    {
        int height = 29;
        gol.ConwayRules();
        gol.SetDimensions(xAxis, 44, yAxis, height);

        gol.Clear();

        int currentIndex = 0;
        gol.SetAliveByAxes(currentIndex++, xAxis, 25, yAxis, height - 2);
        gol.SetAliveByAxes(currentIndex++, xAxis, 23, yAxis, height - 3);
        gol.SetAliveByAxes(currentIndex++, xAxis, 25, yAxis, height - 3);
        gol.SetAliveByAxes(currentIndex++, xAxis, 13, yAxis, height - 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 14, yAxis, height - 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 21, yAxis, height - 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 22, yAxis, height - 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 35, yAxis, height - 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 36, yAxis, height - 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 12, yAxis, height - 5);
        gol.SetAliveByAxes(currentIndex++, xAxis, 16, yAxis, height - 5);
        gol.SetAliveByAxes(currentIndex++, xAxis, 21, yAxis, height - 5);
        gol.SetAliveByAxes(currentIndex++, xAxis, 22, yAxis, height - 5);
        gol.SetAliveByAxes(currentIndex++, xAxis, 35, yAxis, height - 5);
        gol.SetAliveByAxes(currentIndex++, xAxis, 36, yAxis, height - 5);
        gol.SetAliveByAxes(currentIndex++, xAxis, 1, yAxis, height - 6);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, height - 6);
        gol.SetAliveByAxes(currentIndex++, xAxis, 11, yAxis, height - 6);
        gol.SetAliveByAxes(currentIndex++, xAxis, 17, yAxis, height - 6);
        gol.SetAliveByAxes(currentIndex++, xAxis, 21, yAxis, height - 6);
        gol.SetAliveByAxes(currentIndex++, xAxis, 22, yAxis, height - 6);
        gol.SetAliveByAxes(currentIndex++, xAxis, 1, yAxis, height - 7);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, height - 7);
        gol.SetAliveByAxes(currentIndex++, xAxis, 11, yAxis, height - 7);
        gol.SetAliveByAxes(currentIndex++, xAxis, 15, yAxis, height - 7);
        gol.SetAliveByAxes(currentIndex++, xAxis, 17, yAxis, height - 7);
        gol.SetAliveByAxes(currentIndex++, xAxis, 18, yAxis, height - 7);
        gol.SetAliveByAxes(currentIndex++, xAxis, 23, yAxis, height - 7);
        gol.SetAliveByAxes(currentIndex++, xAxis, 25, yAxis, height - 7);
        gol.SetAliveByAxes(currentIndex++, xAxis, 11, yAxis, height - 8);
        gol.SetAliveByAxes(currentIndex++, xAxis, 17, yAxis, height - 8);
        gol.SetAliveByAxes(currentIndex++, xAxis, 25, yAxis, height - 8);
        gol.SetAliveByAxes(currentIndex++, xAxis, 12, yAxis, height - 9);
        gol.SetAliveByAxes(currentIndex++, xAxis, 16, yAxis, height - 9);
        gol.SetAliveByAxes(currentIndex++, xAxis, 13, yAxis, height - 10);
        gol.SetAliveByAxes(currentIndex++, xAxis, 14, yAxis, height - 10);
    }

    public static void Acorn(this GameOfLife gol, int xAxis = 0, int yAxis = 1)
    {
        gol.ConwayRules();
        gol.SetDimensions(xAxis, 174, yAxis, 222);

        gol.Clear();

        int currentIndex = 0;
        gol.SetAliveByAxes(currentIndex++, xAxis, 118, yAxis, 89);
        gol.SetAliveByAxes(currentIndex++, xAxis, 119, yAxis, 89);
        gol.SetAliveByAxes(currentIndex++, xAxis, 122, yAxis, 89);
        gol.SetAliveByAxes(currentIndex++, xAxis, 123, yAxis, 89);
        gol.SetAliveByAxes(currentIndex++, xAxis, 124, yAxis, 89);
        gol.SetAliveByAxes(currentIndex++, xAxis, 119, yAxis, 91);
        gol.SetAliveByAxes(currentIndex++, xAxis, 121, yAxis, 90);
    }

    public static void Fredkin64(this GameOfLife gol, int xAxis = 0, int yAxis = 1)
    {
        gol.FredkinRules();
        gol.SetDimensions(xAxis, -128, yAxis, -128);

        gol.Randomize();
    }

    public static void MorleyGlider(this GameOfLife gol, int xAxis = 0, int yAxis = 1)
    {
        gol.MorleyRules();
        gol.SetDimensions(xAxis, -128, yAxis, -72);

        gol.Clear();

        int currentIndex = 0;
        gol.SetAliveByAxes(currentIndex++, xAxis, 3, yAxis, 5);
        gol.SetAliveByAxes(currentIndex++, xAxis, 4, yAxis, 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 3, yAxis, 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 5, yAxis, 3);
        gol.SetAliveByAxes(currentIndex++, xAxis, 4, yAxis, 3);
        gol.SetAliveByAxes(currentIndex++, xAxis, 3, yAxis, 3);
    }

    public static void MorleyLargeGlider(this GameOfLife gol, int xAxis = 0, int yAxis = 1)
    {
        gol.MorleyRules();
        gol.SetDimensions(xAxis, -250, yAxis, 50);

        gol.Clear();

        int currentIndex = 0;
        gol.SetAliveByAxes(currentIndex++, xAxis, 3, yAxis, 23);
        gol.SetAliveByAxes(currentIndex++, xAxis, 4, yAxis, 23);
        gol.SetAliveByAxes(currentIndex++, xAxis, 5, yAxis, 23);
        gol.SetAliveByAxes(currentIndex++, xAxis, 6, yAxis, 23);

        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 24);
        gol.SetAliveByAxes(currentIndex++, xAxis, 6, yAxis, 24);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 25);
        gol.SetAliveByAxes(currentIndex++, xAxis, 6, yAxis, 25);

        gol.SetAliveByAxes(currentIndex++, xAxis, 3, yAxis, 26);
        gol.SetAliveByAxes(currentIndex++, xAxis, 4, yAxis, 26);
        gol.SetAliveByAxes(currentIndex++, xAxis, 5, yAxis, 26);
        gol.SetAliveByAxes(currentIndex++, xAxis, 6, yAxis, 26);
    }

    public static void SimpleGlider3D(this GameOfLife gol, int xAxis = 0, int yAxis = 1, int zAxis = 2)
    {
        gol.Bays5766Rules();
        gol.SetDimensions(xAxis, -20, yAxis, -15, zAxis, 4);

        gol.Clear();

        int currentIndex = 0;
        gol.SetAliveByAxes(currentIndex++, xAxis, 1, yAxis, 11, zAxis, 1);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 10, zAxis, 1);
        gol.SetAliveByAxes(currentIndex++, xAxis, 0, yAxis, 9, zAxis, 1);
        gol.SetAliveByAxes(currentIndex++, xAxis, 1, yAxis, 9, zAxis, 1);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 9, zAxis, 1);
        gol.SetAliveByAxes(currentIndex++, xAxis, 1, yAxis, 11, zAxis, 2);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 10, zAxis, 2);
        gol.SetAliveByAxes(currentIndex++, xAxis, 0, yAxis, 9, zAxis, 2);
        gol.SetAliveByAxes(currentIndex++, xAxis, 1, yAxis, 9, zAxis, 2);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 9, zAxis, 2);
    }

    public static void Glider4555(this GameOfLife gol, int xAxis = 0, int yAxis = 1, int zAxis = 2)
    {
        gol.Bays4555Rules();
        gol.SetDimensions(xAxis, -15, yAxis, -20, zAxis, -15);

        gol.Clear();

        int currentIndex = 0;
        gol.SetAliveByAxes(currentIndex++, xAxis, 7, yAxis, 0, zAxis, 0);
        gol.SetAliveByAxes(currentIndex++, xAxis, 8, yAxis, 0, zAxis, 0);
        gol.SetAliveByAxes(currentIndex++, xAxis, 6, yAxis, 1, zAxis, 0);
        gol.SetAliveByAxes(currentIndex++, xAxis, 7, yAxis, 1, zAxis, 1);
        gol.SetAliveByAxes(currentIndex++, xAxis, 8, yAxis, 1, zAxis, 1);
        gol.SetAliveByAxes(currentIndex++, xAxis, 9, yAxis, 1, zAxis, 0);
        gol.SetAliveByAxes(currentIndex++, xAxis, 6, yAxis, 2, zAxis, 0);
        gol.SetAliveByAxes(currentIndex++, xAxis, 7, yAxis, 2, zAxis, 1);
        gol.SetAliveByAxes(currentIndex++, xAxis, 8, yAxis, 2, zAxis, 1);
        gol.SetAliveByAxes(currentIndex++, xAxis, 9, yAxis, 2, zAxis, 0);

        gol.SetAliveByAxes(currentIndex++, xAxis, 0, yAxis, 10, zAxis, 7);
        gol.SetAliveByAxes(currentIndex++, xAxis, 0, yAxis, 10, zAxis, 8);
        gol.SetAliveByAxes(currentIndex++, xAxis, 0, yAxis, 11, zAxis, 6);
        gol.SetAliveByAxes(currentIndex++, xAxis, 1, yAxis, 11, zAxis, 7);
        gol.SetAliveByAxes(currentIndex++, xAxis, 1, yAxis, 11, zAxis, 8);
        gol.SetAliveByAxes(currentIndex++, xAxis, 0, yAxis, 11, zAxis, 9);
        gol.SetAliveByAxes(currentIndex++, xAxis, 0, yAxis, 12, zAxis, 6);
        gol.SetAliveByAxes(currentIndex++, xAxis, 1, yAxis, 12, zAxis, 7);
        gol.SetAliveByAxes(currentIndex++, xAxis, 1, yAxis, 12, zAxis, 8);
        gol.SetAliveByAxes(currentIndex++, xAxis, 0, yAxis, 12, zAxis, 9);
    }

    public static void GliderB5S47(this GameOfLife gol, int xAxis = 0, int yAxis = 1, int zAxis = 2)
    {
        gol.BaysB5S47Rules();
        gol.SetDimensions(xAxis, -20, yAxis, 20, zAxis, 8);

        gol.Clear();

        int currentIndex = 0;
        gol.SetAliveByAxes(currentIndex++, xAxis, 5, yAxis, 3, zAxis, 0);
        gol.SetAliveByAxes(currentIndex++, xAxis, 5, yAxis, 4, zAxis, 0);
        gol.SetAliveByAxes(currentIndex++, xAxis, 6, yAxis, 3, zAxis, 1);
        gol.SetAliveByAxes(currentIndex++, xAxis, 6, yAxis, 4, zAxis, 1);
        gol.SetAliveByAxes(currentIndex++, xAxis, 4, yAxis, 2, zAxis, 2);
        gol.SetAliveByAxes(currentIndex++, xAxis, 5, yAxis, 2, zAxis, 2);
        gol.SetAliveByAxes(currentIndex++, xAxis, 6, yAxis, 2, zAxis, 2);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 3, zAxis, 2);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 4, zAxis, 2);
        gol.SetAliveByAxes(currentIndex++, xAxis, 4, yAxis, 5, zAxis, 2);
        gol.SetAliveByAxes(currentIndex++, xAxis, 5, yAxis, 5, zAxis, 2);
        gol.SetAliveByAxes(currentIndex++, xAxis, 6, yAxis, 5, zAxis, 2);
        gol.SetAliveByAxes(currentIndex++, xAxis, 6, yAxis, 1, zAxis, 3);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 2, zAxis, 3);
        gol.SetAliveByAxes(currentIndex++, xAxis, 6, yAxis, 2, zAxis, 3);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 3, zAxis, 3);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 4, zAxis, 3);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 5, zAxis, 3);
        gol.SetAliveByAxes(currentIndex++, xAxis, 6, yAxis, 5, zAxis, 3);
        gol.SetAliveByAxes(currentIndex++, xAxis, 6, yAxis, 6, zAxis, 3);
        gol.SetAliveByAxes(currentIndex++, xAxis, 6, yAxis, 1, zAxis, 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 2, zAxis, 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 6, yAxis, 2, zAxis, 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 3, zAxis, 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 4, zAxis, 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 5, zAxis, 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 6, yAxis, 5, zAxis, 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 6, yAxis, 6, zAxis, 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 4, yAxis, 2, zAxis, 5);
        gol.SetAliveByAxes(currentIndex++, xAxis, 5, yAxis, 2, zAxis, 5);
        gol.SetAliveByAxes(currentIndex++, xAxis, 6, yAxis, 2, zAxis, 5);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 3, zAxis, 5);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 4, zAxis, 5);
        gol.SetAliveByAxes(currentIndex++, xAxis, 4, yAxis, 5, zAxis, 5);
        gol.SetAliveByAxes(currentIndex++, xAxis, 5, yAxis, 5, zAxis, 5);
        gol.SetAliveByAxes(currentIndex++, xAxis, 6, yAxis, 5, zAxis, 5);
        gol.SetAliveByAxes(currentIndex++, xAxis, 6, yAxis, 3, zAxis, 6);
        gol.SetAliveByAxes(currentIndex++, xAxis, 6, yAxis, 4, zAxis, 6);
        gol.SetAliveByAxes(currentIndex++, xAxis, 5, yAxis, 3, zAxis, 7);
        gol.SetAliveByAxes(currentIndex++, xAxis, 5, yAxis, 4, zAxis, 7);
        
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 12, zAxis, 1);
        gol.SetAliveByAxes(currentIndex++, xAxis, 3, yAxis, 12, zAxis, 1);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 13, zAxis, 1);
        gol.SetAliveByAxes(currentIndex++, xAxis, 3, yAxis, 13, zAxis, 1);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 14, zAxis, 1);
        gol.SetAliveByAxes(currentIndex++, xAxis, 3, yAxis, 14, zAxis, 1);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 11, zAxis, 2);
        gol.SetAliveByAxes(currentIndex++, xAxis, 3, yAxis, 11, zAxis, 2);
        gol.SetAliveByAxes(currentIndex++, xAxis, 4, yAxis, 12, zAxis, 2);
        gol.SetAliveByAxes(currentIndex++, xAxis, 4, yAxis, 14, zAxis, 2);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 15, zAxis, 2);
        gol.SetAliveByAxes(currentIndex++, xAxis, 3, yAxis, 15, zAxis, 2);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 11, zAxis, 3);
        gol.SetAliveByAxes(currentIndex++, xAxis, 3, yAxis, 11, zAxis, 3);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 15, zAxis, 3);
        gol.SetAliveByAxes(currentIndex++, xAxis, 3, yAxis, 15, zAxis, 3);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 11, zAxis, 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 3, yAxis, 11, zAxis, 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 4, yAxis, 12, zAxis, 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 4, yAxis, 14, zAxis, 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 15, zAxis, 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 3, yAxis, 15, zAxis, 4);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 12, zAxis, 5);
        gol.SetAliveByAxes(currentIndex++, xAxis, 3, yAxis, 12, zAxis, 5);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 13, zAxis, 5);
        gol.SetAliveByAxes(currentIndex++, xAxis, 3, yAxis, 13, zAxis, 5);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 14, zAxis, 5);
        gol.SetAliveByAxes(currentIndex++, xAxis, 3, yAxis, 14, zAxis, 5);
    }

    public static void EvansGlider(this GameOfLife gol, int xAxis = 0, int yAxis = 1, int zAxis = 2)
    {
        gol.EvansRules();
        gol.SetDimensions(xAxis, 5, yAxis, -16, zAxis, 5);

        gol.Clear();

        int currentIndex = 0;
        gol.SetAliveByAxes(currentIndex++, xAxis, 1, yAxis, 0, zAxis, 1);
        gol.SetAliveByAxes(currentIndex++, xAxis, 1, yAxis, 0, zAxis, 2);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 0, zAxis, 1);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 0, zAxis, 2);
        gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 2, zAxis, 3);
        gol.SetAliveByAxes(currentIndex++, xAxis, 3, yAxis, 2, zAxis, 2);
    }

    public static void Bays5766InfiniGlider(this GameOfLife gol, int xAxis = 0, int yAxis = 1, int zAxis = 2)
    {
        gol.Bays5766Rules();
        int iterations = 4;
        gol.SetDimensions(xAxis, -17, yAxis, 6, zAxis, iterations * -6);
        
        gol.Clear();

        int currentIndex = 0;
        for (int i = 0; i < iterations; ++i)
        {
            gol.SetAliveByAxes(currentIndex++, xAxis, 0, yAxis, 2, zAxis, 3 + (i * 6));
            gol.SetAliveByAxes(currentIndex++, xAxis, 0, yAxis, 3, zAxis, 2 + (i * 6));
            gol.SetAliveByAxes(currentIndex++, xAxis, 0, yAxis, 3, zAxis, 4 + (i * 6));
            gol.SetAliveByAxes(currentIndex++, xAxis, 1, yAxis, 1, zAxis, 1 + (i * 6));
            gol.SetAliveByAxes(currentIndex++, xAxis, 1, yAxis, 1, zAxis, 2 + (i * 6));
            gol.SetAliveByAxes(currentIndex++, xAxis, 1, yAxis, 1, zAxis, 4 + (i * 6));
            gol.SetAliveByAxes(currentIndex++, xAxis, 1, yAxis, 1, zAxis, 5 + (i * 6));
            gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 1, zAxis, 3 + (i * 6));
            gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 2, zAxis, 0 + (i * 6));
            gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 2, zAxis, 1 + (i * 6));
            gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 2, zAxis, 5 + (i * 6));
            gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 3, zAxis, 0 + (i * 6));
            gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 3, zAxis, 1 + (i * 6));
            gol.SetAliveByAxes(currentIndex++, xAxis, 2, yAxis, 3, zAxis, 5 + (i * 6));
            for (int j = 0; j < 2; ++j)
            {
                for (int k = 0; k < 6; ++k)
                {
                    gol.SetAliveByAxes(currentIndex++, xAxis, 3, yAxis, 2 + j, zAxis, k + (i * 6));
                }
            }
        }
    }

    public static void Acorn3D(this GameOfLife gol, int xAxis = 0, int yAxis = 1, int zAxis = 2)
    {
        gol.Bays5766Rules();
        gol.SetDimensions(xAxis, 174, yAxis, 222, zAxis, 2);

        gol.Clear();

        int currentIndex = 0;
        gol.SetAliveByAxes(currentIndex++, xAxis, 118, yAxis, 89, zAxis, 0);
        gol.SetAliveByAxes(currentIndex++, xAxis, 119, yAxis, 89, zAxis, 0);
        gol.SetAliveByAxes(currentIndex++, xAxis, 122, yAxis, 89, zAxis, 0);
        gol.SetAliveByAxes(currentIndex++, xAxis, 123, yAxis, 89, zAxis, 0);
        gol.SetAliveByAxes(currentIndex++, xAxis, 124, yAxis, 89, zAxis, 0);
        gol.SetAliveByAxes(currentIndex++, xAxis, 119, yAxis, 91, zAxis, 0);
        gol.SetAliveByAxes(currentIndex++, xAxis, 121, yAxis, 90, zAxis, 0);

        gol.SetAliveByAxes(currentIndex++, xAxis, 118, yAxis, 89, zAxis, 1);
        gol.SetAliveByAxes(currentIndex++, xAxis, 119, yAxis, 89, zAxis, 1);
        gol.SetAliveByAxes(currentIndex++, xAxis, 122, yAxis, 89, zAxis, 1);
        gol.SetAliveByAxes(currentIndex++, xAxis, 123, yAxis, 89, zAxis, 1);
        gol.SetAliveByAxes(currentIndex++, xAxis, 124, yAxis, 89, zAxis, 1);
        gol.SetAliveByAxes(currentIndex++, xAxis, 119, yAxis, 91, zAxis, 1);
        gol.SetAliveByAxes(currentIndex++, xAxis, 121, yAxis, 90, zAxis, 1);
    }

    private static void SetDimensions(this GameOfLife gol, int xAxis, int xSize, int yAxis = -1, int ySize = 1, int zAxis = -1, int zSize = 1, int wAxis = -1, int wSize = 1)
    {
        int width = 1;
        int height = 1;
        int depth = 1;
        int colors = 1;

        switch (xAxis)
        {
            case 0: {
                width = xSize;
                break;
            }
            case 1: {
                height = xSize;
                break;
            }
            case 2: {
                depth = xSize;
                break;
            }
            case 3: {
                colors = xSize;
                break;
            }
        }
        switch (yAxis)
        {
            case 0: {
                width = ySize;
                break;
            }
            case 1: {
                height = ySize;
                break;
            }
            case 2: {
                depth = ySize;
                break;
            }
            case 3: {
                colors = ySize;
                break;
            }
        }
        switch (zAxis)
        {
            case 0: {
                width = zSize;
                break;
            }
            case 1: {
                height = zSize;
                break;
            }
            case 2: {
                depth = zSize;
                break;
            }
            case 3: {
                colors = zSize;
                break;
            }
        }
        switch (wAxis)
        {
            case 0: {
                width = wSize;
                break;
            }
            case 1: {
                height = wSize;
                break;
            }
            case 2: {
                depth = wSize;
                break;
            }
            case 3: {
                colors = wSize;
                break;
            }
        }

        gol.Resize(new GameOfLife.Vector4i(width, height, depth, colors));
    }

    private static void SetAliveByAxes(this GameOfLife gol, int index, int xAxis, int x, int yAxis = -1, int y = 0, int zAxis = -1, int z = 0, int wAxis = -1, int w = 0)
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
        gol.SetState(indices[0], indices[1], indices[2], indices[3], true);
        gol.liveCells[index].x = indices[0];
        gol.liveCells[index].y = indices[1];
        gol.liveCells[index].z = indices[2];
        gol.liveCells[index].w = indices[3];
        //gol.deadCells = null;
    }

}
