using BlazorAppShared;
using BlazorAppShared.DTO;

namespace BlazorApp.Interfaces
{
    public interface IClientService
    {
        Task<ResponsePayload> CreateClient(CreateEditClientDTO clientDTO);
        Task<ResponsePayload> SeparateProducts(List<CreateEditClientSeparationProductDetailDTO> clientSeparationProductDetailDTOs, int clientId);
        Task<ResponsePayload> PurchaseProduct(List<CreateEditClientProductPurchaseDetailDTO> clientProductPurchaseDetailDTOs, int clientId);
        Task<ResponsePayload<ClientDTO>> GetClient(int clientId);
        Task<ResponsePayload<ClientProductPurchaseDTO>> GetClientPurchaseProducts(int purchaseId);
        Task<List<ClientProductPurchaseDTO>> GetAllClientPurchaseProducts(int clientId);
        Task<List<ClientSeparationProductDTO>> GetAllSeparationProducts(int clientId);
        Task<ResponsePayload<PromotionDTO>> GetAvailablePromotionBySeparation(int separationId);

    }
}
