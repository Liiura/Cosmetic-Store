using BlazorApp.Interfaces;
using BlazorAppShared.DTO;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly HttpClient _httpClient;
        public PromotionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<PromotionDTO>> GetAllPromotions()
        {
            var result = await _httpClient.GetFromJsonAsync<List<PromotionDTO>>("/Promotion/GetAllPromotions");
            return result;
        }
    }
}
