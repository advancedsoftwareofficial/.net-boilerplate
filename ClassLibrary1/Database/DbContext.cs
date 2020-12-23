using AdvancedSoftware.DataAccess.Database;
using Microsoft.EntityFrameworkCore;

namespace NETBoilerplate.DataAccess.Database
{
    public class DbContext : AppDbContext<DbContext>
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
