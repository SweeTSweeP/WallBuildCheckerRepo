using System.Runtime.CompilerServices;

namespace WallBuildChecker
{
    public class WallPattern
    {
        public WallPart[,] Pattern { get; private set; }

        public WallPattern(int[,] pattern)
        {
            int width = pattern.GetLength(0);
            int height = pattern.GetLength(1);

            this.Pattern = new WallPart[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (pattern[i, j] <= 0)
                    {
                        this.Pattern[i, j] = WallPart.None;
                    }
                    else
                    {
                        this.Pattern[i, j] = WallPart.Fill;
                    }
                }
            }
        }
    }
}