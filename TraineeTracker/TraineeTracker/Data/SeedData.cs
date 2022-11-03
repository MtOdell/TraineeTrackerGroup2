using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using TraineeTracker.Models;
using System.Diagnostics.CodeAnalysis;

namespace TraineeTracker.Data
{
    public class SeedData
    {
        [ExcludeFromCodeCoverage]

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
            var serg = new User { UserName = "Serg@SpartaGlobal.com", Email = "Serg@SpartaGlobal.com", EmailConfirmed = true };
            var adam = new User { UserName = "Adam@SpartaGlobal.com", Email = "Adam@SpartaGlobal.com", EmailConfirmed = true };
            var lewis = new User { UserName = "Lewis@SpartaGlobal.com", Email = "Lewis@SpartaGlobal.com", EmailConfirmed = true };

            userManager.CreateAsync(phil, "Password1!").GetAwaiter().GetResult();
            userManager.CreateAsync(peter, "Password1!").GetAwaiter().GetResult();
            userManager.CreateAsync(nish, "Password1!").GetAwaiter().GetResult();
            userManager.CreateAsync(serg, "Password1!").GetAwaiter().GetResult();
            userManager.CreateAsync(adam, "Password1!").GetAwaiter().GetResult();
            userManager.CreateAsync(lewis, "Password1!").GetAwaiter().GetResult();


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
                },
                 new IdentityUserRole<string>
                {
                    UserId = userManager.GetUserIdAsync(serg).GetAwaiter().GetResult(),
                    RoleId = roleStore.GetRoleIdAsync(trainee).GetAwaiter().GetResult()
                },
                new IdentityUserRole<string>
                {
                    UserId = userManager.GetUserIdAsync(adam).GetAwaiter().GetResult(),
                    RoleId = roleStore.GetRoleIdAsync(trainee).GetAwaiter().GetResult()
                },
                new IdentityUserRole<string>
                {
                    UserId = userManager.GetUserIdAsync(lewis).GetAwaiter().GetResult(),
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
                UserID = userManager.GetUserIdAsync(phil).GetAwaiter().GetResult(),
                Roles = UserData.Level.Trainee
            };
            UserData userDataPeter = new UserData()
            {
                FirstName = "Peter",
                LastName = "Bellaby",
                Activity = "C#",
                UserID = userManager.GetUserIdAsync(peter).GetAwaiter().GetResult(),
                Roles = UserData.Level.Trainee
            };
            UserData userDataNish = new UserData()
            {
                FirstName = "Nish",
                LastName = "Mandela",
                Activity = "C#",
                UserID = userManager.GetUserIdAsync(nish).GetAwaiter().GetResult(),
                Roles = UserData.Level.Trainer
            };
            UserData userDataSerg = new UserData()
            {
                FirstName = "Serg",
                LastName = "P",
                Activity = "C#",
                UserID = userManager.GetUserIdAsync(serg).GetAwaiter().GetResult(),
                Roles = UserData.Level.Trainee
            };
            UserData userDataAdam = new UserData()
            {
                FirstName = "Adam",
                LastName = "Millard",
                Activity = "C#",
                UserID = userManager.GetUserIdAsync(adam).GetAwaiter().GetResult(),
                Roles = UserData.Level.Trainee
            };
            UserData userDataLewis = new UserData()
            {
                FirstName = "Lewis",
                LastName = "Mandela",
                Activity = "C#",
                UserID = userManager.GetUserIdAsync(nish).GetAwaiter().GetResult(),
                Roles = UserData.Level.Trainer
            };
            userDataPhil.Trackers.Add(new Tracker() { Stop = "Being funny", Week = 1 });
            userDataPhil.Trackers.Add(new Tracker() { Stop = "Playing Bobble League", Week = 2 });
            
            phil.UserData = userDataPhil;

            userDataPeter.Trackers.Add(new Tracker() { Start = "Being funny", Week = 1  });
            peter.UserData = userDataPeter;

            userDataSerg.Trackers.Add(new Tracker() { Start = "Being funny", Week = 1 });
            serg.UserData = userDataSerg;

            userDataAdam.Trackers.Add(new Tracker() { Start = "Being funny", Week = 1 });
            adam.UserData = userDataAdam;

            userDataSerg.Trackers.Add(new Tracker() { Stop = "playing bobble league", Week = 2 });
            serg.UserData = userDataSerg;

            lewis.UserData = userDataSerg; 
            nish.UserData = userDataNish;

           
            context.UserDataDB.Add(userDataPhil);
            context.UserDataDB.Add(userDataPeter);
            context.UserDataDB.Add(userDataNish);
            context.UserDataDB.Add(userDataSerg);
            context.UserDataDB.Add(userDataLewis);
            context.UserDataDB.Add(userDataAdam);
            context.SaveChanges();
        }
    }
}
