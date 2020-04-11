using System.Runtime.CompilerServices;

namespace WallBuildChecker
{
    public class WallPattern
    {
        public int[,] Pattern { get; private set; }

        public WallPattern(int[,] pattern)
        {
            int width = pattern.GetLength(0);
            int height = pattern.GetLength(1);
            
            this.Pattern = new int[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    this.Pattern[i, j] = pattern[i, j];
                }
            }
        }
    }
}