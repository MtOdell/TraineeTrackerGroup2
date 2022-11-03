using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using TraineeTracker.Models;

namespace TraineeTracker.Data
{
    public class TraineeTrackerContext : IdentityDbContext
    {
        [ExcludeFromCodeCoverage]

        public TraineeTrackerContext(DbContextOptions<TraineeTrackerContext> options)
            : base(options)
        {
        }
        public DbSet<User> UserDB { get; set; }
        public DbSet<UserData> UserDataDB { get; set; }
        public DbSet<Tracker> TrackerDB { get; set; }
    }
}
