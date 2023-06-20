using BlazorApp.Interfaces;
using BlazorAppShared.DTO;
using BlazorAppShared.Models;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class ColorService : IColorService
    {
        private readonly HttpClient _httpClient;
        public ColorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ColorDTO>> GetAllColors()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ColorDTO>>("/Color/GetAllColors");
            return result;
        }
    }
}
