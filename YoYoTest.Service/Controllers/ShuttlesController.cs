using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YoYoTest.Service.Service;

namespace YoYoTest.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShuttlesController : ControllerBase
    {
        private readonly IShuttleService _shuttleService;
        public ShuttlesController(IShuttleService shuttleService)
        {
            _shuttleService = shuttleService;
        }

        [HttpGet]
        [Route("level/{level}")]
        public async Task<IActionResult> CheckUnregisteredAccounts([FromRoute]int level)
        {
            var shuttles = await _shuttleService.GetShuttlesFor(level);
            return Ok(shuttles);
        }
    }
}
