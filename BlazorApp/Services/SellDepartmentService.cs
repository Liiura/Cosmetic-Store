using BlazorApp.Interfaces;
using BlazorAppShared.DTO;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class SellDepartmentService : ISellDepartmentService
    {
        private readonly HttpClient _httpClient;
        public SellDepartmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<SellDepartmentDTO>> GetSellDepartments()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SellDepartmentDTO>>("/SellDepartment/GetAllSellDepartments");
            return result;
        }
    }
}
