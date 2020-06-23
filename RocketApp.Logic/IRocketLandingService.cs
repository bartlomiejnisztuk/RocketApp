using RocketApp.Data.Models;

namespace RocketApp.Logic
{
    public interface IRocketLandingService
    {
        string CanLand(int x, int y);
        void SetupLandingArea(LandingArea landingArea);
    }
}