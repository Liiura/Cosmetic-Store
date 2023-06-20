using BlazorApp.Interfaces;
using BlazorAppShared;
using BlazorAppShared.DTO;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponsePayload<ProductDTO>> CreateProduct(CreateUpdateProductDTO productDTO)
        {
            var fetch = await _httpClient.PostAsJsonAsync("/Product/CreateProduct", productDTO);
            var response = await fetch.Content.ReadFromJsonAsync<ResponsePayload<ProductDTO>>();
            if (response.Status >= 200 && response.Status < 300)
            {
                return response;
            }
            else
            {
                throw new Exception(response.Message);
            }
        }

        public async Task<ResponsePayload> DeleteProduct(int productId)
        {
            var fetch = await _httpClient.DeleteAsync("/Product/DeleteProduct?productId="+ productId);
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

        public async Task<List<ProductDTO>> GetAllProducts()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ProductDTO>>("/Product/GetAllProducts");
            return result;
        }

        public async Task<ResponsePayload<ProductDTO>> GetProductById(int productId)
        {
            var result = await _httpClient.GetFromJsonAsync<ResponsePayload<ProductDTO>>("/Product/GetProductById?productId="+productId);
            if (result.Status >= 200 && result.Status < 300)
            {
                return result;
            }
            else
            {
                throw new Exception(result.Message);
            }
        }

        public async Task<ResponsePayload<ProductDTO>> UpdateProduct(CreateUpdateProductDTO productDTO, int productId)
        {
            var fetch = await _httpClient.PutAsJsonAsync("/Product/UpdateProduct?productId="+productId, productDTO);
            var response = await fetch.Content.ReadFromJsonAsync<ResponsePayload<ProductDTO>>();
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
