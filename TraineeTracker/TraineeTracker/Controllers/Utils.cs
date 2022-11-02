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
                Skills = userData.Skills ,
                Trackers = userData.Trackers
    };
        public static TrackerViewModel TrackerToViewModel(Tracker tracker) =>
            new TrackerViewModel()
            {
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
