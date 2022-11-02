namespace TraineeTracker.Models.ViewModels
{
    public class TrackerViewModel
    {
        public int UserDataId { get; init; }
        public int Week { get; init; }
        public string Stop { get; set; } = "N/A";
        public string Start { get; set; } = "N/A";
        public string Continue { get; set; } = "N/A";
        public string Comments { get; set; } = "";
        public int TechnicalSkills { get; set; } = 0;
        public int ConsultantSkills { get; set; } = 0;
    }
}
