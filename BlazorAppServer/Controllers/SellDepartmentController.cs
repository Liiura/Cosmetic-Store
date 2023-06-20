using BlazorAppServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAppServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SellDepartmentController : Controller
    {
        private readonly ISellDepartmentRepository _sellDepartmentRepository;
        public SellDepartmentController(ISellDepartmentRepository sellDepartmentRepository)
        {
            _sellDepartmentRepository = sellDepartmentRepository;
        }
        [HttpGet]
        [Route("GetAllSellDepartments")]
        public async Task<IActionResult> GetAllSellDepartments()
        {
            var payload = await _sellDepartmentRepository.GetSellDepartments();
            return Ok(payload);
        }
    }
}
