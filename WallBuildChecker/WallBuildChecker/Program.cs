using System;
using System.Collections.Generic;
using WallBuildChecker.InputServices;
using WallBuildChecker.Interfaces;
using WallBuildChecker.WallBuildServices;

namespace WallBuildChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 - Manually input data, 2 - Input data from file.");
            int.TryParse(Console.ReadLine(), out int option);

            while (option != 1 && option != 2)
            {
                Console.WriteLine("Value should be 1 or 2.");
                int.TryParse(Console.ReadLine(), out option);
            }

            IWallDataInput dataInput = null;
            WallPattern wallPattern = null;
            List<BrickSort> bricks = null;

            if (option == 1)
            {
                dataInput = new WallDataManualInput();

                wallPattern = dataInput.GetWallPattern();
                bricks = dataInput.GetBricks();
            }

            if (option == 2)
            {
                Console.WriteLine("Please enter name of file which contain data about wall and about brick sorts " +
                                  "if it is located in root folder otherwise please enter whole path to file " +
                                  "which directory starts with disk name.");

                dataInput = new WallDataFileInput(Console.ReadLine() + ".txt");

                wallPattern = dataInput.GetWallPattern();
                bricks = dataInput.GetBricks();
            }
            
            
            
            var wallBuildService = new WallBuildService();

            var wallStatus = wallBuildService.TryToBuildWall(wallPattern, bricks);

            Console.WriteLine(wallStatus ? "The wall was built." : "The wall cannot be built.");
        }
    }
}