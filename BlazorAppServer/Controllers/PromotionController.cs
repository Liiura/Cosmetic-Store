using BlazorAppServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAppServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PromotionController : Controller
    {
        private readonly IPromotionRepository _promotionRepository;
        public PromotionController(IPromotionRepository productRepository)
        {
            _promotionRepository = productRepository;
        }
        [HttpGet]
        [Route("GetAllPromotions")]
        public async Task<IActionResult> GetAllPromotions()
        {
            var payload = await _promotionRepository.GetAllPromotions();
            return Ok(payload);
        }
    }
}
