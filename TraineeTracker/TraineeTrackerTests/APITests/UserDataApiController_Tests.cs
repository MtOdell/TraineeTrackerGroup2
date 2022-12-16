
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Xml.Linq;
using TraineeTracker.Controllers.API;
using TraineeTracker.Data;
using TraineeTracker.Models;
using TraineeTracker.Models.ViewModels;
using TraineeTracker.Service;


namespace TraineeTrackerTests.APITests
{
    public class UserDataApiController_Tests
    {
        [Test]
        [Category("Constructor")]
        [Category("Happy Path")]
        public void WhenConstructorIsCalled_ObjectIsConstructed()
        {
            var mockUser = new Mock<IServiceLayer<UserData>>();
            var mockTracker = new Mock<IServiceLayer<Tracker>>();

            var _sut = new UserDatasController(mockUser.Object, mockTracker.Object);
            Assert.That(_sut, Is.Not.Null);
            Assert.That(_sut, Is.InstanceOf<UserDatasController>());
        }

        [Test]
        [Category("GetUserData Path")]
        [Category("Sad Path")]
        public void WhenGetUserDataIsCalled_WithInvalid_Data_ReturnsExpected()
        {
            var mockUser = new Mock<IServiceLayer<UserData>>();
            var mockTracker = new Mock<IServiceLayer<Tracker>>();

            mockUser.Setup(x => x.FindAsync(It.IsAny<int>()))
                .Returns(Task.FromResult((UserData)null!)!);   

            var _sut = new UserDatasController(mockUser.Object, mockTracker.Object);

            var result = _sut.GetUserData(It.IsAny<int>()).Result.Result;

            mockUser.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        [Category("GetUserData Path")]
        [Category("Happy Path")]
        public void WhenGetUserDataIsCalled_WithValid_Data_ReturnsExpected()
        {
            var mockUser = new Mock<IServiceLayer<UserData>>();
            var mockTracker = new Mock<IServiceLayer<Tracker>>();

            mockUser.Setup(x => x.FindAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(new UserData())!);

            var _sut = new UserDatasController(mockUser.Object, mockTracker.Object);

            var result = _sut.GetUserData(It.IsAny<int>()).Result.Value;

            mockUser.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<UserDataViewModel>());
        }

        [Test]
        [Category("UpdateUserData Path")]
        [Category("Sad Path")]
        public void WhenUpdateUserDataIsCalled_MismatchIds_Data_ReturnsExpected()
        {
            var mockUser = new Mock<IServiceLayer<UserData>>();
            var mockTracker = new Mock<IServiceLayer<Tracker>>();

            mockUser.Setup(x => x.FindAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(new UserData() { ID = 123 })!);
            mockUser.Setup(x => x.Update(It.IsAny<UserData>()));
            mockUser.Setup(x => x.SaveChangesAsync());

            var _sut = new UserDatasController(mockUser.Object, mockTracker.Object);

            var result = _sut.UpdateUserData(It.IsAny<int>(), new UserDataViewModel() { ID = 123 }).Result;

            mockUser.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<BadRequestResult>());
        }

