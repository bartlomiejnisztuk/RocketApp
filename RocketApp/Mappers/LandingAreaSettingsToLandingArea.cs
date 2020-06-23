using System.Collections.Generic;
using RocketApp.Data.Models;

namespace RocketApp.Mappers
{
    public static class LandingAreaSettingsToLandingArea
    {
        public static LandingArea ToLandingArea(this LandingAreaSettings settings)
        {
            var platforms = new List<LandingPlatform>();

            foreach (var landingPlatformSettings in settings.LandingPlatforms)
            {
                platforms.Add(new LandingPlatform(new Square(landingPlatformSettings.Height,
                    landingPlatformSettings.Width,
                    new Position(landingPlatformSettings.TopLeftCorner.AxisX,
                        landingPlatformSettings.TopLeftCorner.AxisY))));
            }

            return new LandingArea(platforms, settings.Height, settings.Width);
        }
    }
}