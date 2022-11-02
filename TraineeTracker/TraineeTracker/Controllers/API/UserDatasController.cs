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
    [Route("api/UserDatas")]
    [ApiController]
    public class UserDatasController : ControllerBase
    {
        private readonly UserDataService _service;
        private readonly TrackerService _trackerService;

        public UserDatasController(UserDataService service)
        {
            _service = service;
        }

        // GET: api/UserDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserData>>> GetAll()
        {
            var userDatas = await _service.GetAllAsync();
            return Ok(userDatas);
        }

        // GET: api/UserDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserData>> GetUserData(int id)
        {
            var userData = await _service.FindAsync(id);

            if (userData == null)
            {
                return NotFound();
            }

            return userData;
        }
        // GET: api/UserDatas/id/trackers
        [HttpGet("{id}/trackers")]
        public async Task<ActionResult<IEnumerable<Tracker>>> GetUserTrackers(int id)
        {
            
            var allTrackers = await _trackerService.GetAllAsync();
            var userTrackers = allTrackers.Where(t => t.UserDataId == id);

            if (userTrackers == null)
            {
                return NotFound();
            }

            return Ok(userTrackers);
        }

        // PUT: api/UserDatas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserData(int id, UserData userData)
        {
            if (id != userData.ID)
            {
                return BadRequest();
            }

            //should remove savechances from update method
            //because save chances is here inside try
            await _service.Update(userData);            
            //_service.Entry(userData).State = EntityState.Modified;

            try
            {
                await _service.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDataExists(id))
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

        // POST: api/UserDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserData>> PostUserData(UserData userData)
        {
            await _service.AddAsync(userData);

            return CreatedAtAction("GetUserData", new { id = userData.ID }, userData);
        }

        // DELETE: api/UserDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserData(int id)
        {
            var userData = await _service.FindAsync(id);
            if (userData == null)
            {
                return NotFound();
            }

            await _service.RemoveAsync(userData);

            return NoContent();
        }

        private bool UserDataExists(int id)
        {
            return _service.Exists(id);
        }
    }
}
