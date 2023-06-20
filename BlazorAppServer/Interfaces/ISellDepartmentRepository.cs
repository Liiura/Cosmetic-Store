using BlazorAppShared.DTO;

namespace BlazorAppServer.Interfaces
{
    public interface ISellDepartmentRepository
    {
        Task<List<SellDepartmentDTO>> GetSellDepartments();
    }
}
