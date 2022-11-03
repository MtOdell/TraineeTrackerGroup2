using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraineeTracker.Data;
using TraineeTracker.Models;
using TraineeTracker.Models.ViewModels;
using TraineeTracker.Service;

namespace TraineeTracker.Controllers.API
{
    [Route("api/UserDatas")]
    [ApiController]
    public class UserDatasController : ControllerBase
    {
        private readonly IServiceLayer<UserData> _service;
        private readonly IServiceLayer<Tracker> _trackerService;

        public UserDatasController(IServiceLayer<UserData> service, IServiceLayer<Tracker> trackerService)
        {
            _service = service;
            _trackerService = trackerService;
        }

        // GET: api/UserDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDataViewModel>>> GetAll()
        {
            var userDatas = await _service.GetAllAsync();
            var userDatasModel = userDatas.Select(ud => Utils.UserDataToViewModel(ud));
            
            return Ok(userDatasModel);
        }

        // GET: api/UserDatas/
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<UserDataViewModel>>> GetUserData([FromQuery] SearchCriteria search)
        {
            var allUsers = await _service.GetAllAsync();
            var users = allUsers.Where(u => u.FirstName.Contains(search.Name) && u.LastName.Contains(search.Name) && u.Activity.Contains(search.Activity));
            if (users == null)
            {
                return NotFound();
            }
            var userDatasModel = users.Select(ud => Utils.UserDataToViewModel(ud));

            return Ok(userDatasModel);
        }
       
        
        // GET: api/UserDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDataViewModel>> GetUserData(int id)
        {
            var userData = await _service.FindAsync(id);
            if (userData == null)
            {
                return NotFound();
            }

            return Utils.UserDataToViewModel(userData);
        }
        // GET: api/UserDatas/id/trackers
        [HttpGet("{id}/trackers")]
        public async Task<ActionResult<IEnumerable<TrackerViewModel>>> GetUserTrackers(int id)
        {
            
            var allTrackers = await _trackerService.GetAllAsync();

            if (allTrackers == null)
            {
                return NotFound();
            }
            var userTrackers = allTrackers.Where(t => t.UserDataId == id);
            var userTrackerModel = userTrackers.Select(t => Utils.TrackerToViewModel(t));

            return Ok(userTrackerModel);
        }

        // PUT: api/UserDatas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserData(int id, UserDataViewModel userDataViewModel)
        {
            var userData = await _service.FindAsync(id);
            if (id != userDataViewModel.ID)
            {
                return BadRequest();
            }

            userData.FirstName = userDataViewModel.FirstName;
            userData.LastName = userDataViewModel.LastName;
            userData.Title = userDataViewModel.Title;
            userData.Education = userDataViewModel.Education;
            userData.Experience = userDataViewModel.Experience;
            userData.Activity = userDataViewModel.Activity;
            userData.Biography = userDataViewModel.Biography;
            userData.Skills = userDataViewModel.Skills;

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

    public class SearchCriteria
    {
        public string Name { get; set; } = "";

        public string Activity { get; set; } = "";
    }
}
