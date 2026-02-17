using Auto.Market.Models;
using Microsoft.EntityFrameworkCore;

namespace Auto.Market.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
    }