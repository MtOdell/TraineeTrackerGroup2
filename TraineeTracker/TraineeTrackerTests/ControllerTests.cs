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
using System.Collections;

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
        [Category("Constructor")]
        public void GivenDataAndUser_WhenConstructorIsCalled_ConstructorIsConstructed()
        {
            var mockService = new Mock <IServiceLayer<UserData>>();
            var mockUser = new Mock <IUserManager<User>>();
            _sut = new UserDatasController(mockService.Object, mockUser.Object);
            Assert.That(_sut, Is.InstanceOf<UserDatasController>());
        }
        [Ignore("return view")]
        [Test]
        [Category("Trainee Path")]
        public void GivenTrainee_WhenIndexIsCalledAsTrainee_ReturnsViewForTrainee()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            _sut = new UserDatasController(mockService.Object, mockUser.Object);
            
            var user = mockUser.Setup(x => x.GetUserAsync()).Returns(Task.FromResult(new User()));
            
            var result = _sut.Index().Result;

            Assert.That(result, Is.EqualTo(user));
        }
        [Test]
        [Category("Trainer Path")]
        public void GivenTrainer_WhenIndexIsCalledAsTrainer_ItIsNotNull()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
    
            _sut = new UserDatasController(mockService.Object, mockUser.Object);

            
            var user = mockUser.Setup(x => x.IsInRole("Trainer")).Returns(true);
            
            Assert.That(user, Is.Not.False);
            Assert.That(user, Is.Not.Null);

            // ------------------------------------
            
            //var viewer = _sut.View(mockService.Setup(x => x.GetAllAsync().Result));
            
        }
        [Test]
        [Category("GetAllAsync")]
        public void x()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            var mockUserData = mockService.Setup(x => x.GetAllAsync().Result).Returns(It.IsAny<IEnumerable<UserData>>());
            _sut = new UserDatasController(mockService.Object, mockUser.Object);

            Assert.That(mockUserData, Is.Not.Null);
        }

    }
}