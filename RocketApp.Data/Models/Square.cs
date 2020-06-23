namespace RocketApp.Data.Models
{
    public class Square
    {
        public Square(int height, int width, Position topLeftCorner)
        {
            Height = height;
            Width = width;
            TopLeftCorner = topLeftCorner;
        }

        public Position TopLeftCorner { get; }

        public int Width { get; }

        public int Height { get; }
    }
}