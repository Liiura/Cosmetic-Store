using BlazorAppServer.Interfaces;
using BlazorAppShared.DTO;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppServer.Repositories
{
    public class SeparatePlanRepository : ISeparatePlanRepository
    {
        private readonly ApplicationDbContext _context;
        public SeparatePlanRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<SeparatePlanDTO>> GetAllSeparatePlans()
        {
            using (var context = _context)
            {
                var allSeparatePlans = await context.SeparatePlan.Select(x => new SeparatePlanDTO {
                    Id = x.Id,
                    SeparatePlanName = x.SeparatePlanName,
                    SeparateValue = x.SeparateValue,
                    SeparatePlanPercentage = x.SeparatePlanPercentage }).ToListAsync();
                return allSeparatePlans;
            }
        }
    }
}
