using Microsoft.EntityFrameworkCore;
using Webapi.Entities;

namespace Webapi.Data{
    public class AppOracleDbContext:DbContext{
        public AppOracleDbContext(DbContextOptions<AppOracleDbContext> options):base(options)
        {
            
        }
        public DbSet<Item> Items;

    }
}