using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraineeTracker.Models
{
    public class User : IdentityUser
    {
        public UserData userData = new UserData();
    }
}
