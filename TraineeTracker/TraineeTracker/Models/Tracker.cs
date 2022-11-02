using System.ComponentModel.DataAnnotations.Schema;
using static TraineeTracker.Models.SkillsEnum;

namespace TraineeTracker.Models
{
    public class Tracker
    {
        public int ID { get; init; }

        [ForeignKey("UserData")]
        public int UserDataId { get; init; }
        public int Week { get; init; }
        public string Stop { get; set; } = "N/A";
        public string Start { get; set; } = "N/A";
        public string Continue { get; set; } = "N/A";
        public string Comments { get; set; } = "";
        public SkillsRank TechnicalSkills { get; set; }
        public SkillsRank ConsultantSkills { get; set; }
    }
}
