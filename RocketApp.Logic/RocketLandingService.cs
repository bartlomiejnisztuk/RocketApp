using System.Linq;
using RocketApp.Data;
using RocketApp.Data.Models;

namespace RocketApp.Logic
{
    public class RocketLandingService : IRocketLandingService
    {
        private LandingArea _landingArea;

        public void SetupLandingArea(LandingArea landingArea)
        {
            if (_landingArea == null)
            {
                _landingArea = landingArea;
            }
        }

        public string CanLand(int axisX, int axisY)
        {
            var askedPosition = new Position(axisX, axisY);
            var landingPlatform = _landingArea.LandingPlatforms.FirstOrDefault(x =>
                CheckIfPositionInsideSquare(askedPosition, x.Square));

            if (landingPlatform == null)
            {
                return RocketAppConsts.OutOfPlatform;
            }

            var rocketsOnPlatform = landingPlatform.TakenPositions;

            var isClashWithOtherRocket = rocketsOnPlatform.Any(rocketPosition => CheckIfPositionInsideSquare(
                askedPosition,
                rocketPosition.ClashSquare));

            if (!isClashWithOtherRocket)
            {
                SetPositionTaken(askedPosition, landingPlatform);

                return RocketAppConsts.OkForLanding;
            }

            return RocketAppConsts.Clash;
        }

        private void SetPositionTaken(Position position, LandingPlatform platform)
        {
            platform.TakenPositions.Add(new RocketPosition(position));
        }

        private bool CheckIfPositionInsideSquare(Position position, Square square)
        {

            var inAreaHorizontally = position.AxisX >= square.TopLeftCorner.AxisX &&
                                     position.AxisX <= square.TopLeftCorner.AxisX + square.Width;
            var inAreaVertically = position.AxisY >= square.TopLeftCorner.AxisY &&
                                   position.AxisY <= square.TopLeftCorner.AxisY + square.Height;

            return inAreaHorizontally && inAreaVertically;
        }
    }
}
