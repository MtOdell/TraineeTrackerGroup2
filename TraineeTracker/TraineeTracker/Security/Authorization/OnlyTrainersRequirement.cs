using Microsoft.AspNetCore.Authorization;

namespace TraineeTracker.Security.Authorization
{
    public class OnlyTrainersRequirement : IAuthorizationRequirement
    {
    }
}
