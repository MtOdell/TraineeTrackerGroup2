using System.Security.Claims;

namespace TraineeTracker.Service
{
    public interface IUserManager<TUser>
    {
        Task<TUser> GetUserAsync();
        bool IsInRole(string role);
    }
}
