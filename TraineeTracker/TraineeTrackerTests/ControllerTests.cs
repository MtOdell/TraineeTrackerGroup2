using Microsoft.AspNetCore.Identity;
using Moq;
using TraineeTracker.Controllers;
using TraineeTracker.Data;
using TraineeTracker.Models;
using TraineeTracker.Service;

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
            var mockService = new Mock<IServiceLayer<UserData>>(null);
            var mockUser = new Mock<IUserManager<User>>(null);
            _sut = new UserDatasController(mockService.Object, mockUser.Object);
            //Assert.That();
        }

    }
}