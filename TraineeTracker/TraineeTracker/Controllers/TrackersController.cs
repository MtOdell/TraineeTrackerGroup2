using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using TraineeTracker.Data;
using TraineeTracker.Models;
using TraineeTracker.Models.ViewModels;
using TraineeTracker.Service;

namespace TraineeTracker.Controllers
{
    [Authorize]
    public class TrackersController : Controller
    {
        private readonly IServiceLayer<Tracker> _service;

        public TrackersController(IServiceLayer<Tracker> service)
        {
            _service = service;
        }
        [Authorize(Roles = "Trainee, Trainer, Admin")]
        // GET: Trackers
        public async Task<IActionResult> Index(int? id)
        {
            var trackerDatas = (await _service.GetAllAsync()).Where(x => x.UserDataId == id);
            var trackerViewModel = new List<TrackerViewModel>();
            foreach(var trackerData in trackerDatas)
            {
                trackerViewModel.Add(Utils.TrackerToViewModel(trackerData));
            }

              return View(trackerViewModel);
        }

        // GET: Trackers/Details/5
        [Authorize(Roles = "Trainee, Trainer, Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _service.IsNull())
            {
                return NotFound();
            }

            var tracker = await _service.FindAsync((int)id);
            if (tracker == null)
            {
                return NotFound();
            }
            var trackerViewModel = Utils.TrackerToViewModel(tracker);

            return View(trackerViewModel);
        }

        // GET: Trackers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trackers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Trainee, Trainer, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserDataId,Stop,Start,Continue,Comments,TechnicalSkills,ConsultantSkills")] Tracker tracker)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(tracker);
                return RedirectToAction(nameof(Index));
            }
            return View(tracker);
        }
        [Authorize(Roles = "Trainee, Trainer, Admin")]
        // GET: Trackers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _service.IsNull())
            {
                return NotFound();
            }

            var tracker = await _service.FindAsync((int)id);
            if (tracker == null)
            {
                return NotFound();
            }
            var trackerViewModel = Utils.TrackerToViewModel(tracker);
            return View(trackerViewModel);
        }

        // POST: Trackers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Trainee, Trainer, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Stop,Start,Continue,Comments,TechnicalSkills,ConsultantSkills")] TrackerViewModel trackerViewModel)
        {
            var trackers = await _service.FindAsync(id);
            if (id != trackers.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    trackers.Stop = trackerViewModel.Stop;
                    trackers.Start = trackerViewModel.Start;
                    trackers.Continue = trackerViewModel.Continue;
                    trackers.Comments = trackerViewModel.Comments ?? "";
                    trackers.ConsultantSkills = trackerViewModel.ConsultantSkills;
                    trackers.TechnicalSkills = trackerViewModel.TechnicalSkills;

                    await _service.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_service.Exists(trackers.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index),new { id = trackers.UserDataId });
            }
            return View(trackerViewModel);
        }
        [Authorize(Roles = "Trainer, Admin")]

        // GET: Trackers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _service.IsNull())
            {
                return NotFound();
            }

            var tracker = await _service.FindAsync((int)id);
            if (tracker == null)
            {
                return NotFound();
            }
            var trackerViewModel = Utils.TrackerToViewModel(tracker);

            return View(trackerViewModel);
        }

        // POST: Trackers/Delete/5
        [Authorize(Roles = "Trainer, Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_service.IsNull())
            {
                return Problem("Entity set 'TraineeTrackerContext.TrackerDB'  is null.");
            }
            var tracker = await _service.FindAsync(id);
            var idToGo = tracker.UserDataId;
            if (tracker != null)
            {
                await _service.RemoveAsync(tracker);
            }
            
            return RedirectToAction(nameof(Index), new {id = idToGo});
        }

    }
}
