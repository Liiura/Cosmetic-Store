using BlazorApp.Interfaces;
using BlazorAppShared.DTO;
using BlazorAppShared.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class SeparatePlanService : ISeparatePlanService
    {
        private readonly HttpClient _httpClient;
        public SeparatePlanService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<SeparatePlanDTO>> GetAllSeparatePlans()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SeparatePlanDTO>>("/SeparatePlan/GetAllSeparatePlans");
            return result;
        }
    }
}
