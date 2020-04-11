using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WallBuildChecker.Interfaces;

namespace WallBuildChecker.InputServices
{
    public class WallDataFileInput : IWallDataInput
    {
        private string FilePath;
        
        public WallDataFileInput(string filePath)
        {
            this.FilePath = filePath;
        }

        public List<BrickSort> GetBricks()
        {
            var file = TryOpenFile(FilePath);

            if (file == null)
            {
                return null;
            }

            var lines = GetFileLines(file);
            
            int.TryParse(lines[0].Split(" ")[1], out int linesToSkip);
            linesToSkip++;
            int.TryParse(lines[linesToSkip], out int brickSortQuantity);
            linesToSkip++;
            
            var brickSorts = new List<BrickSort>();
            
            foreach (var s in lines.Skip(linesToSkip))
            {
                var brickSortProperties = s.Split(" ");
                int.TryParse(brickSortProperties[0], out int height);
                int.TryParse(brickSortProperties[1], out int width);
                int.TryParse(brickSortProperties[2], out int quantity);
                
                brickSorts.Add(new BrickSort(width, height, quantity));
            }

            return brickSorts;
        }

        public WallPattern GetWallPattern()
        {
            var file = TryOpenFile(FilePath);
            
            if (file == null)
            {
                return null;
            }
            
            var lines = GetFileLines(file);

            var arraySize = lines[0].Split(" ");

            int.TryParse(arraySize[0], out int width);
            int.TryParse(arraySize[1], out int height);

            var wallPattern = new int[height, width];

            var wall = lines.Skip(1).Take(width);

            var i = 0;
            foreach (var s in lines.Skip(1).Take(height))
            {
                for (int j = 0; j < width; j++)
                {
                    int.TryParse(s[j].ToString(), out int arrayElement);
                    wallPattern[i, j] = arrayElement;
                }

                i++;
            }

            return new WallPattern(wallPattern);
        }
        
        private StreamReader TryOpenFile(string filePath)
        {
            try
            {
                return new StreamReader(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: File was not found.");
                return null;
            }
        }

        private List<string> GetFileLines(StreamReader file)
        {
            var lines = new List<string>();

            while (!file.EndOfStream)
            {
                lines.Add(file.ReadLine());
            }

            return lines;
        }
    }
}