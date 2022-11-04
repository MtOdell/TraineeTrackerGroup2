using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using TraineeTracker.Data;
using TraineeTracker.Models;
using TraineeTracker.Models.ViewModels;
using TraineeTracker.Security.Authorization;
using TraineeTracker.Service;

namespace TraineeTracker.Controllers.API
{
    [Route("api/Trackers")]
    [ApiController]
    [Produces("application/json")]
    public class TrackersController : ControllerBase
    {
        private readonly IServiceLayer<Tracker> _service;

        public TrackersController(IServiceLayer<Tracker> service)
        {
            _service = service;
        }
        //// GET: api/Trackers
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Tracker>>> GetAll()
        //{
        //    var tasks = await _service.GetAllAsync();
        //    return Ok(tasks);
        //}

        // GET: api/Trackers/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Trainee, Trainer")]

        public async Task<ActionResult<TrackerViewModel>> GetTracker(int id)
        {
            var tracker = await _service.FindAsync(id);

            if (tracker == null)
            {
                return NotFound();
            }

            return Utils.TrackerToViewModel(tracker);
        }

        // PUT: api/Trackers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Policy = Policies.OnlyTrainee)]
        public async Task<IActionResult> UpdateTracker(int id, TrackerViewModel trackerViewModel)
        {
            var tracker = await _service.FindAsync(id);
            if (id != trackerViewModel.ID || tracker == null)
            {
                return BadRequest();
            }

            tracker.Stop = trackerViewModel.Stop;
            tracker.Start = trackerViewModel.Start;
            tracker.Continue = trackerViewModel.Continue;
            tracker.Comments = trackerViewModel.Comments;
            tracker.TechnicalSkills = trackerViewModel.TechnicalSkills;
            tracker.ConsultantSkills = trackerViewModel.ConsultantSkills;

            await _service.Update(tracker);
            

            try
            {
                await _service.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Trackers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Trainer, Admin")]
        public async Task<ActionResult<TrackerViewModel>> CreateTracker(TrackerViewModel tracker)
        {
            await _service.AddAsync(Utils.ViewModelToTracker(tracker));

            return CreatedAtAction("GetTracker", new { id = tracker.ID }, tracker);
        }

        // DELETE: api/Trackers/5
        [HttpDelete("{id}")]
        [Authorize(Roles ="Trainers, Admin")]
        public async Task<IActionResult> DeleteTracker(int id)
        {
            var tracker = await _service.FindAsync(id);
            if (tracker == null)
            {
                return NotFound();
            }

            await _service.RemoveAsync(tracker);

            return NoContent();
        }

        private bool TrackerExists(int id)
        {
            return _service.Exists(id);
        }
    }
}
