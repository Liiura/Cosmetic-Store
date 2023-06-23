using BlazorAppServer.Interfaces;
using BlazorAppShared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAppServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;
        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        [HttpPost]
        [Route("CreateClient")]
        public async Task<IActionResult> CreateClient(CreateEditClientDTO clientDTO)
        {
            if (ModelState.IsValid)
            {
                var payload = await _clientRepository.CreateClient(clientDTO);
                return StatusCode(payload.Status.Value, payload);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPost]
        [Route("SeparateProducts")]
        public async Task<IActionResult> SeparateProducts(List<CreateEditClientSeparationProductDetailDTO> clientSeparationProductDetailDTOs, int clientId,int? promotionId)
        {
            if (ModelState.IsValid)
            {
                var payload = await _clientRepository.SeparateProducts(clientSeparationProductDetailDTOs,clientId, promotionId);
                return StatusCode(payload.Status.Value, payload);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPost]
        [Route("PurchaseProduct")]
        public async Task<IActionResult> PurchaseProduct(List<CreateEditClientProductPurchaseDetailDTO> clientProductPurchaseDetailDTOs, int clientId, int? separatePlanId) {

            if (ModelState.IsValid)
            {
                var payload = await _clientRepository.PurchaseProduct(clientProductPurchaseDetailDTOs, clientId,separatePlanId);
                return StatusCode(payload.Status.Value, payload);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpGet]
        [Route("GetClient")]
        public async Task<IActionResult> GetClient(string clientName)
        {
            var payload = await _clientRepository.GetClient(clientName);
            return StatusCode(payload.Status.Value, payload);
        }
        [HttpGet]
        [Route("GetClientPurchaseProducts")]
        public async Task<IActionResult> GetClientPurchaseProducts(int purchaseId)
        {
            var payload = await _clientRepository.GetClientPurchaseProducts(purchaseId);
            return StatusCode(payload.Status.Value, payload);
        }
        [HttpGet]
        [Route("GetAllClientPurchaseProducts")]
        public async Task<IActionResult> GetAllClientPurchaseProducts(int clientId)
        {
            var payload = await _clientRepository.GetAllClientPurchaseProducts(clientId);
            return StatusCode(200, payload);
        }
        [HttpGet]
        [Route("GetAllSeparationProducts")]
        public async Task<IActionResult> GetAllSeparationProducts(int clientId)
        {
            var payload = await _clientRepository.GetAllSeparationProducts(clientId);
            return StatusCode(200, payload);
        }
        [HttpGet]
        [Route("GetAvailablePromotionBySeparation")]
        public async Task<IActionResult> GetAvailablePromotionBySeparation(int separationId)
        {
            var payload = await _clientRepository.GetAvailablePromotionBySeparation(separationId);
            return StatusCode(200, payload);
        }
    }
}
