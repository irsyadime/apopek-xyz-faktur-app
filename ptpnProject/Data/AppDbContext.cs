using Microsoft.EntityFrameworkCore;
using ptpnProject.Models.Entities;

namespace ptpnProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {
        }
        public DbSet<Faktur> Fakturs {  get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<FakturDetail> FakturDetail { get; set;}
    }
}
