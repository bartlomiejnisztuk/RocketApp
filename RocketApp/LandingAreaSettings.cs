using System.Collections.Generic;

namespace RocketApp
{
    public class LandingAreaSettings
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public List<LandingPlatformSettings> LandingPlatforms { get; set; }
    }

    public class LandingPlatformSettings
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public TopLeftCorner TopLeftCorner { get; set; }

    }

    public class TopLeftCorner
    {
        public int AxisX { get; set; }
        public int AxisY { get; set; }
    }
}
