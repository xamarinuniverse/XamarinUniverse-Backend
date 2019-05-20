using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XamarinUniverse_Backend.Services;

namespace XamarinUniverse_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetXamarinController : ControllerBase
    {
        private readonly IPlanetXamarinService _planetXamarinService;

        public PlanetXamarinController(IPlanetXamarinService planetXamarinService)
        {
            _planetXamarinService = planetXamarinService;
        }
        // GET: api/PlanetXamarin
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string category)
        {
            var result = string.IsNullOrEmpty(category) ? _planetXamarinService.GetAllFeeds()
                : _planetXamarinService.GetFeedsByCategory(category);
            return Ok(await result);            
        }
        [HttpGet("{order}")]
        public async Task<IActionResult> Get(int order, [FromQuery] string category)
        {
            var result = string.IsNullOrEmpty(category) ? _planetXamarinService.GetFeedsByOrder(order)
                : _planetXamarinService.GetFeedsByCategoryOrder(order, category);
            
            if ((await result)!=null)
            {
                return Ok(await result);
            }
            return NotFound();
        }
    }
}
