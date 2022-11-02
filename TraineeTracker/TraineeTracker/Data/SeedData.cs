using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using TraineeTracker.Models;

namespace TraineeTracker.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            TraineeTrackerContext context = serviceProvider.GetRequiredService<TraineeTrackerContext>();
            UserManager<User> userManager = serviceProvider.GetService<UserManager<User>>()!;
            RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(context);

            context.Database.EnsureCreated();

            if (context.UserDB.Any() || context.TrackerDB.Any() || context.UserDataDB.Any()) return;

            var trainer = new IdentityRole { Name = "Trainer", NormalizedName = "Trainer" };
            var trainee = new IdentityRole { Name = "Trainee", NormalizedName = "Trainee" };

            roleStore.CreateAsync(trainer).GetAwaiter().GetResult();
            roleStore.CreateAsync(trainee).GetAwaiter().GetResult();

            var phil = new User { UserName = "Phil@SpartaGlobal.com", Email = "Phil@SpartaGlobal.com", EmailConfirmed = true };
            var peter = new User { UserName = "Peter@SpartaGlobal.com", Email = "Peter@SpartaGlobal.com", EmailConfirmed = true };
            var nish = new User { UserName = "Nish@SpartaGlobal.com", Email = "Nish@SpartaGlobal.com", EmailConfirmed = true };

            userManager.CreateAsync(phil, "Password1!").GetAwaiter().GetResult();
            userManager.CreateAsync(peter, "Password1!").GetAwaiter().GetResult();
            userManager.CreateAsync(nish, "Password1!").GetAwaiter().GetResult();


            IdentityUserRole<string>[] userRoles = new IdentityUserRole<string>[]
            {
                new IdentityUserRole<string>
                {
                    UserId = userManager.GetUserIdAsync(phil).GetAwaiter().GetResult(),
                    RoleId = roleStore.GetRoleIdAsync(trainee).GetAwaiter().GetResult()
                },
                new IdentityUserRole<string>
                {
                    UserId = userManager.GetUserIdAsync(peter).GetAwaiter().GetResult(),
                    RoleId = roleStore.GetRoleIdAsync(trainee).GetAwaiter().GetResult()
                },
                new IdentityUserRole<string>
                {
                    UserId = userManager.GetUserIdAsync(nish).GetAwaiter().GetResult(),
                    RoleId = roleStore.GetRoleIdAsync(trainer).GetAwaiter().GetResult()
                }
            };
             
            context.UserRoles.AddRange(userRoles);
            context.SaveChanges();

            UserData userDataPhil = new UserData()
            {
                FirstName = "Phil",
                LastName = "Phil",
                Activity = "C#",
                UserID = userManager.GetUserIdAsync(phil).GetAwaiter().GetResult()
            };
            UserData userDataPeter = new UserData()
            {
                FirstName = "Peter",
                LastName = "Bellaby",
                Activity = "C#",
                UserID = userManager.GetUserIdAsync(peter).GetAwaiter().GetResult()
            };
            UserData userDataNish = new UserData()
            {
                FirstName = "Nish",
                LastName = "Mandela",
                Activity = "C#",
                UserID = userManager.GetUserIdAsync(nish).GetAwaiter().GetResult()
            };
            phil.UserData = userDataPhil;
            peter.UserData = userDataPeter;
            nish.UserData = userDataNish;

            context.UserDataDB.Add(userDataPhil);
            context.UserDataDB.Add(userDataPeter);
            context.UserDataDB.Add(userDataNish);
            context.SaveChanges();
        }
    }
}
