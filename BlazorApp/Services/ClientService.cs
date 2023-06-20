using BlazorApp.Interfaces;
using BlazorAppShared;
using BlazorAppShared.DTO;
using BlazorAppShared.Models;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class ClientService: IClientService
    {
        private readonly HttpClient _httpClient;
        public ClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponsePayload> CreateClient(CreateEditClientDTO clientDTO)
        {
            var fetch = await _httpClient.PostAsJsonAsync("/Client/CreateClient",clientDTO);
            var response = await fetch.Content.ReadFromJsonAsync<ResponsePayload>();
            if(response.Status >= 200 && response.Status < 300)
            {
                return response;
            }
            else
            {
                throw new Exception(response.Message);
            }
        }

        public async Task<List<ClientProductPurchaseDTO>> GetAllClientPurchaseProducts(int clientId)
        {
            var result = await _httpClient.GetFromJsonAsync<List<ClientProductPurchaseDTO>>("/Client/GetAllClientPurchaseProducts?clientId="+clientId);
            return result;
        }

        public async Task<List<ClientSeparationProductDTO>> GetAllSeparationProducts(int clientId)
        {
            var result = await _httpClient.GetFromJsonAsync<List<ClientSeparationProductDTO>>("/Client/GetAllSeparationProducts?clientId=" + clientId);
            return result;
        }

        public async Task<ResponsePayload<PromotionDTO>> GetAvailablePromotionBySeparation(int separationId)
        {
            var result = await _httpClient.GetFromJsonAsync<ResponsePayload<PromotionDTO>>("/Client/GetAvailablePromotionBySeparation?separationId=" + separationId);
            if(result.Status >= 200 && result.Status < 300)
            {
                return result;
            }
            else
            {
                throw new Exception(result.Message);
            }
        }

        public async Task<ResponsePayload<ClientDTO>> GetClient(int clientId)
        {
            var result = await _httpClient.GetFromJsonAsync<ResponsePayload<ClientDTO>>("/Client/GetClient?clientId=" + clientId);
            if (result.Status >= 200 && result.Status < 300)
            {
                return result;
            }
            else
            {
                throw new Exception(result.Message);
            }
        }

        public async Task<ResponsePayload<ClientProductPurchaseDTO>> GetClientPurchaseProducts(int purchaseId)
        {
            var result = await _httpClient.GetFromJsonAsync<ResponsePayload<ClientProductPurchaseDTO>>("/Client/GetClientPurchaseProducts?purchaseId=" + purchaseId);
            if (result.Status >= 200 && result.Status < 300)
            {
                return result;
            }
            else
            {
                throw new Exception(result.Message);
            }
        }

        public async Task<ResponsePayload> PurchaseProduct(List<CreateEditClientProductPurchaseDetailDTO> clientProductPurchaseDetailDTOs, int clientId)
        {
            var fetch = await _httpClient.PostAsJsonAsync("/Client/PurchaseProduct?clientId="+clientId, clientProductPurchaseDetailDTOs);
            var response = await fetch.Content.ReadFromJsonAsync<ResponsePayload>();
            if (response.Status >= 200 && response.Status < 300)
            {
                return response;
            }
            else
            {
                throw new Exception(response.Message);
            }
        }

        public async Task<ResponsePayload> SeparateProducts(List<CreateEditClientSeparationProductDetailDTO> clientSeparationProductDetailDTOs, int clientId)
        {
            var fetch = await _httpClient.PostAsJsonAsync("/Client/SeparateProducts?clientId=" + clientId, clientSeparationProductDetailDTOs);
            var response = await fetch.Content.ReadFromJsonAsync<ResponsePayload>();
            if (response.Status >= 200 && response.Status < 300)
            {
                return response;
            }
            else
            {
                throw new Exception(response.Message);
            }
        }
    }
}
