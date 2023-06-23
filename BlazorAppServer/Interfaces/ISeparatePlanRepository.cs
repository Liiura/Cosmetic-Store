using BlazorAppShared.DTO;

namespace BlazorAppServer.Interfaces
{
    public interface ISeparatePlanRepository
    {
        Task<List<SeparatePlanDTO>> GetAllSeparatePlans();
    }
}
