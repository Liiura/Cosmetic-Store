using BlazorAppShared;
using BlazorAppShared.DTO;
namespace BlazorAppServer.Interfaces
{
    public interface IProductRepository
    {
        Task<ResponsePayload<ProductDTO>> CreateProduct(CreateUpdateProductDTO productDTO);
        Task<ResponsePayload> DeleteProduct(int productId);
        Task<ResponsePayload<ProductDTO>> GetProductById(int productId);
        Task <List<ProductDTO>> GetAllProducts();
        Task<ResponsePayload<ProductDTO>> UpdateProduct(CreateUpdateProductDTO productDTO, int productId);

    }
}
