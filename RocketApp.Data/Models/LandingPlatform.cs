using System.Collections.Generic;

namespace RocketApp.Data.Models
{
    public class LandingPlatform
    {
        public LandingPlatform(Square square)
        {
            Square = square;
            TakenPositions = new List<RocketPosition>();
        }

        public Square Square { get; }

        public IList<RocketPosition> TakenPositions { get; set; }
    }
}