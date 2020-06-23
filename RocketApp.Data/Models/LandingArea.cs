using System.Collections.Generic;

namespace RocketApp.Data.Models
{
    public class LandingArea
    {
        public LandingArea(IEnumerable<LandingPlatform> landingPlatforms, int height, int width)
        {
            LandingPlatforms = landingPlatforms;
            Height = height;
            Width = width;
        }

        public int Width { get; }
        public int Height { get; }
        public IEnumerable<LandingPlatform> LandingPlatforms { get; }
    }
}
