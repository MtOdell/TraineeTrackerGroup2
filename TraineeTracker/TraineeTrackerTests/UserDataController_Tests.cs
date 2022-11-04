
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Moq;
using TraineeTracker.Controllers;
using TraineeTracker.Data;
using TraineeTracker.Models;
using TraineeTracker.Models.ViewModels;
using TraineeTracker.Service;


namespace TraineeTrackerTests
{
    public class UserDataController_Tests
    {
        private UserDatasController? _sut;

        [Test]
        [Category("Constructor")]
        [Category("Happy Path")]
        public void WhenConstructorIsCalled_ObjectIsConstructed()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            _sut = new UserDatasController(mockService.Object, mockUser.Object);
            Assert.That(_sut, Is.Not.Null);
            Assert.That(_sut, Is.InstanceOf<UserDatasController>());
        }

        [Test]
        [Category("Index Path")]
        [Category("Happy Path")]
        public void WhenIndexIsCalledAs_Trainer_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();

            mockUser.Setup(x => x.IsInRole("Trainer")).Returns(true);
            mockUser.Setup(x => x.GetUserAsync()).Returns(Task.FromResult(new User() { Id = "AAA" }));
            mockService.Setup(x => x.GetAllAsync())
                .Returns(Task.FromResult(((IEnumerable<UserData>)new List<UserData>() { new UserData() { UserID = "AAA", Activity = "ABCD" } })));

            _sut = new UserDatasController(mockService.Object, mockUser.Object);

            var result = ((ViewResult)_sut.Index(It.IsAny<string>()).Result).Model;
            List<UserDataViewModel> list = (List<UserDataViewModel>)result!;

