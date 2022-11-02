using System.ComponentModel.DataAnnotations.Schema;
using static TraineeTracker.Models.SkillsEnum;

namespace TraineeTracker.Models
{
    public class Tracker
    {
        public int ID { get; set; }

        [ForeignKey("UserData")]
        public int UserDataId { get; set; }
        public int Week { get; set; }
        public string Stop { get; set; } = "";
        public string Start { get; set; } = "";
        public string Continue { get; set; } = "";
        public string Comments { get; set; } = "";
        public SkillsRank TechnicalSkills { get; set; }
        public SkillsRank ConsultantSkills { get; set; }
    }
}
