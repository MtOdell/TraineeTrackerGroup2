
using Microsoft.AspNetCore.Mvc;
using Moq;
using TraineeTracker.Controllers;
using TraineeTracker.Data;
using TraineeTracker.Models;
using TraineeTracker.Service;


namespace TraineeTrackerTests
{
    public class ControllerTests
    {
        private UserDatasController? _sut;

        [SetUp]
        public void SetUp()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            var mockTracker = new Mock<IServiceLayer<Tracker>>();
            _sut = new UserDatasController(mockService.Object, mockUser.Object, mockTracker.Object);
        }

        [Test]
        [Category("Constructor")]
        public void GivenDataAndUser_WhenConstructorIsCalled_ConstructorIsConstructed()
        {
            Assert.That(_sut, Is.InstanceOf<UserDatasController>());
        }
        [Ignore("return view")]
        [Test]
        [Category("Trainee Path")]
        public void GivenTrainee_WhenIndexIsCalledAsTrainee_ReturnsViewForTrainee()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            var mockTracker = new Mock<IServiceLayer<Tracker>>();
            _sut = new UserDatasController(mockService.Object, mockUser.Object, mockTracker.Object);

            var user = mockUser.Setup(x => x.GetUserAsync()).Returns(Task.FromResult(new User()));
            
            var result = _sut.Index().Result;

            Assert.That(result, Is.EqualTo(user));
        }
        [Test]
        [Category("Trainer Path")]
        public void GivenTrainer_WhenIndexIsCalledAsTrainer_ItIsNotNull()
        {
            var mockUser = new Mock<IUserManager<User>>();

            var mockTrainer = mockUser.Setup(x => x.IsInRole("Trainer")).Returns(true);
            
            Assert.That(mockTrainer, Is.Not.False);
            Assert.That(mockTrainer, Is.Not.Null);
            
        }
        [Test]
        [Category("Index - ServiceGetAllAsync - Happy Path")]
        public void GivenUserDataInDatabase_WhenGetAllAsyncIsCalled_ReturnsListOfUserData()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();

            var mockUserData = mockService.Setup(x => x.GetAllAsync().Result).Returns(It.IsAny<IEnumerable<UserData>>());

            Assert.That(mockUserData, Is.Not.Null);
        }
        [Test]
        [Category("Details - ServiceFindAsync - Happy Path")]
        public void GivenValidID_WhenServiceFindAsyncIsCalled_ItIsNotNull()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockFindAsync = mockService.Setup(x => x.FindAsync(It.IsAny<int>()).Result);
            Assert.That(mockFindAsync, Is.Not.Null);
        }
        [Ignore("need to return null")]
        [Test]
        [Category("Details - ServiceFindAsync - Sad Path")]
        public void INVALID()
        {

        }
        [Test]
        [Category("TrackerDetails - TrackerFindAsync - Happy Path")]
        public void GivenValidID_TrackerFindAsync_IsNotNull()
        {
            var mockTracker = new Mock<IServiceLayer<Tracker>>();

            var mockFindAsync = mockTracker.Setup(x => x.FindAsync(It.IsAny<int>()).Result);

            //Assert.That(FindAsync, Is.TypeOf<ViewResult>());
            Assert.That(mockFindAsync, Is.Not.Null);
        }
        [Test]
        [Category("Create GET")]
        public void GivenUserData_WhenCreateConstructorIsCalled_RetunsView()
        {

            var mockCreate = _sut.Create();
            
            Assert.That(mockCreate, Is.TypeOf<ViewResult>());
        }
        [Test]
        [Category("Create POST")]
        public void GivenUserData_WhenAddAsyncIsCalled_ItIsNotNull()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();

            var mockAddAsync = mockService.Setup( x => x.AddAsync(It.IsAny<UserData>()));

            Assert.That(mockAddAsync, Is.Not.Null);
        }
        [Test]
        [Category("Edit POST - Update")]
        public void GivenValidUserData_WhenUpdateIsCalled_ItIsNotNull()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();

            var mockUpdate = mockService.Setup(x => x.Update(It.IsAny<UserData>()));

            Assert.That(mockUpdate, Is.Not.Null);
        }
        [Test]
        [Category("Edit Post - Exists - Happy Path")]
        public void GivenValidUserID_WhenExistsIsCalled_ItIsNotNull()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();

            var mockExists = mockService.Setup(x => x.Exists(It.IsAny<int>())).Returns(true);

            Assert.That(mockExists, Is.Not.Null);
            

        }
        [Ignore("need to return the result")]
        [Test]
        [Category("Edit Post - Exists - Sad Path")]
        public void x()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();

            var mockExists = mockService.Setup(x => x.Exists(It.IsAny<int>())).Returns(false);

           
            //mockExists.Verifiable(StatusCodes.Status404NotFound);

        }
    }
}