using BlazorAppServer.Interfaces;
using BlazorAppShared.DTO;
using BlazorAppShared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppServer.Repositories
{
    public class ColorRepository : IColorRepository
    {
        private readonly ApplicationDbContext _context;
        public ColorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        async Task<List<ColorDTO>> IColorRepository.GetAllColors()
        {
            using (var context = _context)
            {
                var allColors = await context.Color.Select(x => new ColorDTO { Id = x.Id, Name = x.Name }).ToListAsync();
                return allColors;
            }
        }

         List<ColorDTO> IColorRepository.GetAllColorsWithStoreProcedure()
        {
            using (var context = _context)
            {
                var allColors = context.Color.FromSqlRaw("EXEC [dbo].[GetAllColors]").AsEnumerable();
                var colorsToReturn = allColors.Select(x => new ColorDTO { Id = x.Id, Name = x.Name }).ToList();
                return colorsToReturn;
            }
        }
    }
}
