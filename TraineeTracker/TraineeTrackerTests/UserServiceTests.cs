using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraineeTracker.Service;
using TraineeTracker.Models;
using Microsoft.EntityFrameworkCore;
using TraineeTracker.Data;

namespace TraineeTrackerTests;

public class UserServiceTests
{
    private TraineeTrackerContext _context;
    private IServiceLayer<UserData> _sut;
    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        var options = new DbContextOptionsBuilder<TraineeTrackerContext>()
            .UseInMemoryDatabase(databaseName: "aspnet-TraineeTracker").Options;
        _context = new TraineeTrackerContext(options);
        _sut = new UserDataService(_context);
        _sut.AddAsync(new UserData 
        {
            FirstName = "Name One", 
            LastName = "Name Two", 
            Title = "A Title", 
            Education = "Illiterate", 
            Experience = "Not Much", 
            Activity = "C#", 
            Biography = "Cheeseburgers OOOoooOOOooOoOoooOo", 
            ID = 1,
            UserID = "xyz"
        });
    }
    [Test]
    public void GivenValidID_FindReturnsCorrectUser()
    {
        var result = _sut.FindAsync(1).Result;
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<UserData>());
        Assert.That(result.FirstName, Is.EqualTo("Name One"));
    }
    [Test]
    public void GetAllAsync_ReturnsIEnumerableType()
    {
        var result = _sut.GetAllAsync().Result;
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<List<UserData>>());
        Assert.That(result.Count, Is.EqualTo(1));
    }

    [Test]
    public async Task Create_Creates()
    {
        int countPrior = _context.UserDataDB.Count();
        await _sut.AddAsync(new UserData { UserID = "abc", ID = 2 });
        int countPost = _context.UserDataDB.Count();
        Assert.That(countPost, Is.EqualTo(countPrior + 1));
        await _sut.RemoveAsync(_context.UserDataDB.Find(2));
    }
    [Test]
    public async Task DeleteUserData_LowersCountByOne()
    {
        await _sut.AddAsync(new UserData { UserID = "abc", ID = 2 });
        int countPrior = _context.UserDataDB.Count();
        await _sut.RemoveAsync(_context.UserDataDB.Find(2));
        int countPost = _context.UserDataDB.Count();
        Assert.That(countPost, Is.EqualTo(countPrior - 1));
    }

    [Test]
    public void Exists_ReturnsTrue_WhenUserDataExists()
    {
        var result = _sut.Exists(1);
        Assert.That(result, Is.True);
    }
    [Test]
    public void IsNull_ReturnsTrue_IfUserDataIsNull()
    {
        var result = _sut.IsNull();
        Assert.That(result, Is.False);
    }
}
