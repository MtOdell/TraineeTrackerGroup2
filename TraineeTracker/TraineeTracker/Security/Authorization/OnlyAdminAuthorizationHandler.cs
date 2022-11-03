using Microsoft.AspNetCore.Authorization;

namespace TraineeTracker.Security.Authorization
{
    public class OnlyAdminAuthorizationHandler : AuthorizationHandler<OnlyAdminRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OnlyAdminRequirement requirement)
        {
            if (context.User.IsInRole(Roles.Admin))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
