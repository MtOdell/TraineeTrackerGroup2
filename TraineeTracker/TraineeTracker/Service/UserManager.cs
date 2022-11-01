using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using TraineeTracker.Models;

namespace TraineeTracker.Service
{
    public class UserManager : IUserManager<User>
    {
        private readonly UserManager<User> _userManager;
        public UserManager(UserManager<User> userManager)
        {
            _userManager = userManager; 
        }

        public Task<User> GetUserAsync(ClaimsPrincipal principal)
        {
            return _userManager.GetUserAsync(principal);   
        }
    }
}
