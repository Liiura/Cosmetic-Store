using BlazorAppShared;
using BlazorAppShared.DTO;
namespace BlazorApp.Interfaces
{
    public interface IProductService
    {
        Task<ResponsePayload<ProductDTO>> CreateProduct(CreateUpdateProductDTO productDTO);
        Task<ResponsePayload> DeleteProduct(int productId);
        Task<ResponsePayload<ProductDTO>> GetProductById(int productId);
        Task<List<ProductDTO>> GetAllProducts();
        Task<ResponsePayload<ProductDTO>> UpdateProduct(CreateUpdateProductDTO productDTO, int productId);

    }
}
