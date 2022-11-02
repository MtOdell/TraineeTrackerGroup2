
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

        [Test]
        [Category("Constructor")]
        public void GivenDataAndUser_WhenConstructorIsCalled_ConstructorIsConstructed()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            var mockTracker = new Mock<IServiceLayer<Tracker>>();
            _sut = new UserDatasController(mockService.Object, mockUser.Object, mockTracker.Object);
            Assert.That(_sut, Is.InstanceOf<UserDatasController>());
        }
        [Test]
        [Category("Trainer Path")]
        public void GivenTrainer_WhenIndexIsCalledAsTrainer_ItIsNotNull()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            var mockTracker = new Mock<IServiceLayer<Tracker>>();

            mockUser.Setup(x => x.IsInRole("Trainer")).Returns(true);
            _sut = new UserDatasController(mockService.Object, mockUser.Object, mockTracker.Object);

            var result = _sut.Index().Result;

            Assert.That(result, Is.Not.False);
            Assert.That(result, Is.Not.Null);
            
        }
        [Test]
        [Category("Trainer Path")]
        public void GivenTrainee_WhenIndexIsCalledAsTrainee_ItIsNotNull()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            var mockTracker = new Mock<IServiceLayer<Tracker>>();

            mockUser.Setup(x => x.IsInRole("Trainee")).Returns(true);
            _sut = new UserDatasController(mockService.Object, mockUser.Object, mockTracker.Object);

            var result = _sut.Index().Result;

            Assert.That(result, Is.Not.False);
            Assert.That(result, Is.Not.Null);

        }
        [Test]
        [Category("Index - ServiceGetAllAsync - Happy Path")]
        public void GivenUserDataInDatabase_WhenGetAllAsyncIsCalled_ReturnsListOfUserData()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            var mockTracker = new Mock<IServiceLayer<Tracker>>();

            mockService.Setup(x => x.GetAllAsync().Result);
            _sut = new UserDatasController(mockService.Object, mockUser.Object, mockTracker.Object);

            var result = _sut.Index().Result;

            Assert.That(result, Is.Not.Null);
        }
        [Test]
        [Category("Details - ServiceFindAsync - Happy Path")]
        public void GivenValidID_WhenServiceFindAsyncIsCalled_ItIsNotNull()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            var mockTracker = new Mock<IServiceLayer<Tracker>>();

            mockService.Setup(x => x.FindAsync(It.IsAny<int>()).Result);
            _sut = new UserDatasController(mockService.Object, mockUser.Object, mockTracker.Object);

            var result = _sut.Details(1).Result;

            Assert.That(result, Is.Not.Null);
            
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
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            var mockTracker = new Mock<IServiceLayer<Tracker>>();

            mockTracker.Setup(x => x.FindAsync(It.IsAny<int>()).Result);
            _sut = new UserDatasController(mockService.Object, mockUser.Object, mockTracker.Object);

            var result = _sut.TrackerDetails(1).Result;

            //Assert.That(FindAsync, Is.TypeOf<ViewResult>());
            Assert.That(result, Is.Not.Null);
        }
        [Test]
        [Category("Create GET")]
        public void GivenUserData_WhenCreateConstructorIsCalled_RetunsView()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            var mockTracker = new Mock<IServiceLayer<Tracker>>();
            
            _sut = new UserDatasController(mockService.Object, mockUser.Object, mockTracker.Object);
            
            var result = _sut.Create();
            
            Assert.That(result, Is.TypeOf<ViewResult>());
        }
        [Test]
        [Category("Create POST")]
        public void GivenUserData_WhenAddAsyncIsCalled_ItIsNotNull()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            var mockTracker = new Mock<IServiceLayer<Tracker>>();

            mockService.Setup( x => x.AddAsync(It.IsAny<UserData>()));
            _sut = new UserDatasController(mockService.Object, mockUser.Object, mockTracker.Object);

            var data = new UserData { FirstName = It.IsAny<string>(), LastName = It.IsAny<string>(), Title = It.IsAny<string>(), Education = It.IsAny<string>(), Experience = It.IsAny<string>(), Activity = It.IsAny<string>(), Biography = It.IsAny<string>(), Skills = It.IsAny<string>(), ID = 1, UserID = It.IsAny<string>(), Roles = UserData.Level.Trainee };
            var result = _sut.Create(data).Result;
            
            Assert.That(result, Is.Not.Null);
        }
        [Test]
        [Category("Edit POST - Update")]
        public void GivenValidUserData_WhenUpdateIsCalled_ItIsNotNull()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            var mockTracker = new Mock<IServiceLayer<Tracker>>();

            mockService.Setup(x => x.Update(It.IsAny<UserData>()));
            _sut = new UserDatasController(mockService.Object, mockUser.Object, mockTracker.Object);

            var data = new UserData { FirstName = It.IsAny<string>(), LastName = It.IsAny<string>(), Title = It.IsAny<string>(), Education = It.IsAny<string>(), Experience = It.IsAny<string>(), Activity = It.IsAny<string>(), Biography = It.IsAny<string>(), Skills = It.IsAny<string>(), ID = 1, UserID = It.IsAny<string>(), Roles = UserData.Level.Trainee };
            var result = _sut.Edit(1, data).Result;
            
            Assert.That(result, Is.Not.Null);

            //mockService.Verify(x => x.Update(It.IsAny<UserData>()), Times.Once);
            
        }
        [Test]
        [Category("Edit Post - Exists - Happy Path")]
        public void GivenValidUserID_WhenExistsIsCalled_ItIsNotNull()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            var mockTracker = new Mock<IServiceLayer<Tracker>>();
                        
            mockService.Setup(x => x.Exists(It.IsAny<int>()));
            _sut = new UserDatasController(mockService.Object, mockUser.Object, mockTracker.Object);

            var data = new UserData { FirstName = It.IsAny<string>(), LastName = It.IsAny<string>(), Title = It.IsAny<string>(), Education = It.IsAny<string>(), Experience = It.IsAny<string>(), Activity = It.IsAny<string>(), Biography = It.IsAny<string>(), Skills = It.IsAny<string>(), ID = 1, UserID = It.IsAny<string>(), Roles = UserData.Level.Trainee };
            var result = _sut.Edit(1, data).Result;
            
            Assert.That(result, Is.Not.Null);
            


        }
        [Ignore("WIP")]
        [Test]
        [Category("Edit Post - Exists - Sad Path")]
        public void x()
        {
            //var mockService = new Mock<IServiceLayer<UserData>>();

            //var mockExists = mockService.Setup(x => x.Exists(It.IsAny<int>())).Returns(false);

           
            //mockExists.Verifiable(StatusCodes.Status404NotFound);

        }
    }
}