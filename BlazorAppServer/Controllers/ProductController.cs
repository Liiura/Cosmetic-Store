using BlazorAppServer.Interfaces;
using BlazorAppShared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAppServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateUpdateProductDTO productDTO) {
            if(ModelState.IsValid)
            {
                var payload = await _productRepository.CreateProduct(productDTO);
                return StatusCode(payload.Status.Value, payload);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpDelete]
        [Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var payload = await _productRepository.DeleteProduct(productId);
            return StatusCode(payload.Status.Value, payload);
        }
        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(CreateUpdateProductDTO productDTO, int productId)
        {
            if (ModelState.IsValid)
            {
                var payload = await _productRepository.UpdateProduct(productDTO,productId);
                return StatusCode(payload.Status.Value, payload);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpGet]
        [Route("GetProductById")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var payload = await _productRepository.GetProductById(productId);
            return StatusCode(payload.Status.Value, payload);
        }
        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var payload = await _productRepository.GetAllProducts();
            return Ok(payload);
        }
    }
}
