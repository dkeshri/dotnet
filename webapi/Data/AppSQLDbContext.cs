using Microsoft.EntityFrameworkCore;
using Webapi.Entities;

namespace Webapi.Data
{
    public class AppSQLDbContext : DbContext
    {
        public AppSQLDbContext(DbContextOptions<AppSQLDbContext> options)
        : base(options)
        {

        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}