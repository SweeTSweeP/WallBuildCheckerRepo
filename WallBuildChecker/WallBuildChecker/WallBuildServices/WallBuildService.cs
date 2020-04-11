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
            }

            return false;
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
            
            for (int i = 0; i < brickSort.Height; i++)
            {
                for (int j = 0; j < brickSort.Width; j++)
                {
                    if (indJ + 1 > brickSort.Width && j < brickSort.Width - 1)
                    {
                        return null;
                    }

                    if (wallPattern.Pattern[indI, indexJ] == WallPart.Fill)
                    {
                        shapeIndexes.Add((indI, indJ));
                        indJ++;
                    }
                    else
                    {
                        return null;
                    }
                }

                if (indI + 1 > brickSort.Height && i < brickSort.Height - 1)
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
            
            for (int j = 0; j < brickSort.Height; j++)
            {
                for (int i = 0; i < brickSort.Width; i++)
                {
                    if (indJ + 1 > brickSort.Width && i < brickSort.Width - 1)
                    {
                        return null;
                    }

                    if (wallPattern.Pattern[indI, indexJ] == WallPart.Fill)
                    {
                        shapeIndexes.Add((indJ, indI));
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
    }
}