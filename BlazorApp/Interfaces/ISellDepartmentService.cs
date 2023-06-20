using BlazorAppShared.DTO;

namespace BlazorApp.Interfaces
{
    public interface ISellDepartmentService
    {
        Task<List<SellDepartmentDTO>> GetSellDepartments();
    }
}
