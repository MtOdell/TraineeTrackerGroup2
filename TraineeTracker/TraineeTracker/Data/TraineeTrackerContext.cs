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
        public DbSet<User> UserDB { get; set; }
        public DbSet<UserData> UserDataDB { get; set; }
        public DbSet<Tracker> TrackerDB { get; set; }
    }
}
