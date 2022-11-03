using System.Security.Claims;
using TraineeTracker.Models;

namespace TraineeTracker.Service
{
    public interface IUserManager<TUser>
    {
        Task<TUser> GetUserAsync();

        Task<User> GetUserByIdAsync(string id);
        bool IsInRole(string role);
        public Task ChangeRole(User user, string role);
    }
}
