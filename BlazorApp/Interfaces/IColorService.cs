using BlazorAppShared.DTO;

namespace BlazorApp.Interfaces
{
    public interface IColorService
    {
        Task<List<ColorDTO>> GetAllColors();
    }
}
