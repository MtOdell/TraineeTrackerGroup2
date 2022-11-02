using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace TraineeTracker.Models
{
    public class UserData
    {
        public enum Level
        {
            Trainee,
            Trainer,
            Admin
        }

        [ForeignKey("User")]
        public string UserID { get; set; }
        public int ID { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string? Title { get; set; } = "";
        public string? Education { get; set; } = "";
        public string? Experience { get; set; } = "";
        public string? Activity { get; set; } = "";
        public string? Biography { get; set; } = "";
        public string? Skills { get; set; } = "";

        public Level Roles { get; set; } = Level.Trainee;

        public List<Tracker>? Trackers { get; set; } = new List<Tracker>();
    }
}
