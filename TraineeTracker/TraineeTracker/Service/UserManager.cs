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

        public bool IsInRole(string role)
        {
            return _httpContextAccessor.HttpContext!.User.IsInRole(role);
        }

        public async Task ChangeRole(User user, string role)
        {
            var roleToDelete = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            await _userManager.AddToRoleAsync(user, role);
            await _userManager.RemoveFromRoleAsync(user, roleToDelete);
            var letssee = await _userManager.IsInRoleAsync(user, roleToDelete);
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }
    }
}
