
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Xml.Linq;
using TraineeTracker.Controllers;
using TraineeTracker.Data;
using TraineeTracker.Models;
using TraineeTracker.Models.ViewModels;
using TraineeTracker.Service;


namespace TraineeTrackerTests
{
    public class TrackersController_Tests
    {
        private TrackersController? _sut;

        [Test]
        [Category("Constructor")]
        [Category("Happy Path")]
        public void WhenConstructorIsCalled_ObjectIsConstructed()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();
            
            _sut = new TrackersController(mockService.Object);
            Assert.That(_sut, Is.Not.Null);
            Assert.That(_sut, Is.InstanceOf<TrackersController>());
        }

        [Test]
        [Category("Index Path")]
        [Category("Happy Path")]
        public void WhenIndexIsCalledAs_Trainer_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();

            mockService.Setup(x => x.GetAllAsync())
                .Returns(Task.FromResult(((IEnumerable<Tracker>)new List<Tracker>() { new Tracker() { Comments = "ABCD" } })));

            _sut = new TrackersController(mockService.Object);

            var result = ((ViewResult)_sut.Index(It.IsAny<int>()).Result).Model;
            List<TrackerViewModel> list = (List<TrackerViewModel>)result!;

            mockService.Verify(x => x.GetAllAsync(), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list[0]!.Comments, Is.EqualTo("ABCD"));
        }

        [Test]
        [Category("Index Path")]
        [Category("Happy Path")]
        public void WhenIndexIsCalledAs_Trainee_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();
            
            mockService.Setup(x => x.GetAllAsync())
                .Returns(Task.FromResult(((IEnumerable<Tracker>)new List<Tracker>() { new Tracker() { Comments = "ABCD" } })));

            _sut = new TrackersController(mockService.Object);

            var result = ((ViewResult)_sut.Index(It.IsAny<int>()).Result).Model;
            List<TrackerViewModel> list = (List<TrackerViewModel>)result!;

            mockService.Verify(x => x.GetAllAsync(), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list[0]!.Comments, Is.EqualTo("ABCD"));
        }

        [Test]
        [Category("Details Path")]
        [Category("Sad Path")]
        public void WhenDetailsIsCalledWith_InvalidId_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();
            
            //mockService.Setup(x => x.FindAsync(It.IsAny<int>()));
            _sut = new TrackersController(mockService.Object);

            var result = ((NotFoundResult)_sut.Details(null).Result);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [Category("Details Path")]
        [Category("Sad Path")]
        public void WhenDetailsIsCalledWith_NullService_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();
            
            mockService.Setup(x => x.IsNull()).Returns(true);
            _sut = new TrackersController(mockService.Object);

            var result = ((NotFoundResult)_sut.Details(null).Result);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [Category("Details Path")]
        [Category("Sad Path")]
        public void WhenDetailsIsCalledWith_NoTracker_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();
            
            mockService.Setup(x => x.FindAsync(It.IsAny<int>())).Returns(Task.FromResult((Tracker)null!)!);
            _sut = new TrackersController(mockService.Object);

            var result = ((NotFoundResult)_sut.Details(1).Result);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [Category("Details Path")]
        [Category("Sad Path")]
        public void WhenDetailsIsCalledWith_ValidData_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();
            
            mockService.Setup(x => x.FindAsync(It.IsAny<int>())).Returns(Task.FromResult(new Tracker() { Comments="TEST"})!);
            _sut = new TrackersController(mockService.Object);

            var result = (TrackerViewModel)((ViewResult)_sut.Details(1).Result).Model!;

            mockService.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Exactly(1));
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Comments, Is.EqualTo("TEST"));
        }

        [Test]
        [Category("Create Path")]
        [Category("Happy Path")]
        public void WhenCreateIsCalled_ReturnsExpected_View()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();
            _sut = new TrackersController(mockService.Object);
            var result = _sut.Create();
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [Category("Create Path")]
        [Category("Happy Path")]
        public void WhenCreateIsCalled_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();
            mockService.Setup(x => x.GetAllAsync())
               .Returns(Task.FromResult(((IEnumerable<Tracker>)new List<Tracker>() { new Tracker() { Comments = "ABCD" } })));

            mockService.Setup(x => x.AddAsync(It.IsAny<Tracker>()));
            _sut = new TrackersController(mockService.Object);

            var result = _sut.Create(0, new TrackerViewModel());

            mockService.Verify(x => x.AddAsync(It.IsAny<Tracker>()), Times.Exactly(1));
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [Category("Create Path")]
        [Category("Sad Path")]
        public void WhenCreateIsCalled_WithInvalidModel_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();
            mockService.Setup(x => x.GetAllAsync())
               .Returns(Task.FromResult(((IEnumerable<Tracker>)new List<Tracker>() { new Tracker() { Comments = "ABCD" } })));

            mockService.Setup(x => x.AddAsync(It.IsAny<Tracker>()));
            _sut = new TrackersController(mockService.Object);
            _sut.ModelState.AddModelError("key", "error message");

            var result = _sut.Create(0, new TrackerViewModel());

            mockService.Verify(x => x.AddAsync(It.IsAny<Tracker>()), Times.Never());
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [Category("Edit Path")]
        [Category("Sad Path")]
        public void WhenEditIsCalledWith_InvalidId_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();
            
            //mockService.Setup(x => x.FindAsync(It.IsAny<int>()));
            _sut = new TrackersController(mockService.Object);

            var result = ((NotFoundResult)_sut.Edit(null).Result);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [Category("Edit Path")]
        [Category("Sad Path")]
        public void WhenEditIsCalledWith_NullService_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();
            
            mockService.Setup(x => x.IsNull()).Returns(true);
            _sut = new TrackersController(mockService.Object);

            var result = ((NotFoundResult)_sut.Edit(null).Result);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [Category("Edit Path")]
        [Category("Sad Path")]
        public void WhenEditIsCalledWith_NoTracker_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();
            
            mockService.Setup(x => x.FindAsync(It.IsAny<int>())).Returns(Task.FromResult((Tracker)null!)!);
            _sut = new TrackersController(mockService.Object);

            var result = ((NotFoundResult)_sut.Edit(1).Result);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [Category("Edit Path")]
        [Category("Sad Path")]
        public void WhenEditIsCalledWith_ValidData_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();
            
            mockService.Setup(x => x.FindAsync(It.IsAny<int>())).Returns(Task.FromResult(new Tracker() { Comments = "TEST" })!);
            _sut = new TrackersController(mockService.Object);

            var result = (TrackerViewModel)((ViewResult)_sut.Edit(1).Result).Model!;

            mockService.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Exactly(1));
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [Category("Delete Path")]
        [Category("Sad Path")]
        public void WhenDeleteIsCalledWith_InvalidId_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();
            
            //mockService.Setup(x => x.FindAsync(It.IsAny<int>()));
            _sut = new TrackersController(mockService.Object);

            var result = ((NotFoundResult)_sut.Delete(null).Result);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [Category("Delete Path")]
        [Category("Sad Path")]
        public void WhenDeleteIsCalledWith_NullService_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();
            
            mockService.Setup(x => x.IsNull()).Returns(true);
            _sut = new TrackersController(mockService.Object);

            var result = ((NotFoundResult)_sut.Delete(null).Result);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [Category("Delete Path")]
        [Category("Sad Path")]
        public void WhenDeleteIsCalledWith_NoTracker_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();
            
            mockService.Setup(x => x.FindAsync(It.IsAny<int>())).Returns(Task.FromResult((Tracker)null!)!);
            _sut = new TrackersController(mockService.Object);

            var result = ((NotFoundResult)_sut.Delete(1).Result);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [Category("Delete Path")]
        [Category("Sad Path")]
        public void WhenDeleteIsCalledWith_ValidData_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();
            
            mockService.Setup(x => x.FindAsync(It.IsAny<int>())).Returns(Task.FromResult(new Tracker() { Comments = "TEST" })!);
            _sut = new TrackersController(mockService.Object);

            var result = (TrackerViewModel)((ViewResult)_sut.Delete(1).Result).Model!;

            mockService.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Exactly(1));
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [Category("DeleteConfirmed Path")]
        [Category("Sad Path")]
        public void WhenDeleteConfirmedIsCalledWith_NullService_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();
            
            mockService.Setup(x => x.IsNull()).Returns(true);
            _sut = new TrackersController(mockService.Object);

            var errorString = "Entity set 'TraineeTrackerContext.TrackerDB'  is null.";

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
            var mockService = new Mock<IServiceLayer<Tracker>>();
            
            mockService.Setup(x => x.IsNull()).Returns(false);
            mockService.Setup(x => x.FindAsync(It.IsAny<int>())).Returns(Task.FromResult(new Tracker() { Comments = "TEST" })!);
            mockService.Setup(x => x.RemoveAsync(It.IsAny<Tracker>()));

            _sut = new TrackersController(mockService.Object);

            var result = _sut.DeleteConfirmed(1).Result;

            mockService.Verify(x => x.RemoveAsync(It.IsAny<Tracker>()), Times.Once);
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
        }


        [Test]
        [Category("Edit/Post Path")]
        [Category("Sad Path")]
        public void WhenPostEditIsCalledWith_MismatchedId_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();

            mockService.Setup(x => x.FindAsync(It.IsAny<int>())).Returns(Task.FromResult(new Tracker() { ID=124, Comments = "TEST" })!);
            _sut = new TrackersController(mockService.Object);

            var result = _sut.Edit(0, new TrackerViewModel() { ID = 100 }).Result;

            mockService.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Once);
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }


        [Test]
        [Category("Edit/Post Path")]
        [Category("Sad Path")]
        public void WhenPostEditIsCalledWith_InvalidModelState_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();

            mockService.Setup(x => x.FindAsync(It.IsAny<int>())).Returns(Task.FromResult(new Tracker() { Comments = "TEST" })!);
            _sut = new TrackersController(mockService.Object);
            _sut.ModelState.AddModelError("", "");

            var result = _sut.Edit(0, new TrackerViewModel() { ID = 0 }).Result;

            mockService.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Once);
            Assert.That(result, Is.InstanceOf<ViewResult>());
        }


        [Test]
        [Category("Edit/Post Path")]
        [Category("Sad Path")]
        public void WhenPostEditIsCalledWith_ValidData_SaveChangesThrows_And_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();

            mockService.Setup(x => x.FindAsync(It.IsAny<int>())).Returns(Task.FromResult(new Tracker() { Comments = "TEST" })!);
            mockService.Setup(x => x.Exists(It.IsAny<int>())).Returns(false);
            mockService.Setup(x => x.SaveChangesAsync()).Throws<DbUpdateConcurrencyException>();

            _sut = new TrackersController(mockService.Object);

            var result = _sut.Edit(0, new TrackerViewModel() { ID = 0 }).Result;

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
            var mockService = new Mock<IServiceLayer<Tracker>>();

            mockService.Setup(x => x.FindAsync(It.IsAny<int>())).Returns(Task.FromResult(new Tracker() { Comments = "TEST" })!);
            mockService.Setup(x => x.Exists(It.IsAny<int>())).Returns(true);
            mockService.Setup(x => x.SaveChangesAsync()).Throws<DbUpdateConcurrencyException>();

            _sut = new TrackersController(mockService.Object);

            Assert.Throws<DbUpdateConcurrencyException>(() => { _sut.Edit(0, new TrackerViewModel() { ID = 0 }).GetAwaiter().GetResult(); });

            mockService.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Once);
            mockService.Verify(x => x.Exists(It.IsAny<int>()), Times.Once);
            mockService.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Test]
        [Category("Edit/Post Path")]
        [Category("Happy Path")]
        public void WhenPostEditIsCalledWith_ValidData_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();

            mockService.Setup(x => x.FindAsync(It.IsAny<int>())).Returns(Task.FromResult(new Tracker() { Comments = "TEST" })!);
            mockService.Setup(x => x.SaveChangesAsync());

            _sut = new TrackersController(mockService.Object);

            var result = _sut.Edit(0, new TrackerViewModel() { ID = 0 }).Result;

            mockService.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Once);
            mockService.Verify(x => x.SaveChangesAsync(), Times.Once);
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
        }


    }
}
