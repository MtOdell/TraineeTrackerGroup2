using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using TraineeTracker.Models;

namespace TraineeTracker.Service
{
    public class UserManager : IUserManager<User>
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserManager(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _userManager = userManager; 
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<User> GetUserAsync()
        {
            return _userManager.GetUserAsync(_httpContextAccessor.HttpContext!.User);   
        }
    }
}
