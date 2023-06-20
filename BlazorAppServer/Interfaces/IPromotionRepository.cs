using BlazorAppShared.DTO;

namespace BlazorAppServer.Interfaces
{
    public interface IPromotionRepository
    {
        Task <List<PromotionDTO>> GetAllPromotions();
    }
}
