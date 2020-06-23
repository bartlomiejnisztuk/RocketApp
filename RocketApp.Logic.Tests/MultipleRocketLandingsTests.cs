using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using RocketApp.Data;
using RocketApp.Data.Models;

namespace RocketApp.Logic.Tests
{
    [TestFixture]
    public class MultipleRocketLandingsTests
    {
        private IRocketLandingService _sut;

        private const int LandingAreaWidth = 100;
        private const int LandingAreaHeight = 100;
        private const int LandingPlatformHeight = 10;
        private const int LandingPlatformWidth = 10;
        private const int LandingPlatformTopLeftX = 5;
        private const int LandingPlatformTopLeftY = 5;

        [OneTimeSetUp]
        public void Setup()
        {
            _sut = new RocketLandingService();

            _sut.SetupLandingArea(new LandingArea(new List<LandingPlatform>()
            {
                new LandingPlatform(new Square(LandingPlatformHeight, LandingPlatformWidth, new Position(LandingPlatformTopLeftX, LandingPlatformTopLeftY)))
            }, LandingAreaHeight, LandingAreaWidth));
        }

        [Test]
        [TestCaseSource(typeof(RocketLandingData), nameof(RocketLandingData.ClashTestCases))]
        [TestCaseSource(typeof(RocketLandingData), nameof(RocketLandingData.OkForLandingTestCases))]
        [TestCaseSource(typeof(RocketLandingData), nameof(RocketLandingData.OutOfPlatformTestCases))]
        public string CanLandShouldReturnClash(
            int x,
            int y)
        {
            return _sut.CanLand(x, y);
        }

        private class RocketLandingData
        {
            public static IEnumerable ClashTestCases
            {
                get
                {
                    yield return new TestCaseData(10, 10).Returns(RocketLandingResponseConsts.OkForLanding);
                    yield return new TestCaseData(9, 9).Returns(RocketLandingResponseConsts.Clash);
                    yield return new TestCaseData(9, 10).Returns(RocketLandingResponseConsts.Clash);
                    yield return new TestCaseData(9, 11).Returns(RocketLandingResponseConsts.Clash);
                    yield return new TestCaseData(10, 9).Returns(RocketLandingResponseConsts.Clash);
                    yield return new TestCaseData(10, 10).Returns(RocketLandingResponseConsts.Clash);
                    yield return new TestCaseData(10, 11).Returns(RocketLandingResponseConsts.Clash);
                    yield return new TestCaseData(11, 9).Returns(RocketLandingResponseConsts.Clash);
                    yield return new TestCaseData(11, 10).Returns(RocketLandingResponseConsts.Clash);
                    yield return new TestCaseData(11, 11).Returns(RocketLandingResponseConsts.Clash);
                }
            }
            public static IEnumerable OutOfPlatformTestCases
            {
                get
                {
                    for (var x = 1; x <= LandingAreaWidth; x++)
                    {
                        for (var y = 1; y <= 100; y++)
                        {
                            if ((x < 5 || x > 15) && (y < 5 || y > 15))
                            {
                                yield return new TestCaseData(x, y).Returns(RocketLandingResponseConsts.OutOfPlatform);
                            }
                        }
                    }
                }
            }

            public static IEnumerable OkForLandingTestCases
            {
                get
                {
                    yield return new TestCaseData(5, 5).Returns(RocketLandingResponseConsts.OkForLanding);
                    yield return new TestCaseData(5, 8).Returns(RocketLandingResponseConsts.OkForLanding);
                    yield return new TestCaseData(8, 5).Returns(RocketLandingResponseConsts.OkForLanding);
                    yield return new TestCaseData(11, 8).Returns(RocketLandingResponseConsts.OkForLanding);
                    yield return new TestCaseData(8, 11).Returns(RocketLandingResponseConsts.OkForLanding);
                    yield return new TestCaseData(14, 11).Returns(RocketLandingResponseConsts.OkForLanding);
                    yield return new TestCaseData(11, 14).Returns(RocketLandingResponseConsts.OkForLanding);
                }
            }
        }
    }
}
