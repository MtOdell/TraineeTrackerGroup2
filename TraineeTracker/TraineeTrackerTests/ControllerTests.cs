using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;
using System.Security.Principal;
using TraineeTracker.Controllers;
using TraineeTracker.Data;
using TraineeTracker.Models;
using TraineeTracker.Service;
using System.Security.Claims;

namespace TraineeTrackerTests
{
    public class Tests
    {
    //    [SetUp]
    //    public void Setup()
    //    {

    //    }
    private UserDatasController? _sut;

        [Test]
        [Category("Happy Path")]
        public void GivenDataAndUser_WhenConstructorIsCalled_ConstructorIsConstructed()
        {
            var mockService = new Mock <IServiceLayer<UserData>>();
            var mockUser = new Mock <IUserManager<User>>();
            _sut = new UserDatasController(mockService.Object, mockUser.Object);
            Assert.That(_sut, Is.InstanceOf<UserDatasController>());
        }

        [Test]
        [Category("Sad Path")]
        public void GivenUserData_WhenIndexIsCalledAsTrainee_ReturnsViewOfAllUserData()
        {
            
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            //var fackPrinciple = new Mock<IPrincipal>();
            
            // Setup fack data
             //var cool = fackPrinciple.Setup(e => e.IsInRole("Trainee")).Returns(true);

            mockUser.Setup(x => x.GetUserAsync()).Returns(Task.FromResult(new User()));
            // Assign to current thread principle
            //Thread.CurrentPrincipal = fackPrinciple.Object;

            _sut = new UserDatasController(mockService.Object, mockUser.Object);

            var result = _sut.Index().Result;

            //Assert.That(cool, Is.EqualTo(result));
            
            //var principal = new Mock<IPrincipal>();
            //principal.Setup(p => p.IsInRole("Trainee")).Returns(true);
            ////principal.SetupGet(x => x.Identity.Name).Returns(It.IsAny<string>);
            //_sut.SetupGet(x => x.HttpContext.User).Returns(principal.Object);
        }

    }
}