using Microsoft.AspNetCore.Authorization;

namespace TraineeTracker.Security.Authorization
{ 
        public class OnlyTraineesRequirement : IAuthorizationRequirement
        {
        }
    
}
