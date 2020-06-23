namespace RocketApp.Data.Models
{
    public class Position
    {
        public Position(int axisX, int axisY)
        {
            AxisY = axisY;
            AxisX = axisX;
        }

        public int AxisX { get; }

        public int AxisY { get; }
    }
}