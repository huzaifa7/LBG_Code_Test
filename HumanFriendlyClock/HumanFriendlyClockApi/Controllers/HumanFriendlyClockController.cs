using HumanFriendlyClock.Service;
using Microsoft.AspNetCore.Mvc;

namespace HumanFriendlyClockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanFriendlyClockController : ControllerBase
    {
        private readonly IHumanFriendlyClockService _humanFriendlyClockService;

        public HumanFriendlyClockController(IHumanFriendlyClockService humanFriendlyClockService)
        {
            this._humanFriendlyClockService = humanFriendlyClockService;
        }

        [HttpGet("{message}")]
        public ActionResult<string> Get(string message)
        {
            var friendlyClockMessage = _humanFriendlyClockService.Translate(message);
            return friendlyClockMessage;
        }
    }
}
