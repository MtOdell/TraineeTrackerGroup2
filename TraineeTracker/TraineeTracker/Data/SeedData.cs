using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using TraineeTracker.Models;
using System.Diagnostics.CodeAnalysis;
using static TraineeTracker.Models.SkillsEnum;
using TraineeTracker.Data.Migrations;

namespace TraineeTracker.Data
{
    [ExcludeFromCodeCoverage]
    public class SeedData
    {
        private static Tracker GetDefaultTracker(int week)
        {
            return new Tracker()
            {
                Stop = "Something bad",
                Start = "Something good",
                Continue = "That thing I'm good at!",
                Week = week,
                ConsultantSkills = SkillsRank.Low_Skilled,
                TechnicalSkills = SkillsRank.Skilled
            };
        }
        private static void AddGenericTracker(UserData user, int week) => user.Trackers!.Add(GetDefaultTracker(week));

        private static void AddGenericTrackers(UserData user)
        {
            for(int i = 1; i < 8; i++)
            {
                AddGenericTracker(user, i);
            }
        }


        public static void Initialize(IServiceProvider serviceProvider)
        {
            TraineeTrackerContext context = serviceProvider.GetRequiredService<TraineeTrackerContext>();
            UserManager<User> userManager = serviceProvider.GetService<UserManager<User>>()!;
            RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(context);

            context.Database.EnsureCreated();

            if (context.UserDB.Any() || context.TrackerDB.Any() || context.UserDataDB.Any()) return;

            var trainer = new IdentityRole { Name = "Trainer", NormalizedName = "Trainer" };
            var trainee = new IdentityRole { Name = "Trainee", NormalizedName = "Trainee" };
            var admin = new IdentityRole { Name = "Admin", NormalizedName = "Admin" };

            roleStore.CreateAsync(trainer).GetAwaiter().GetResult();
            roleStore.CreateAsync(trainee).GetAwaiter().GetResult();
            roleStore.CreateAsync(admin).GetAwaiter().GetResult();

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
                    RoleId = roleStore.GetRoleIdAsync(admin).GetAwaiter().GetResult()
                },
                new IdentityUserRole<string>
                {
                    UserId = userManager.GetUserIdAsync(adam).GetAwaiter().GetResult(),
                    RoleId = roleStore.GetRoleIdAsync(trainee).GetAwaiter().GetResult()
                },
                new IdentityUserRole<string>
                {
                    UserId = userManager.GetUserIdAsync(lewis).GetAwaiter().GetResult(),
                    RoleId = roleStore.GetRoleIdAsync(trainee).GetAwaiter().GetResult()
                }

            };
             
            context.UserRoles.AddRange(userRoles);
            context.SaveChanges();

            UserData userDataPhil = new UserData()
            { 
                Title = "Mr.",
                FirstName = "Phil",
                LastName = "Phil",
                Activity = "C#",
                UserID = userManager.GetUserIdAsync(phil).GetAwaiter().GetResult(),
                Roles = UserData.Level.Trainer
            };
            UserData userDataPeter = new UserData()
            {
                Title = "Mr.",
                FirstName = "Peter",
                LastName = "Bellaby",
                Activity = "C#",
                UserID = userManager.GetUserIdAsync(peter).GetAwaiter().GetResult(),
                Roles = UserData.Level.Trainer
            };
            UserData userDataNish = new UserData()
            {
                Title = "Mr.",
                FirstName = "Nishant",
                LastName = "Mandal",
                Activity = "C#",
                UserID = userManager.GetUserIdAsync(nish).GetAwaiter().GetResult(),
                Roles = UserData.Level.Trainer
            };
            
            UserData userDataSerg = new UserData()
            {
                Title = "Mr.",
                FirstName = "Sergiusz",
                LastName = "Pietrala",
                Activity = "C#",
                UserID = userManager.GetUserIdAsync(serg).GetAwaiter().GetResult(),
                Roles = UserData.Level.Trainee
            };
            UserData userDataAdam = new UserData()
            {
                Title = "Mr.",
                FirstName = "Adam",
                LastName = "Millard",
                Activity = "C#",
                UserID = userManager.GetUserIdAsync(adam).GetAwaiter().GetResult(),
                Roles = UserData.Level.Trainee
            };
            UserData userDataLewis = new UserData()
            {
                Title = "Mr.",
                FirstName = "Lewis",
                LastName = "Kellett",
                Activity = "C#",
                UserID = userManager.GetUserIdAsync(lewis).GetAwaiter().GetResult(),
                Roles = UserData.Level.Trainee
            };

            UserData userDataAdmin = new UserData()
            {
                Title = "Mr.",
                FirstName = "Admin",
                LastName = "Admin",
                Activity = "C#",
                UserID = userManager.GetUserIdAsync(lewis).GetAwaiter().GetResult(),
                Roles = UserData.Level.Admin
            };


            AddGenericTrackers(userDataSerg);
            AddGenericTrackers(userDataAdam);
            AddGenericTrackers(userDataLewis);

            phil.UserData = userDataPhil;
            peter.UserData = userDataPeter;
            adam.UserData = userDataAdam;
            serg.UserData = userDataSerg;
            lewis.UserData = userDataLewis; 
            nish.UserData = userDataNish;

           
            context.UserDataDB.Add(userDataPhil);
            context.UserDataDB.Add(userDataPeter);
            context.UserDataDB.Add(userDataNish);
            context.UserDataDB.Add(userDataLewis);
            context.UserDataDB.Add(userDataAdam);
            context.SaveChanges();
        }
    }
}
