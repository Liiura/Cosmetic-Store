using BlazorAppServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAppServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColorController : Controller
    {
        private readonly IColorRepository _colorRepository;
        public ColorController(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }
        [HttpGet]
        [Route("GetAllColors")]
        public IActionResult GetAllColors()
        {
            var payload =  _colorRepository.GetAllColorsWithStoreProcedure();
            return Ok(payload);
        }
    }
}
