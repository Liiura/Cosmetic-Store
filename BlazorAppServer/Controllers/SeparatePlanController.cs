using BlazorAppServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAppServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeparatePlanController : Controller
    {
        private readonly ISeparatePlanRepository _separatePlanRepository;
        public SeparatePlanController(ISeparatePlanRepository separatePlanRepository)
        {
            _separatePlanRepository = separatePlanRepository;
        }
        [HttpGet]
        [Route("GetAllSeparatePlans")]
        public async Task<IActionResult> GetAllSeparatePlans()
        {
            var response = await _separatePlanRepository.GetAllSeparatePlans();
            return Ok(response);
        }
    }
}
