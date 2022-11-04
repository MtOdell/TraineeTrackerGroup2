using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace TraineeTracker.Security.Authorization
{
    public class OnlyTraineesAuthorizationHandler : AuthorizationHandler<OnlyTraineesRequirement>
    {

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OnlyTraineesRequirement requirement)
        {
            if (context.User.IsInRole(Roles.Trainee))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
