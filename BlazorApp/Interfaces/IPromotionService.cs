using BlazorAppShared.DTO;

namespace BlazorApp.Interfaces
{
    public interface IPromotionService
    {
        Task <List<PromotionDTO>> GetAllPromotions();
    }
}
