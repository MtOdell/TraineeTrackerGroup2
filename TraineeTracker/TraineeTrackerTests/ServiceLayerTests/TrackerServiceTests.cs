using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraineeTracker.Service;
using TraineeTracker.Models;
using Microsoft.EntityFrameworkCore;
using TraineeTracker.Data;

namespace TraineeTrackerTests.ServiceLayerTests;

public class TrackerServiceTests
{
    private TraineeTrackerContext _context;
    private IServiceLayer<Tracker> _sut;
    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        var options = new DbContextOptionsBuilder<TraineeTrackerContext>()
            .UseInMemoryDatabase(databaseName: "aspnet-TraineeTracker").Options;
        _context = new TraineeTrackerContext(options);
        _sut = new TrackerService(_context);
        _sut.AddAsync(new Tracker
        {
            ID = 1,
            UserDataId = 1,
            Stop = "nothing",
            Start = "nothing",
            Continue = "moving",
            Comments = "controversial",
            TechnicalSkills = 4,
            ConsultantSkills = 4,
        });
    }
    [Test]
    public void GivenValidID_FindReturnsCorrectTracker()
    {
        var result = _sut.FindAsync(1).Result;
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<Tracker>());
        Assert.That(result.Stop, Is.EqualTo("nothing"));
    }
    [Test]
    public void GetAllAsync_ReturnsListOfTrackers()
    {
        var result = _sut.GetAllAsync().Result;
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<List<Tracker>>());
        Assert.That(result.Count, Is.EqualTo(1));
    }

    [Test]
    public async Task Create_Creates()
    {
        int countPrior = _context.TrackerDB.Count();
        await _sut.AddAsync(new Tracker { UserDataId = 2, ID = 2 });
        int countPost = _context.TrackerDB.Count();
        Assert.That(countPost, Is.EqualTo(countPrior + 1));
        await _sut.RemoveAsync(_context.TrackerDB.Find(2));
    }
    [Test]
    public async Task DeleteUserData_LowersCountByOne()
    {
        await _sut.AddAsync(new Tracker { UserDataId = 2, ID = 2 });
        int countPrior = _context.TrackerDB.Count();
        await _sut.RemoveAsync(_context.TrackerDB.Find(2));
        int countPost = _context.TrackerDB.Count();
        Assert.That(countPost, Is.EqualTo(countPrior - 1));
    }

    [Test]
    public void Exists_ReturnsTrue_WhenTrackerExists()
    {
        var result = _sut.Exists(1);
        Assert.That(result, Is.True);
    }
    [Test]
    public void Exists_ReturnsFalse_WhenTrackerDoesNotExist()
    {
        var result = _sut.Exists(2);
        Assert.That(result, Is.False);
    }

    [Test]
    public void IsNull_ReturnsFalse_IfTrackerIsNotNull()
    {
        var result = _sut.IsNull();
        Assert.That(result, Is.False);
    }
    [Test]
    public async Task SaveChanges_SavesChanges()
    {
        _context.TrackerDB.Add(new Tracker { ID = 3, Comments = "abc" });
        _sut.SaveChangesAsync();
        var data = _context.TrackerDB.Find(3);
        Assert.That(data.Comments, Is.EqualTo("abc"));
        await _sut.RemoveAsync(data);
    }

    [Test]
    public async Task Update_UpdatesUserData()
    {
        await _sut.AddAsync(new Tracker { Comments = "abc", ID = 2 });
        var tracker = _sut.FindAsync(2).Result;
        tracker.Comments = "def";
        await _sut.Update(tracker);
        var result = _sut.FindAsync(2).Result;
        Assert.That(result.Comments, Is.EqualTo("def"));
        await _sut.RemoveAsync(result);
    }
}