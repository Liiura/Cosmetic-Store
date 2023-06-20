using BlazorAppShared.DTO;

namespace BlazorAppServer.Interfaces
{
    public interface IColorRepository
    {
        Task<List<ColorDTO>> GetAllColors();
        List<ColorDTO> GetAllColorsWithStoreProcedure();
    }
}
