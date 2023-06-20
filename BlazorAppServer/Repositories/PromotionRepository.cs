using BlazorAppServer.Interfaces;
using BlazorAppShared.DTO;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppServer.Repositories
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly ApplicationDbContext _context;
        public PromotionRepository(ApplicationDbContext context)
        {

            _context = context;

        }
        async Task<List<PromotionDTO>> IPromotionRepository.GetAllPromotions()
        {
            using (var context = _context)
            {
                var allPromotions = await context.Promotion.Select(x => new PromotionDTO
                {
                    PromotionName = x.PromotionName,
                    Id = x.Id,
                    MinimalAmount= x.MinimalAmount,
                    MaximalAmount= x.MaximalAmount,
                    PromotionPercentage = x.PromotionPercentage
                }).ToListAsync();
                return allPromotions;
            }
        }
    }
}
