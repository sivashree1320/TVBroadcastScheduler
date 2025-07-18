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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Broadcast>().HasData(
                new Broadcast
                {
                    Id = 1,
                    Title = "English Morning Show",
                    Description = "Start your day with fresh updates and music.",
                    StartTime = DateTime.Parse("2025-07-20 07:00:00"),
                    EndTime = DateTime.Parse("2025-07-20 08:00:00"),
                    Status = "Pending",
                    CreatedBy = "scheduler",
                    ApprovalComment = null,
                    Category = "Daily",
                    Channel = "BBC News"
                },
                new Broadcast
                {
                    Id = 2,
                    Title = "Business Buzz",
                    Description = "World economy & stock news.",
                    StartTime = DateTime.Parse("2025-07-20 09:00:00"),
                    EndTime = DateTime.Parse("2025-07-20 10:00:00"),
                    Status = "Pending",
                    CreatedBy = "scheduler",
                    ApprovalComment = null,
                    Category = "Daily",
                    Channel = "CNN"
                },
                new Broadcast
                {
                    Id = 3,
                    Title = "Tech Talk Live",
                    Description = "Latest in gadgets and innovation.",
                    StartTime = DateTime.Parse("2025-07-20 17:00:00"),
                    EndTime = DateTime.Parse("2025-07-20 18:00:00"),
                    Status = "Pending",
                    CreatedBy = "scheduler",
                    ApprovalComment = null,
                    Category = "Daily",
                    Channel = "Discovery"
                }
            );
        }

    }

}
