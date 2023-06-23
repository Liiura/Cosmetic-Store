using BlazorAppShared.DTO;

namespace BlazorApp.Interfaces
{
    public interface ISeparatePlanService
    {
        Task<List<SeparatePlanDTO>> GetAllSeparatePlans();
    }
}
