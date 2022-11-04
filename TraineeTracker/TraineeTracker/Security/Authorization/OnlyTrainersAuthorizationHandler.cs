using Microsoft.AspNetCore.Authorization;

namespace TraineeTracker.Security.Authorization
{
    public class OnlyTrainersAuthorizationHandler : AuthorizationHandler<OnlyTrainersRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OnlyTrainersRequirement requirement)
        {
            if (context.User.IsInRole(Roles.Trainer))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
