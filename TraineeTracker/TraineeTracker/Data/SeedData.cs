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

            var adminUser = new User { UserName = "Admin@SpartaGlobal.com", Email = "Admin@SpartaGlobal.com", EmailConfirmed = true };
            
            var phil = new User { UserName = "Phil@SpartaGlobal.com", Email = "Phil@SpartaGlobal.com", EmailConfirmed = true };
            var peter = new User { UserName = "Peter@SpartaGlobal.com", Email = "Peter@SpartaGlobal.com", EmailConfirmed = true };
            var nish = new User { UserName = "Nish@SpartaGlobal.com", Email = "Nish@SpartaGlobal.com", EmailConfirmed = true };
            var serg = new User { UserName = "Serg@SpartaGlobal.com", Email = "Serg@SpartaGlobal.com", EmailConfirmed = true };
            var adam = new User { UserName = "Adam@SpartaGlobal.com", Email = "Adam@SpartaGlobal.com", EmailConfirmed = true };
            var lewis = new User { UserName = "Lewis@SpartaGlobal.com", Email = "Lewis@SpartaGlobal.com", EmailConfirmed = true };

            var cesar = new User { UserName = "Cesar@SpartaGlobal.com", Email = "Cesar@SpartaGlobal.com", EmailConfirmed = true };
            var nathan = new User { UserName = "Nathan@SpartaGlobal.com", Email = "Nathan@SpartaGlobal.com", EmailConfirmed = true };
            var max = new User { UserName = "Max@SpartaGlobal.com", Email = "Max@SpartaGlobal.com", EmailConfirmed = true };
            var rahul = new User { UserName = "Rahul@SpartaGlobal.com", Email = "Rahul@SpartaGlobal.com", EmailConfirmed = true };
            var ameer = new User { UserName = "Ameer@SpartaGlobal.com", Email = "Ameer@SpartaGlobal.com", EmailConfirmed = true };
            var sahil = new User { UserName = "Sahil@SpartaGlobal.com", Email = "Sahil@SpartaGlobal.com", EmailConfirmed = true };

            userManager.CreateAsync(adminUser, "Password1!").GetAwaiter().GetResult();

            userManager.CreateAsync(phil, "Password1!").GetAwaiter().GetResult();
            userManager.CreateAsync(peter, "Password1!").GetAwaiter().GetResult();
            userManager.CreateAsync(nish, "Password1!").GetAwaiter().GetResult();

            userManager.CreateAsync(serg, "Password1!").GetAwaiter().GetResult();
            userManager.CreateAsync(adam, "Password1!").GetAwaiter().GetResult();

            userManager.CreateAsync(cesar, "Password1!").GetAwaiter().GetResult();
            userManager.CreateAsync(nathan, "Password1!").GetAwaiter().GetResult();
            userManager.CreateAsync(max, "Password1!").GetAwaiter().GetResult();
            userManager.CreateAsync(rahul, "Password1!").GetAwaiter().GetResult();
            userManager.CreateAsync(ameer, "Password1!").GetAwaiter().GetResult();
            userManager.CreateAsync(sahil, "Password1!").GetAwaiter().GetResult();


            IdentityUserRole<string>[] userRoles = new IdentityUserRole<string>[]
            {
                new IdentityUserRole<string>
                {
                    UserId = userManager.GetUserIdAsync(phil).GetAwaiter().GetResult(),
                    RoleId = roleStore.GetRoleIdAsync(trainer).GetAwaiter().GetResult()
                },
                new IdentityUserRole<string>
                {
                    UserId = userManager.GetUserIdAsync(peter).GetAwaiter().GetResult(),
                    RoleId = roleStore.GetRoleIdAsync(trainer).GetAwaiter().GetResult()
                },
                new IdentityUserRole<string>
                {
                    UserId = userManager.GetUserIdAsync(nish).GetAwaiter().GetResult(),
                    RoleId = roleStore.GetRoleIdAsync(trainer).GetAwaiter().GetResult()
                },
                 new IdentityUserRole<string>
                {
                    UserId = userManager.GetUserIdAsync(adminUser).GetAwaiter().GetResult(),
                    RoleId = roleStore.GetRoleIdAsync(admin).GetAwaiter().GetResult()
                },

                new IdentityUserRole<string>
                {
                    UserId = userManager.GetUserIdAsync(adam).GetAwaiter().GetResult(),
                    RoleId = roleStore.GetRoleIdAsync(trainee).GetAwaiter().GetResult()
                },
                new IdentityUserRole<string>
                {
                    UserId = userManager.GetUserIdAsync(max).GetAwaiter().GetResult(),
                    RoleId = roleStore.GetRoleIdAsync(trainee).GetAwaiter().GetResult()
                },
                new IdentityUserRole<string>
                {
                    UserId = userManager.GetUserIdAsync(nathan).GetAwaiter().GetResult(),
                    RoleId = roleStore.GetRoleIdAsync(trainee).GetAwaiter().GetResult()
                },
                new IdentityUserRole<string>
                {
                    UserId = userManager.GetUserIdAsync(rahul).GetAwaiter().GetResult(),
                    RoleId = roleStore.GetRoleIdAsync(trainee).GetAwaiter().GetResult()
                },
                new IdentityUserRole<string>
                {
                    UserId = userManager.GetUserIdAsync(ameer).GetAwaiter().GetResult(),
                    RoleId = roleStore.GetRoleIdAsync(trainee).GetAwaiter().GetResult()
                },
                new IdentityUserRole<string>
                {
                    UserId = userManager.GetUserIdAsync(serg).GetAwaiter().GetResult(),
                    RoleId = roleStore.GetRoleIdAsync(trainee).GetAwaiter().GetResult()
                },
                new IdentityUserRole<string>
                {
                    UserId = userManager.GetUserIdAsync(sahil).GetAwaiter().GetResult(),
                    RoleId = roleStore.GetRoleIdAsync(trainee).GetAwaiter().GetResult()
                },
                new IdentityUserRole<string>
                {
                    UserId = userManager.GetUserIdAsync(cesar).GetAwaiter().GetResult(),
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
            UserData userDataNathan = new UserData()
            {
                Title = "Mr.",
                FirstName = "Nathan",
                LastName = "Bird",
                Activity = "C#",
                UserID = userManager.GetUserIdAsync(nathan).GetAwaiter().GetResult(),
                Roles = UserData.Level.Trainee
            };
            UserData userDataMax = new UserData()
            {
                Title = "Mr.",
                FirstName = "Max",
                LastName = "Odell",
                Activity = "C#",
                UserID = userManager.GetUserIdAsync(max).GetAwaiter().GetResult(),
                Roles = UserData.Level.Trainee
            };
            UserData userDataRahul = new UserData()
            {
                Title = "Mr.",
                FirstName = "Rahul",
                LastName = "Patel",
                Activity = "C#",
                UserID = userManager.GetUserIdAsync(rahul).GetAwaiter().GetResult(),
                Roles = UserData.Level.Trainee
            };
            UserData userDataCesar = new UserData()
            {
                Title = "Mr.",
                FirstName = "Cesar",
                LastName = "Mello",
                Activity = "C#",
                UserID = userManager.GetUserIdAsync(cesar).GetAwaiter().GetResult(),
                Roles = UserData.Level.Trainee
            };
            UserData userDataAmeer = new UserData()
            {
                Title = "Mr.",
                FirstName = "Ameer",
                LastName = "Gardezi",
                Activity = "C#",
                UserID = userManager.GetUserIdAsync(ameer).GetAwaiter().GetResult(),
                Roles = UserData.Level.Trainee
            };
            UserData userDataSahil = new UserData()
            {
                Title = "Mr.",
                FirstName = "Sahil",
                LastName = "Singh",
                Activity = "C#",
                UserID = userManager.GetUserIdAsync(sahil).GetAwaiter().GetResult(),
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

            adminUser.UserData = userDataAdmin;
            phil.UserData = userDataPhil;
            peter.UserData = userDataPeter;
            adam.UserData = userDataAdam;
            serg.UserData = userDataSerg;

            nish.UserData = userDataNish;
            nathan.UserData = userDataNathan;
            max.UserData = userDataMax;
            rahul.UserData = userDataRahul;
            cesar.UserData = userDataCesar;
            ameer.UserData = userDataAmeer;
            sahil.UserData = userDataSahil;

            context.UserDataDB.Add(userDataAdmin);
            context.UserDataDB.Add(userDataPhil);
            context.UserDataDB.Add(userDataPeter);
            context.UserDataDB.Add(userDataNish);
            context.UserDataDB.Add(userDataAdam);
            context.UserDataDB.Add(userDataSerg);
            context.UserDataDB.Add(userDataNathan);
            context.UserDataDB.Add(userDataMax);
            context.UserDataDB.Add(userDataRahul);
            context.UserDataDB.Add(userDataCesar);
            context.UserDataDB.Add(userDataAmeer);
            context.UserDataDB.Add(userDataSahil);
            context.SaveChanges();
        }
    }
}