            mockUser.Verify(x => x.IsInRole("Trainer"), Times.Once);
            mockUser.Verify(x => x.GetUserAsync(), Times.Once);
            mockService.Verify(x => x.GetAllAsync(), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list[0]!.Activity, Is.EqualTo("ABCD"));
        }

        [Test]
        [Category("Index Path")]
        [Category("Happy Path")]
        public void WhenIndexIsCalledAs_Trainee_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();

            mockUser.Setup(x => x.IsInRole("Trainee")).Returns(true);
            mockUser.Setup(x => x.GetUserAsync()).Returns(Task.FromResult(new User() { Id = "AAA" }));
            mockService.Setup(x => x.GetAllAsync())
                .Returns(Task.FromResult(((IEnumerable<UserData>)new List<UserData>() { new UserData() { UserID = "AAA", Activity = "ABCD" } })));

            _sut = new UserDatasController(mockService.Object, mockUser.Object);

            var result = ((ViewResult)_sut.Index(It.IsAny<string>()).Result).Model;
            List<UserDataViewModel> list = (List<UserDataViewModel>)result!;

            mockUser.Verify(x => x.IsInRole("Trainee"), Times.Once);
            mockUser.Verify(x => x.GetUserAsync(), Times.Once);
            mockService.Verify(x => x.GetAllAsync(), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list[0]!.Activity, Is.EqualTo("ABCD"));
        }

        [Test]
        [Category("Index Path")]
        [Category("Sad Path")]
        public void WhenIndexIsCalledAs_NonExistantRole_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            mockUser.Setup(x => x.IsInRole(It.IsAny<string>())).Returns(false);
            _sut = new UserDatasController(mockService.Object, mockUser.Object);

            var result = ((NoContentResult)_sut.Index(It.IsAny<string>()).Result);
            
            mockUser.Verify(x => x.IsInRole(It.IsAny<string>()), Times.Exactly(3));

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [Category("Details Path")]
        [Category("Sad Path")]
        public void WhenDetailsIsCalledWith_InvalidId_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            //mockService.Setup(x => x.FindAsync(It.IsAny<int>()));
            _sut = new UserDatasController(mockService.Object, mockUser.Object);

            var result = ((NotFoundResult)_sut.Details(null).Result);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [Category("Details Path")]
        [Category("Sad Path")]
        public void WhenDetailsIsCalledWith_NullService_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            mockService.Setup(x => x.IsNull()).Returns(true);
            _sut = new UserDatasController(mockService.Object, mockUser.Object);

            var result = ((NotFoundResult)_sut.Details(null).Result);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [Category("Details Path")]
        [Category("Sad Path")]
        public void WhenDetailsIsCalledWith_NoUserData_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            mockService.Setup(x => x.FindAsync(It.IsAny<int>())).Returns(Task.FromResult((UserData)null!)!);
            _sut = new UserDatasController(mockService.Object, mockUser.Object);

            var result = ((NotFoundResult)_sut.Details(1).Result);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [Category("Details Path")]
        [Category("Sad Path")]
        public void WhenDetailsIsCalledWith_ValidData_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            mockService.Setup(x => x.FindAsync(It.IsAny<int>())).Returns(Task.FromResult(new UserData() { FirstName="TEST"})!);
            mockUser.Setup(x => x.IsInRole(It.IsAny<string>())).Returns(true);
            mockUser.Setup(x => x.IsInRole(It.IsAny<string>())).Returns(true);
            _sut = new UserDatasController(mockService.Object, mockUser.Object);

            var result = (UserDataViewModel)((ViewResult)_sut.Details(1).Result).Model!;

            mockService.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Exactly(1));
            Assert.That(result, Is.Not.Null);
            Assert.That(result.FirstName, Is.EqualTo("TEST"));

        }


        [Test]
        [Category("Edit Path")]
        [Category("Sad Path")]
        public void WhenEditIsCalledWith_InvalidId_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            //mockService.Setup(x => x.FindAsync(It.IsAny<int>()));
            _sut = new UserDatasController(mockService.Object, mockUser.Object);

            var result = ((NotFoundResult)_sut.Edit(null).Result);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [Category("Edit Path")]
        [Category("Sad Path")]
        public void WhenEditIsCalledWith_NullService_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            mockService.Setup(x => x.IsNull()).Returns(true);
            _sut = new UserDatasController(mockService.Object, mockUser.Object);

            var result = ((NotFoundResult)_sut.Edit(null).Result);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [Category("Edit Path")]
        [Category("Sad Path")]
        public void WhenEditIsCalledWith_NoUserData_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            mockService.Setup(x => x.FindAsync(It.IsAny<int>())).Returns(Task.FromResult((UserData)null!)!);
            _sut = new UserDatasController(mockService.Object, mockUser.Object);

            var result = ((NotFoundResult)_sut.Edit(1).Result);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [Category("Edit Path")]
        [Category("Sad Path")]
        public void WhenEditIsCalledWith_ValidData_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            mockService.Setup(x => x.FindAsync(It.IsAny<int>())).Returns(Task.FromResult(new UserData() { FirstName = "TEST" })!);
            mockUser.Setup(x => x.IsInRole(It.IsAny<string>())).Returns(true);
            _sut = new UserDatasController(mockService.Object, mockUser.Object);

            var result = (UserDataViewModel)((ViewResult)_sut.Edit(1).Result).Model!;

            mockService.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Exactly(1));
            Assert.That(result, Is.Not.Null);
            Assert.That(result.FirstName, Is.EqualTo("TEST"));

        }

        [Test]
        [Category("Delete Path")]
        [Category("Sad Path")]
        public void WhenDeleteIsCalledWith_InvalidId_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            _sut = new UserDatasController(mockService.Object, mockUser.Object);

            var result = ((NotFoundResult)_sut.Delete(null).Result);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [Category("Delete Path")]
        [Category("Sad Path")]
        public void WhenDeleteIsCalledWith_NullService_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            mockService.Setup(x => x.IsNull()).Returns(true);
            _sut = new UserDatasController(mockService.Object, mockUser.Object);

            var result = ((NotFoundResult)_sut.Delete(null).Result);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [Category("Delete Path")]
        [Category("Sad Path")]
        public void WhenDeleteIsCalledWith_NoUserData_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            mockService.Setup(x => x.FindAsync(It.IsAny<int>())).Returns(Task.FromResult((UserData)null!)!);
            _sut = new UserDatasController(mockService.Object, mockUser.Object);

            var result = ((NotFoundResult)_sut.Delete(1).Result);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [Category("Delete Path")]
        [Category("Sad Path")]
        public void WhenDeleteIsCalledWith_ValidData_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            mockService.Setup(x => x.FindAsync(It.IsAny<int>())).Returns(Task.FromResult(new UserData() { FirstName = "TEST" })!);
            mockUser.Setup(x => x.GetUserAsync()).Returns(Task.FromResult(new User() ));
            mockUser.Setup(x => x.IsInRole(It.IsAny<string>())).Returns(true);

            _sut = new UserDatasController(mockService.Object, mockUser.Object);

            var result = (UserDataViewModel)((ViewResult)_sut.Delete(1).Result).Model!;

            mockService.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Exactly(1));
            Assert.That(result, Is.Not.Null);
            Assert.That(result.FirstName, Is.EqualTo("TEST"));
        }

        [Test]
        [Category("DeleteConfirmed Path")]
        [Category("Sad Path")]
        public void WhenDeleteConfirmedIsCalledWith_NullService_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            mockService.Setup(x => x.IsNull()).Returns(true);

            _sut = new UserDatasController(mockService.Object, mockUser.Object);

            var errorString = "Entity set 'TraineeTrackerContext.UserDataDB'  is null.";

            var result = ((ObjectResult)_sut.DeleteConfirmed(1).Result);
            var expected = new ObjectResult(new ProblemDetails { Detail = errorString });

            Assert.That(result, Is.InstanceOf<ObjectResult>());
            Assert.That(((ProblemDetails)result.Value!).Detail, Is.EqualTo(errorString));
        }

        [Test]
        [Category("DeleteConfirmed Path")]
        [Category("Happy Path")]
        public void WhenDeleteConfirmedIsCalledWith_ValidUserId_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            mockService.Setup(x => x.IsNull()).Returns(false);
            mockService.Setup(x => x.FindAsync(It.IsAny<int>())).Returns(Task.FromResult(new UserData() { FirstName = "TEST" })!);
            mockService.Setup(x => x.RemoveAsync(It.IsAny<UserData>()));

            _sut = new UserDatasController(mockService.Object, mockUser.Object);

            var result = _sut.DeleteConfirmed(1).Result;

            mockService.Verify(x => x.RemoveAsync(It.IsAny<UserData>()), Times.Once);
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
        }


        [Test]
        [Category("Edit/Post Path")]
        [Category("Sad Path")]
        public void WhenPostEditIsCalledWith_MismatchedId_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            mockService.Setup(x => x.FindAsync(It.IsAny<int>())).Returns(Task.FromResult(new UserData() { FirstName = "TEST" })!);
            _sut = new UserDatasController(mockService.Object, mockUser.Object);

            var result = _sut.Edit(0, new UserDataViewModel() { ID = 100 }).Result;

            mockService.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Once);
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }


        [Test]
        [Category("Edit/Post Path")]
        [Category("Sad Path")]
        public void WhenPostEditIsCalledWith_InvalidModelState_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            mockService.Setup(x => x.FindAsync(It.IsAny<int>())).Returns(Task.FromResult(new UserData() { FirstName = "TEST" })!);
            _sut = new UserDatasController(mockService.Object, mockUser.Object);
            _sut.ModelState.AddModelError("", "");

            var result = _sut.Edit(0, new UserDataViewModel() { ID = 0 }).Result;

            mockService.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Once);
            Assert.That(result, Is.InstanceOf<ViewResult>());
        }


        [Test]
        [Category("Edit/Post Path")]
        [Category("Sad Path")]
        public void WhenPostEditIsCalledWith_ValidData_SaveChangesThrows_And_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            mockService.Setup(x => x.FindAsync(It.IsAny<int>())).Returns(Task.FromResult(new UserData() { FirstName = "TEST" })!);
            mockService.Setup(x => x.Exists(It.IsAny<int>())).Returns(false);
            mockService.Setup(x => x.SaveChangesAsync()).Throws<DbUpdateConcurrencyException>();

            _sut = new UserDatasController(mockService.Object, mockUser.Object);

            var result = _sut.Edit(0, new UserDataViewModel() { ID = 0 }).Result;

            mockService.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Once);
            mockService.Verify(x => x.Exists(It.IsAny<int>()), Times.Once);
            mockService.Verify(x => x.SaveChangesAsync(), Times.Once);
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        [Category("Edit/Post Path")]
        [Category("Sad Path")]
        public void WhenPostEditIsCalledWith_ValidData_SaveChangesThrows_Then_Catch_Throws()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            mockService.Setup(x => x.FindAsync(It.IsAny<int>())).Returns(Task.FromResult(new UserData() { FirstName = "TEST" })!);
            mockService.Setup(x => x.Exists(It.IsAny<int>())).Returns(true);
            mockService.Setup(x => x.SaveChangesAsync()).Throws<DbUpdateConcurrencyException>();

            _sut = new UserDatasController(mockService.Object, mockUser.Object);

            Assert.Throws<DbUpdateConcurrencyException>(() => { _sut.Edit(0, new UserDataViewModel() { ID = 0 }).GetAwaiter().GetResult(); });

            mockService.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Once);
            mockService.Verify(x => x.Exists(It.IsAny<int>()), Times.Once);
            mockService.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Test]
        [Category("AttemptGetUserDataViewModel Path")]
        [Category("Sad Path")]
        public void AttemptGetUserDataViewModel_Bad_Access()
        {
            var mockService = new Mock<IServiceLayer<UserData>>();
            var mockUser = new Mock<IUserManager<User>>();
            mockService.Setup(x => x.FindAsync(It.IsAny<int>())).Returns(Task.FromResult(new UserData() { ID = 1, FirstName = "TEST" })!);
            mockUser.Setup(x => x.GetUserAsync()).Returns(Task.FromResult(new User() { Id = "a" }));

            _sut = new UserDatasController(mockService.Object, mockUser.Object);

            var result = _sut.AttemptGetUserDataViewModel(0).Result;

            mockService.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Once);
            mockUser.Verify(x => x.GetUserAsync(), Times.Once);
        }

    }
}

