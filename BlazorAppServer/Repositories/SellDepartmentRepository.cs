using BlazorAppServer.Interfaces;
using BlazorAppShared.DTO;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppServer.Repositories
{
    public class SellDepartmentRepository: ISellDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public SellDepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<SellDepartmentDTO>> GetSellDepartments()
        {
            using(var context = _context)
            {
                var allSellDepartments = await context.SellDepartment.Select(x => new SellDepartmentDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToListAsync();
                return allSellDepartments;
            }
        }
    }
}
