using BlazorAppShared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppServer
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options )
            :base(options)
        {
                
        }
        public DbSet<Client> Client { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Promotion> Promotion { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<ProductColorDetail> ProductColorDetail { get; set; }
        public DbSet<ClientProductPurchase> ClientProductPurchase { get; set; }
        public DbSet<ClientSeparationProduct> ClientSeparationProduct { get; set;}
        public DbSet<ClientSeparationProductDetail> ClientSeparationProductDetail { get; set; }
        public DbSet<ClientProductPurchaseDetail> ClientProductPurchaseDetail { get; set;}
        public DbSet<SellDepartment> SellDepartment { get; set; }
    }
}
