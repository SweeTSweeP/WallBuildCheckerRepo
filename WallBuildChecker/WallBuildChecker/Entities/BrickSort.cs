namespace WallBuildChecker
{
    public class BrickSort
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Quantity { get; set; }

        public BrickSort(int width, int height, int quantity)
        {
            this.Width = width;
            this.Height = height;
            this.Quantity = quantity;
        }
    }
}