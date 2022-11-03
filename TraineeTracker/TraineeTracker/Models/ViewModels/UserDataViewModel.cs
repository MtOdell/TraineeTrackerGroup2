namespace TraineeTracker.Models.ViewModels
{
    public class UserDataViewModel
    {
        public enum Level
        {
            Trainee,
            Trainer,
            Admin
        }
        public int ID { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Title { get; set; } = "";
        public string Education { get; set; } = "";
        public string Experience { get; set; } = "";
        public string Activity { get; set; } = "";
        public string Biography { get; set; } = "";
        public string Skills { get; set; } = "";
        public UserData.Level Roles { get; set; }
    }
}
