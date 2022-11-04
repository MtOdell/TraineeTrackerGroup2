namespace TraineeTrackerTests.ServiceLayerTests
{
    using TraineeTracker.Service;
    using System;
    using NUnit.Framework;
    using Moq;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using TraineeTracker.Models;
    using Microsoft.Extensions.Options;
    using System.Collections.Generic;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;
    using System.Security.Claims;

    [TestFixture]
    public class UserManagerTests
    {
        [Test]
        public async Task CanCallGetUserAsync()
        {
            var httpContextAccessor = new Mock<IHttpContextAccessor>();
            var userManager = new Mock<UserManager<User>>(
                new Mock<IUserStore<User>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<IPasswordHasher<User>>().Object,
                new[] { new Mock<IUserValidator<User>>().Object,
                    new Mock<IUserValidator<User>>().Object,
                    new Mock<IUserValidator<User>>().Object },
                new[] { new Mock<IPasswordValidator<User>>().Object,
                    new Mock<IPasswordValidator<User>>().Object,
                    new Mock<IPasswordValidator<User>>().Object },
                new Mock<ILookupNormalizer>().Object, new IdentityErrorDescriber(),
                new Mock<IServiceProvider>().Object,
                new Mock<ILogger<UserManager<User>>>().Object);

            userManager.Setup(x => x.GetUserAsync(It.IsAny<ClaimsPrincipal>())).Returns(Task.FromResult(new User() { Email = "aaaa" }));
            httpContextAccessor.Setup(mock => mock.HttpContext).Returns(new DefaultHttpContext());
            var testClass = new UserManager(httpContextAccessor.Object, userManager.Object);
            // Act
            var result = await testClass.GetUserAsync();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Email, Is.EqualTo("aaaa"));
        }

        [Test]
        public async Task GetUserByIdAsync_ReturnsExpected()
        {
            var httpContextAccessor = new Mock<IHttpContextAccessor>();
            var userManager = new Mock<UserManager<User>>(
                new Mock<IUserStore<User>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<IPasswordHasher<User>>().Object,
                new[] { new Mock<IUserValidator<User>>().Object,
                    new Mock<IUserValidator<User>>().Object,
                    new Mock<IUserValidator<User>>().Object },
                new[] { new Mock<IPasswordValidator<User>>().Object,
                    new Mock<IPasswordValidator<User>>().Object,
                    new Mock<IPasswordValidator<User>>().Object },
                new Mock<ILookupNormalizer>().Object, new IdentityErrorDescriber(),
                new Mock<IServiceProvider>().Object,
                new Mock<ILogger<UserManager<User>>>().Object);

            userManager.Setup(x => x.FindByIdAsync(It.IsAny<string>())).Returns(Task.FromResult(new User() { Id = "aaaa" }));
            httpContextAccessor.Setup(mock => mock.HttpContext).Returns(new DefaultHttpContext());
            var testClass = new UserManager(httpContextAccessor.Object, userManager.Object);
            // Act
            var result = await testClass.GetUserByIdAsync("AAAA");

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo("aaaa"));
        }

    }
}