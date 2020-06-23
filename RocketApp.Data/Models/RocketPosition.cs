using RocketApp.Logic;

namespace RocketApp.Data.Models
{
    public class RocketPosition
    {
        public RocketPosition(Position position)
        {
            Position = position;
        }

        public Position Position { get; }

        public Square ClashSquare =>
            new Square(RocketAppConsts.ClashAreaDimension, RocketAppConsts.ClashAreaDimension,
                new Position(Position.AxisX - RocketAppConsts.OnePositionStep,
                    Position.AxisY - RocketAppConsts.OnePositionStep));
    }
}