using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{

    public class HackerAPIController : Controller
    {
        private readonly IHackerAPIServices _HackerAPIService;

        public HackerAPIController(IHackerAPIServices hackerAPIService)
        {
            this._HackerAPIService = hackerAPIService;
        }

        [HttpGet,Route("api/HackerAPI/GetTopTwenty")]
        public async Task<IActionResult> GetTopTwenty()
        {
            var result = await _HackerAPIService.GetTopTwentyResults();
            if (result == null)
                return BadRequest();

            return Ok(result);
        }

    
    }
}
