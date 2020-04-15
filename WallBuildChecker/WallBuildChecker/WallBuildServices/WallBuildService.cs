using System.Collections.Generic;

namespace WallBuildChecker.WallBuildServices
{

    public class WallBuildService
    {
        public bool TryToBuildWall(WallPattern wallPattern, List<BrickSort> brickSorts)
        {
            foreach (var brickSort in brickSorts)
            {
                var indexes = GetIndexesToPutShape(wallPattern, brickSort);
                PutShape(indexes, wallPattern);
            }

            return IsItFilled(wallPattern);
        }

        private List<(int, int)> GetIndexesToPutShape(WallPattern wallPattern, BrickSort brickSort)
        {
            var shapeIndexes = new List<(int, int)>();

            var height = wallPattern.Pattern.GetLength(0);
            var width = wallPattern.Pattern.GetLength(1);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (wallPattern.Pattern[i, j] == WallPart.Fill)
                    {
                        shapeIndexes = 
                            TryToPutShapeHorizontallyFromCurrentIndex(wallPattern, brickSort, i, j);

                        if (shapeIndexes == null)
                        {
                            shapeIndexes = 
                                TryToPutShapeVerticallyFromCurrentIndex(wallPattern, brickSort, i, j);

                            if (shapeIndexes != null)
                            {
                                return shapeIndexes;
                            }
                        }
                        else
                        {
                            return shapeIndexes;
                        }
                    }
                }
            }

            if (shapeIndexes == null)
            {
                return new List<(int, int)>();
            }

            return shapeIndexes;
        }

        private List<(int, int)> TryToPutShapeHorizontallyFromCurrentIndex(
            WallPattern wallPattern,
            BrickSort brickSort,
            int indexI,
            int indexJ)
        {
            var shapeIndexes = new List<(int, int)>();

            int indI = indexI;
            int indJ = indexJ;

            int height = 0;
            int width = 0;

            if (brickSort.Height > brickSort.Width)
            {
                height = brickSort.Width;
                width = brickSort.Height;
            }
            else
            {
                height = brickSort.Height;
                width = brickSort.Width;
            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (indJ + 1 > wallPattern.Pattern.GetLength(1) && j <= width - 1)
                    {
                        return null;
                    }

                    if (wallPattern.Pattern[indI, indJ] == WallPart.Fill)
                    {
                        shapeIndexes.Add((indI, indJ));
                        indJ++;
                    }
                    else
                    {
                        return null;
                    }
                }

                if (indI + 1 >= wallPattern.Pattern.GetLength(0) && i <= height - 1)
                {
                    return null;
                }
                
                indI++;
                indJ = indexJ;
            }

            return shapeIndexes;
        }
        
        private List<(int, int)> TryToPutShapeVerticallyFromCurrentIndex(
            WallPattern wallPattern,
            BrickSort brickSort,
            int indexI,
            int indexJ)
        {
            var shapeIndexes = new List<(int, int)>();

            int indI = indexI;
            int indJ = indexJ;

            int height = 0;
            int width = 0;

            if (brickSort.Width > brickSort.Height)
            {
                height = brickSort.Width;
                width = brickSort.Height;
            }
            else
            {
                height = brickSort.Height;
                width = brickSort.Width;
            }

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    if (indJ + 1 > brickSort.Width && i < brickSort.Width - 1)
                    {
                        return null;
                    }

                    if (wallPattern.Pattern[indI, indJ] == WallPart.Fill)
                    {
                        shapeIndexes.Add((indI, indJ));
                        indJ++;
                    }
                    else
                    {
                        return null;
                    }
                }

                if (indI + 1 > brickSort.Height && j < brickSort.Height - 1)
                {
                    return null;
                }
                
                indI++;
                indJ = indexJ;
            }

            return shapeIndexes;
        }

        private void PutShape(List<(int, int)> indexes, WallPattern wallPattern)
        {
            foreach (var index in indexes)
            {
                wallPattern.Pattern[index.Item1, index.Item2] = WallPart.Filled;
            }
        }

        private bool IsItFilled(WallPattern wallPattern)
        {
            for (int i = 0; i < wallPattern.Pattern.GetLength(0); i++)
            {
                for (int j = 0; j < wallPattern.Pattern.GetLength(1); j++)
                {
                    if (wallPattern.Pattern[i, j] == WallPart.Fill)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}