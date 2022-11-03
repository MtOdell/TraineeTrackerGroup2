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
            //TechnicalSkills = 4,
            //ConsultantSkills = 4,
        });
    }
}