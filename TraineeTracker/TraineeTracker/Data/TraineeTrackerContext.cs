using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TraineeTracker.Models;

namespace TraineeTracker.Data
{
    public class TraineeTrackerContext : IdentityDbContext
    {
        public TraineeTrackerContext(DbContextOptions<TraineeTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<Trainee> TraineeDB { get; set; }
        public DbSet<Trainer> TrainerDB { get; set; }
        public DbSet<Profile> ProfileDB { get; set; }
        public DbSet<Tracker> TrackerDB { get; set; }
    }
}
