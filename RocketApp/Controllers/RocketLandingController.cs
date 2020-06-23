using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RocketApp.Logic;
using RocketApp.Mappers;

namespace RocketApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RocketLandingController : Controller
    {
        private readonly IRocketLandingService _rocketLandingService;

        public RocketLandingController(IRocketLandingService rocketLandingService, IConfiguration configuration)
        {
            _rocketLandingService = rocketLandingService;

            var settings = new LandingAreaSettings();
            configuration.GetSection("LandingAreaSettings").Bind(settings);
            rocketLandingService.SetupLandingArea(settings.ToLandingArea());
        }

        [HttpGet("canland/{x}/{y}")]
        public ActionResult CanLand(int x, int y)
        {
            var canLandResponse = _rocketLandingService.CanLand(x, y); 
            return Ok(canLandResponse);
        }
    }
}
