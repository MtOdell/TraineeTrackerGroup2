using TraineeTracker.Models;
using TraineeTracker.Models.ViewModels;

namespace TraineeTracker.Controllers
{
    public static class Utils
    {
        public static UserDataViewModel UserDataToViewModel(UserData userData) =>
            new UserDataViewModel()
            {
                ID = userData.ID,
                FirstName = userData.FirstName,
                LastName = userData.LastName,
                Title = userData.Title,
                Education = userData.Education,
                Experience = userData.Experience,
                Activity = userData.Activity,
                Biography = userData.Biography,
                Skills = userData.Skills
            };
        
        public static UserData ViewModelToUserData(UserDataViewModel userDataViewModel) =>
            new UserData()
            {
                
                ID= userDataViewModel.ID,
                FirstName= userDataViewModel.FirstName,
                LastName= userDataViewModel.LastName,
                Title= userDataViewModel.Title,
                Education  = userDataViewModel.Education,
                Experience = userDataViewModel.Experience,
                Activity = userDataViewModel.Activity,
                Biography = userDataViewModel.Biography,
                Skills = userDataViewModel.Skills

            };
    

        public static TrackerViewModel TrackerToViewModel(Tracker tracker) =>
            new TrackerViewModel()
            {
                ID = tracker.ID,
                UserDataId = tracker.UserDataId,
                Week = tracker.Week,
                Stop = tracker.Stop,
                Start = tracker.Start,
                Continue = tracker.Continue,
                Comments = tracker.Comments,
                TechnicalSkills = tracker.TechnicalSkills,
                ConsultantSkills = tracker.ConsultantSkills
            };
        public static Tracker ViewModelToTracker(TrackerViewModel tracker) =>
            new Tracker()
            {
                ID = tracker.ID,
                UserDataId = tracker.UserDataId,
                Week = tracker.Week,
                Stop = tracker.Stop,
                Start = tracker.Start,
                Continue = tracker.Continue,
                Comments = tracker.Comments,
                TechnicalSkills = tracker.TechnicalSkills,
                ConsultantSkills = tracker.ConsultantSkills
            };
    }
}
