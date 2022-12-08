using Microsoft.EntityFrameworkCore;
using server.Model;

namespace server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {

        }

        public DbSet<FinanceTracker> FinanceTracker { get; set; }
    }
}
