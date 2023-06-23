using BlazorAppShared;
using BlazorAppShared.DTO;

namespace BlazorAppServer.Interfaces
{
    public interface IClientRepository
    {
        Task<ResponsePayload> CreateClient(CreateEditClientDTO clientDTO);
        Task<ResponsePayload> SeparateProducts(List<CreateEditClientSeparationProductDetailDTO> clientSeparationProductDetailDTOs, int clientId, int? promotionId);
        Task<ResponsePayload> PurchaseProduct(List<CreateEditClientProductPurchaseDetailDTO> clientProductPurchaseDetailDTOs, int clientId, int? separatePlanId);
        Task<ResponsePayload<ClientDTO>> GetClient(string clientName);
        Task<ResponsePayload<ClientProductPurchaseDTO>> GetClientPurchaseProducts(int purchaseId);
        Task<List<ClientProductPurchaseDTO>> GetAllClientPurchaseProducts(int clientId);
        Task<List<ClientSeparationProductDTO>> GetAllSeparationProducts(int clientId);
        Task<ResponsePayload<PromotionDTO>> GetAvailablePromotionBySeparation(int separationId);

    }
}
