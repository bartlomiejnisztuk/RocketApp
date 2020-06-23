using System.Collections.Generic;
using NUnit.Framework;
using RocketApp.Data;
using RocketApp.Data.Models;

namespace RocketApp.Logic.Tests
{
    [TestFixture]
    public class RocketLandingServiceTests
    {
        private IRocketLandingService _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new RocketLandingService();
            _sut.SetupLandingArea(new LandingArea(new List<LandingPlatform>()
            {
                new LandingPlatform(new Square(10, 10, new Position(5, 5)))
            }, 100, 100));
        }

        [Test]
        public void CanLandShouldReturnOkForLanding(
            [Range(5, 15)]
            int x,
            [Range(5, 15)]
            int y)
        {
            var result = _sut.CanLand(x, y);

            Assert.AreEqual(RocketAppConsts.OkForLanding, result);
        }

        [Test]
        public void CanLandShouldReturnOutOfPlatform(
            [Range(1, 4)]
            [Range(15, 100)]
            int x,
            [Range(1, 4)]
            [Range(15, 100)]
            int y)
        {
            var result = _sut.CanLand(x, y);

            Assert.AreEqual(RocketAppConsts.OutOfPlatform, result);
        }
    }
}