        [Test]
        [Category("UpdateUserData Path")]
        [Category("Happy Path")]
        public void WhenUpdateUserDataIsCalled_WithValid_Data_ReturnsExpected()
        {
            var mockUser = new Mock<IServiceLayer<UserData>>();
            var mockTracker = new Mock<IServiceLayer<Tracker>>();

            mockUser.Setup(x => x.FindAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(new UserData() { ID=123})!);
            mockUser.Setup(x => x.Update(It.IsAny<UserData>()));
            mockUser.Setup(x => x.SaveChangesAsync());

            var _sut = new UserDatasController(mockUser.Object, mockTracker.Object);

            var result = _sut.UpdateUserData(123, new UserDataViewModel() { ID = 123 }).Result;

            mockUser.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Once);
            mockUser.Verify(x => x.Update(It.IsAny<UserData>()), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<NoContentResult>());
        }

        [Test]
        [Category("UpdateUserData Path")]
        [Category("Sad Path")]
        public void WhenUpdateUserDataIsCalled_SaveChangesAsync_Throws_Catches()
        {
            var mockUser = new Mock<IServiceLayer<UserData>>();
            var mockTracker = new Mock<IServiceLayer<Tracker>>();

            mockUser.Setup(x => x.FindAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(new UserData() { ID = 123 })!);
            mockUser.Setup(x => x.Update(It.IsAny<UserData>()));
            mockUser.Setup(x => x.Exists(It.IsAny<int>()))
                .Returns(false);
            mockUser.Setup(x => x.SaveChangesAsync())
                .Throws<DbUpdateConcurrencyException>();

            var _sut = new UserDatasController(mockUser.Object, mockTracker.Object);

            var result = _sut.UpdateUserData(123, new UserDataViewModel() { ID = 123 }).Result;

            mockUser.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Once);
            mockUser.Verify(x => x.Update(It.IsAny<UserData>()), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        [Category("UpdateUserData Path")]
        [Category("Sad Path")]
        public void WhenUpdateUserDataIsCalled_SaveChangesAsync_Throws()
        {
            var mockUser = new Mock<IServiceLayer<UserData>>();
            var mockTracker = new Mock<IServiceLayer<Tracker>>();

            mockUser.Setup(x => x.FindAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(new UserData() { ID = 123 })!);
            mockUser.Setup(x => x.Update(It.IsAny<UserData>()));
            mockUser.Setup(x => x.Exists(It.IsAny<int>()))
                .Returns(true);
            mockUser.Setup(x => x.SaveChangesAsync())
                .Throws<DbUpdateConcurrencyException>();

            var _sut = new UserDatasController(mockUser.Object, mockTracker.Object);

            Assert.Throws<DbUpdateConcurrencyException>(() => 
            { 
                _sut.UpdateUserData(123, new UserDataViewModel() { ID = 123 }).GetAwaiter().GetResult(); 
            });

            mockUser.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Once);
            mockUser.Verify(x => x.Exists(It.IsAny<int>()), Times.Once);
            mockUser.Verify(x => x.Update(It.IsAny<UserData>()), Times.Once);
        }

        [Test]
        [Category("DeleteUserData Path")]
        [Category("Sad Path")]
        public void WhenDeleteUserDataIsCalled_WithInvalidId_Returns_NotFound()
        {
            var mockUser = new Mock<IServiceLayer<UserData>>();
            var mockTracker = new Mock<IServiceLayer<Tracker>>();

            mockUser.Setup(x => x.FindAsync(It.IsAny<int>()))
                .Returns(Task.FromResult((UserData)null!)!);

            mockUser.Setup(x => x.RemoveAsync(It.IsAny<UserData>()));

            var _sut = new UserDatasController(mockUser.Object, mockTracker.Object);

            var result = _sut.DeleteUserData(123).Result;

            mockUser.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }
        [Test]
        [Category("DeleteUserData Path")]
        [Category("Happy Path")]
        public void WhenDeleteUserDataIsCalled_WithValidId_Returns_NoContent()
        {
            var mockUser = new Mock<IServiceLayer<UserData>>();
            var mockTracker = new Mock<IServiceLayer<Tracker>>();

            mockUser.Setup(x => x.FindAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(new UserData() { ID = 123 })!);

            mockUser.Setup(x => x.RemoveAsync(It.IsAny<UserData>()));


            var _sut = new UserDatasController(mockUser.Object, mockTracker.Object);

            var result = _sut.DeleteUserData(123).Result;

            mockUser.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Once);
            mockUser.Verify(x => x.RemoveAsync(It.IsAny<UserData>()), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<NoContentResult>());
        }

        [Test]
        [Category("PostUserData Path")]
        [Category("Happy Path")]
        public void WhenPostUserDataIsCalled_WithValid_Data_ReturnsExpected()
        {
            var mockUser = new Mock<IServiceLayer<UserData>>();
            var mockTracker = new Mock<IServiceLayer<Tracker>>();

            mockUser.Setup(x => x.AddAsync(It.IsAny<UserData>()));

            var _sut = new UserDatasController(mockUser.Object, mockTracker.Object);

            var result = _sut.PostUserData(new UserData() { ID=123}).Result.Result;

            mockUser.Verify(x => x.AddAsync(It.IsAny<UserData>()), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<CreatedAtActionResult>());
        }

        [Test]
        [Category("GetUserTrackers Path")]
        [Category("Sad Path")]
        public void WhenGetUserTrackersIsCalled_WithInvalid_Data_ReturnsNotFound()
        {
            var mockUser = new Mock<IServiceLayer<UserData>>();
            var mockTracker = new Mock<IServiceLayer<Tracker>>();

            mockTracker.Setup(x => x.GetAllAsync()).Returns(Task.FromResult((IEnumerable<Tracker>)null!));

            var _sut = new UserDatasController(mockUser.Object, mockTracker.Object);

            var result = _sut.GetUserTrackers(1).Result.Result;

            mockTracker.Verify(x => x.GetAllAsync(), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        } 

        [Test]
        [Category("GetUserTrackers Path")]
        [Category("Happy Path")]
        public void WhenGetUserTrackersIsCalled_WithValid_Data_ReturnsExpected()
        {
            var mockUser = new Mock<IServiceLayer<UserData>>();
            var mockTracker = new Mock<IServiceLayer<Tracker>>();
            IEnumerable<Tracker> data = new List<Tracker>();

            mockTracker.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(data));

            var _sut = new UserDatasController(mockUser.Object, mockTracker.Object);

            var result = _sut.GetUserTrackers(1).Result.Result;

            mockTracker.Verify(x => x.GetAllAsync(), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        [Category("GetAll Path")]
        [Category("Happy Path")]
        public void WhenGetAllIsCalled_WithValid_Data_ReturnsExpected()
        {
            var mockUser = new Mock<IServiceLayer<UserData>>();
            var mockTracker = new Mock<IServiceLayer<Tracker>>();
            IEnumerable<UserData> data = new List<UserData>();

            mockUser.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(data));

            var _sut = new UserDatasController(mockUser.Object, mockTracker.Object);

            var result = _sut.GetAll().Result.Result;

            mockUser.Verify(x => x.GetAllAsync(), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

      /*  [Test]
        [Category("GetUserData Path")]
        [Category("Sad Path")]
        public void WhenGetUserData_Query_IsCalled_WithInvalid_Data_ReturnsExpected()
        {
            var mockUser = new Mock<IServiceLayer<UserData>>();
            var mockTracker = new Mock<IServiceLayer<Tracker>>();
            IEnumerable<UserData> data = new List<UserData>();

            mockUser.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(data));

            var _sut = new UserDatasController(mockUser.Object, mockTracker.Object);

            var result = _sut.GetUserData(new SearchCriteria()).Result.Result;

            mockUser.Verify(x => x.GetAllAsync(), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }*/

        /*[Test]
        [Category("GetUserData Path")]
        [Category("Sad Path")]
        public void WhenGetUserData_Query_IsCalled_WithInvalid_Data_ActivityBranch_ReturnsExpected()
        {
            var mockUser = new Mock<IServiceLayer<UserData>>();
            var mockTracker = new Mock<IServiceLayer<Tracker>>();
            IEnumerable<UserData> data = new List<UserData>()
            { new UserData() { FirstName = "ddddd", LastName = "A", Activity = "A" } };

            mockUser.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(data));

            var _sut = new UserDatasController(mockUser.Object, mockTracker.Object);

            var result = _sut.GetUserData(new SearchCriteria() { Name = "A",Activity="V" }).Result.Result;

            mockUser.Verify(x => x.GetAllAsync(), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }
*/

        [Test]
        [Category("GetUserData Path")]
        [Category("Happy Path")]
        public void WhenGetUserData_Query_IsCalled_WithValid_Data_ReturnsExpected()
        {
            var mockUser = new Mock<IServiceLayer<UserData>>();
            var mockTracker = new Mock<IServiceLayer<Tracker>>();
            IEnumerable<UserData> data = new List<UserData>()
            { new UserData() {FirstName = "A",LastName = "A",Activity = "A"} };
             
            mockUser.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(data));
            
            var _sut = new UserDatasController(mockUser.Object, mockTracker.Object);

            var result = _sut.GetUserData(new SearchCriteria() { Name = "A" , Activity = "A" }).Result.Result;

            mockUser.Verify(x => x.GetAllAsync(), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }
    }
}
