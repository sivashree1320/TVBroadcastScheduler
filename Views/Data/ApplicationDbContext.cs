using Microsoft.EntityFrameworkCore;
using TVBroadcastScheduler.Models;

namespace TVBroadcastScheduler.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Broadcast> Broadcasts { get; set; }
    }
}
