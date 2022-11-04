
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Xml.Linq;
using TraineeTracker.Controllers.API;
using TraineeTracker.Data;
using TraineeTracker.Models;
using TraineeTracker.Models.ViewModels;
using TraineeTracker.Service;


namespace TraineeTrackerTests.APITests
{
    public class TrackersApiController_Tests
    {
       
        [Test]
        [Category("Constructor")]
        [Category("Happy Path")]
        public void WhenConstructorIsCalled_ObjectIsConstructed()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();

            var _sut = new TrackersController(mockService.Object);
            Assert.That(_sut, Is.Not.Null);
            Assert.That(_sut, Is.InstanceOf<TrackersController>());
        }

        [Test]
        [Category("GetTracker Path")]
        [Category("Sad Path")]
        public void WhenGetTrackerIsCalled_WithInvalid_Data_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();

            mockService.Setup(x => x.FindAsync(It.IsAny<int>()))
                .Returns(Task.FromResult((Tracker)null!)!);   

            var _sut = new TrackersController(mockService.Object);

            var result = _sut.GetTracker(It.IsAny<int>()).Result.Result;

            mockService.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        [Category("GetTracker Path")]
        [Category("Happy Path")]
        public void WhenGetTrackerIsCalled_WithValid_Data_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();

            mockService.Setup(x => x.FindAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(new Tracker())!);

            var _sut = new TrackersController(mockService.Object);

            var result = _sut.GetTracker(It.IsAny<int>()).Result.Value;

            mockService.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<TrackerViewModel>());
        }

        /*[Test]
        [Category("UpdateTracker Path")]
        [Category("Sad Path")]
        public void WhenUpdateTrackerIsCalled_MismatchIds_Data_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();

            mockService.Setup(x => x.FindAsync(It.IsAny<int>()))
                .Returns(Task.FromResult((Tracker)null!)!);
            mockService.Setup(x => x.Update(It.IsAny<Tracker>()));
            mockService.Setup(x => x.SaveChangesAsync());

            var _sut = new TrackersController(mockService.Object);

            var result = _sut.UpdateTracker(It.IsAny<int>(), It.IsAny<TrackerViewModel>()).Result;

            mockService.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<BadRequestResult>());
        }*/

        [Test]
        [Category("UpdateTracker Path")]
        [Category("Happy Path")]
        public void WhenUpdateTrackerIsCalled_WithValid_Data_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();

            mockService.Setup(x => x.FindAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(new Tracker() { ID=123})!);
            mockService.Setup(x => x.Update(It.IsAny<Tracker>()));
            mockService.Setup(x => x.SaveChangesAsync());

            var _sut = new TrackersController(mockService.Object);

            var result = _sut.UpdateTracker(123, new TrackerViewModel() { ID = 123 }).Result;

            mockService.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Once);
            mockService.Verify(x => x.Update(It.IsAny<Tracker>()), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<NoContentResult>());
        }

        [Test]
        [Category("UpdateTracker Path")]
        [Category("Sad Path")]
        public void WhenUpdateTrackerIsCalled_SaveChangesAsync_Throws_Catches()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();

            mockService.Setup(x => x.FindAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(new Tracker() { ID = 123 })!);
            mockService.Setup(x => x.Update(It.IsAny<Tracker>()));
            mockService.Setup(x => x.Exists(It.IsAny<int>()))
                .Returns(false);
            mockService.Setup(x => x.SaveChangesAsync())
                .Throws<DbUpdateConcurrencyException>();

            var _sut = new TrackersController(mockService.Object);

            var result = _sut.UpdateTracker(123, new TrackerViewModel() { ID = 123 }).Result;

            mockService.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Once);
            mockService.Verify(x => x.Update(It.IsAny<Tracker>()), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        [Category("UpdateTracker Path")]
        [Category("Sad Path")]
        public void WhenUpdateTrackerIsCalled_SaveChangesAsync_Throws()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();

            mockService.Setup(x => x.FindAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(new Tracker() { ID = 123 })!);
            mockService.Setup(x => x.Update(It.IsAny<Tracker>()));
            mockService.Setup(x => x.Exists(It.IsAny<int>()))
                .Returns(true);
            mockService.Setup(x => x.SaveChangesAsync())
                .Throws<DbUpdateConcurrencyException>();

            var _sut = new TrackersController(mockService.Object);

            Assert.Throws<DbUpdateConcurrencyException>(() => 
            { 
                _sut.UpdateTracker(123, new TrackerViewModel() { ID = 123 }).GetAwaiter().GetResult(); 
            });

            mockService.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Once);
            mockService.Verify(x => x.Exists(It.IsAny<int>()), Times.Once);
            mockService.Verify(x => x.Update(It.IsAny<Tracker>()), Times.Once);
        }

        [Test]
        [Category("UpdateTracker Path")]
        [Category("Sad Path")]
        public void WhenCreateTrackerIsCalled_ReturnsExpected()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();

            mockService.Setup(x => x.AddAsync(It.IsAny<Tracker>()));

            var _sut = new TrackersController(mockService.Object);

            var result = _sut.CreateTracker(new TrackerViewModel() { ID = 123 }).Result;

            mockService.Verify(x => x.AddAsync(It.IsAny<Tracker>()), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Result, Is.InstanceOf<CreatedAtActionResult>());
        }

        [Test]
        [Category("DeleteTracker Path")]
        [Category("Sad Path")]
        public void WhenDeleteTrackerIsCalled_WithInvalidId_Returns_NotFound()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();

            mockService.Setup(x => x.FindAsync(It.IsAny<int>()))
                .Returns(Task.FromResult((Tracker)null!)!);

            mockService.Setup(x => x.RemoveAsync(It.IsAny<Tracker>()));

            var _sut = new TrackersController(mockService.Object);

            var result = _sut.DeleteTracker(123).Result;

            mockService.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }
        [Test]
        [Category("DeleteTracker Path")]
        [Category("Happy Path")]
        public void WhenDeleteTrackerIsCalled_WithValidId_Returns_NoContent()
        {
            var mockService = new Mock<IServiceLayer<Tracker>>();

            mockService.Setup(x => x.FindAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(new Tracker() { ID = 123 })!);

            mockService.Setup(x => x.RemoveAsync(It.IsAny<Tracker>()));


            var _sut = new TrackersController(mockService.Object);

            var result = _sut.DeleteTracker(123).Result;

            mockService.Verify(x => x.FindAsync(It.IsAny<int>()), Times.Once);
            mockService.Verify(x => x.RemoveAsync(It.IsAny<Tracker>()), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<NoContentResult>());
        }
    }
}
