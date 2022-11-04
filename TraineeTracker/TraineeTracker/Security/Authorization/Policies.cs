namespace TraineeTracker.Security.Authorization
{
    public class Policies
    {
        public const string OnlyTrainee = nameof(OnlyTrainee);
        public const string OnlyTrainer = nameof(OnlyTrainer);
        public const string OnlyAdmin = nameof(OnlyAdmin);
    }
}
