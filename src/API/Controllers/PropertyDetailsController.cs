using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using src.Domain.Interface;
using src.Domain.Request;

namespace src.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertyDetailsController : Controller
    {
        private readonly IHttpServices _httpServices;

        public PropertyDetailsController(IHttpServices httpServices)
        {
            _httpServices = httpServices;
        }

        /**
            sample request:
            {
                "Type": "koop",
                "Zo": "/amsterdam/tuin"
            }
        **/
        [HttpGet("GetAllPropertyData")]
        public async Task<IActionResult> GetAllPropertyData([FromQuery] RequestParams requestParams)
        {
            var resp = await _httpServices.GetAllPropertyData(requestParams.Type!, requestParams.Zo!);
            if(resp == null)
            {
                return NotFound(new { message = "No available property"});
            }
            return Ok(resp);
        }

        [HttpGet("GetAgentsRankedByMostProperties")]
        public async Task<IActionResult> GetAgentsRankedByMostProperties()
        {
            var resp = await _httpServices.GetAgentsRankedByMostProperties();
            if(resp == null)
            {
                return NotFound(new { message = "No available property"});
            }
            return Ok(resp);
        }

        [HttpGet("GetAgentsRankedByMostPropertiesAndGarden")]
        public async Task<IActionResult> GetAgentsRankedByMostPropertiesAndGarden()
        {
            var resp = await _httpServices.GetAgentsRankedByMostPropertiesAndGarden();
            if(resp == null)
            {
                return NotFound(new { message = "No available property"});
            }
            return Ok(resp);
        }
    }
}