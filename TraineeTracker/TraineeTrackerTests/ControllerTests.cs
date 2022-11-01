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
        public void UserDatasController_CanBe_Constructed()
        {
        var mockService = new Mock<TraineeTrackerContext>(null);
        _sut = new UserDatasController(mockService.Object);
        Assert.That(_sut, Is.InstanceOf<UserDatasController>());
        }
    }
}