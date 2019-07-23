using Microsoft.AspNetCore.Mvc;
using TalkingClock.Service;

namespace TalkingClockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalkingClockController : ControllerBase
    {
        private readonly ITalkingClockService _talkingClockService;

        public TalkingClockController(ITalkingClockService talkingClockService)
        {
            this._talkingClockService = talkingClockService;
        }

        [HttpGet("{message}")]
        public ActionResult<string> Get(string message)
        {
            return _talkingClockService.Translate(message);
        }
    }
}
