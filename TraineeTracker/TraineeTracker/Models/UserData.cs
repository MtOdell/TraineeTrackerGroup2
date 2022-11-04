using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using TraineeTracker.Data.Migrations;
using static TraineeTracker.Models.SkillsEnum;

namespace TraineeTracker.Models
{
    [ExcludeFromCodeCoverage]
    class DataFactory
    {
        public static List<Tracker> GetDefaultTracker(int week)
        {
            List<Tracker> trackers = new();

            for (int i = 1; i < week; i++)
            {
                trackers.Add(new Tracker()
                {
                    Stop = "Something bad",
                    Start = "Something good",
                    Continue = "That thing I'm good at!",
                    Week = i,
                    ConsultantSkills = SkillsRank.Low_Skilled,
                    TechnicalSkills = SkillsRank.Skilled
                });
            }
            return trackers;
        }
    }

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

        public List<Tracker>? Trackers { get; set; } = DataFactory.GetDefaultTracker(8);
    }
}
