using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;
using System.Text.Json;
using TraineeTracker.Data;
using TraineeTracker.Models;
using TraineeTracker.Security.Authentication;
using TraineeTracker.Security.Authorization;
using TraineeTracker.Service;
using Microsoft.AspNetCore.Builder;
using TraineeTracker.Swagger;

namespace TraineeTracker
{
    [ExcludeFromCodeCoverage]

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<TraineeTrackerContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddControllersWithViews();

            builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<TraineeTrackerContext>();

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<IServiceLayer<Tracker>, TrackerService>();
            builder.Services.AddScoped<IServiceLayer<UserData>, UserDataService>();
            builder.Services.AddScoped<IUserManager<User>, UserManager>();

            builder.Services.AddAuthentication(options => 
            { 
                options.DefaultAuthenticateScheme = ApiKeyAuthenticationOptions.DefaultScheme;
                options.DefaultChallengeScheme = ApiKeyAuthenticationOptions.DefaultScheme;
            }).AddApiKeySupport(options => { });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.OnlyTrainee, policy => policy.Requirements.Add(new OnlyTraineesRequirement()));
                options.AddPolicy(Policies.OnlyTrainer, policy => policy.Requirements.Add(new OnlyTrainersRequirement()));
                options.AddPolicy(Policies.OnlyAdmin, policy => policy.Requirements.Add(new OnlyAdminRequirement()));
            });

            builder.Services.AddSingleton<IAuthorizationHandler, OnlyTraineesAuthorizationHandler>();
            builder.Services.AddSingleton<IAuthorizationHandler, OnlyTrainersAuthorizationHandler>();
            builder.Services.AddSingleton<IAuthorizationHandler, OnlyAdminAuthorizationHandler>();

            builder.Services.AddSingleton<IGetApiKeyQuery, InMemoryGetApiKeyQuery>();

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                });

            builder.Services.ConfigureSwaggerFeature();

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                SeedData.Initialize(services);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Trainee Tracker");
            });
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}