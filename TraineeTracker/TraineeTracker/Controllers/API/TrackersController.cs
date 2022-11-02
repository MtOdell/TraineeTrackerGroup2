using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraineeTracker.Data;
using TraineeTracker.Models;
using TraineeTracker.Service;

namespace TraineeTracker.Controllers.API
{
    [Route("api/Trackers")]
    [ApiController]
    public class TrackersController : ControllerBase
    {
        private readonly IServiceLayer<Tracker> _service;

        public TrackersController(IServiceLayer<Tracker> service)
        {
            _service = service;
        }
        // GET: api/Trackers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tracker>>> GetAll()
        {
            var tasks = await _service.GetAllAsync();
            return Ok(tasks);
        }

        // GET: api/Trackers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tracker>> GetTracker(int id)
        {
            var tracker = await _service.FindAsync(id);

            if (tracker == null)
            {
                return NotFound();
            }

            return tracker;
        }

        // PUT: api/Trackers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTracker(int id, Tracker tracker)
        {
            if (id != tracker.ID)
            {
                return BadRequest();
            }

            await _service.Update(tracker);
            //_context.Entry(tracker).State = EntityState.Modified;

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
        public async Task<ActionResult<Tracker>> CreateTracker(Tracker tracker)
        {
            await _service.AddAsync(tracker);

            return CreatedAtAction("GetTracker", new { id = tracker.ID }, tracker);
        }

        // DELETE: api/Trackers/5
        [HttpDelete("{id}")]
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
