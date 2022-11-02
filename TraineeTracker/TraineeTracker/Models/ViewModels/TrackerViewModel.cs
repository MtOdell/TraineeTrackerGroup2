namespace TraineeTracker.Models.ViewModels
{
    public class TrackerViewModel
    {
        public int UserDataId { get; set; } 
        public int Week { get; set; }
        public string Stop { get; set; } = "";
        public string Start { get; set; } = "";
        public string Continue { get; set; } = "";
        public string Comments { get; set; } = "";
        public int TechnicalSkills { get; set; } = 0;
        public int ConsultantSkills { get; set; } = 0;
    }
}
