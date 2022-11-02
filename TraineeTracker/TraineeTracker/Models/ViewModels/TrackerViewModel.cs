using static TraineeTracker.Models.SkillsEnum;
using static TraineeTracker.Models.Tracker;
    public class TrackerViewModel
    {
        public int UserDataId { get; set; }
        public int Week { get; set; }
        public string Stop { get; set; } = "";
        public string Start { get; set; } = "";
        public string Continue { get; set; } = "";
        public string Comments { get; set; } = "";
        public SkillsRank TechnicalSkills { get; set; }
        public SkillsRank ConsultantSkills { get; set; }
    }
