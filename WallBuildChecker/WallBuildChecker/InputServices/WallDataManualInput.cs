using System;
 using System.Collections.Generic;
 using WallBuildChecker.Interfaces;
 
 namespace WallBuildChecker.InputServices
 {
     public class WallDataManualInput : IWallDataInput
     {
         public List<BrickSort> GetBricks()
         {
             Console.WriteLine("Please enter quantity of brick sort.");
             int.TryParse(Console.ReadLine(), out int bricksCount);

             while (bricksCount == 0)
             {
                 Console.WriteLine("The value should be the type of integer.");
                 int.TryParse(Console.ReadLine(), out bricksCount);
             }

             var brickSorts = new List<BrickSort>();
             
             for (int i = 0; i < bricksCount; i++)
             {
                 Console.WriteLine("Please enter height of brick sort.");
                 int.TryParse(Console.ReadLine(), out int brickHeight);

                 while (brickHeight == 0)
                 {
                     Console.WriteLine("The value should be the type of integer.");
                     int.TryParse(Console.ReadLine(), out brickHeight);
                 }
                 
                 Console.WriteLine("Please enter width of brick sort.");
                 int.TryParse(Console.ReadLine(), out int brickWidth);

                 while (brickWidth == 0)
                 {
                     Console.WriteLine("The value should be the type of integer.");
                     int.TryParse(Console.ReadLine(), out brickWidth);
                 }
                 
                 Console.WriteLine("Please enter count of brick sort.");
                 int.TryParse(Console.ReadLine(), out int brickCount);

                 while (brickCount == 0)
                 {
                     Console.WriteLine("The value should be the type of integer.");
                     int.TryParse(Console.ReadLine(), out brickCount);
                 }
                 
                 brickSorts.Add(new BrickSort(brickWidth, brickHeight, brickCount));
             }

             return brickSorts;
         }
 
         public WallPattern GetWallPattern()
         {
             Console.WriteLine("Please enter quantity of wall pattern rows:");
             int.TryParse(Console.ReadLine(), out int height);
 
             while (height == 0)
             {
                 Console.WriteLine("The value should be the type of integer.");
                 int.TryParse(Console.ReadLine(), out height);
             }
             
             Console.WriteLine("Please enter quantity of wall pattern columns:");
             int.TryParse(Console.ReadLine(), out int width);
 
             while (width == 0)
             {
                 Console.WriteLine("The value should be the type of integer.");
                 int.TryParse(Console.ReadLine(), out width);
             }
 
             var wallPattern = new int[height, width];
 
             for (int i = 0; i < height; i++)
             {
                 for (int j = 0; j < width; j++)
                 {
                     Console.WriteLine($"Please enter element of wall pattern #{i + 1},{j + 1}:");
                     int.TryParse(Console.ReadLine(), out int arrayItem);
                     
                     wallPattern[i, j] = arrayItem;
                 }
             }
             
             return new WallPattern(wallPattern);
         }
     }
 }