using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using TraineeTracker.Data;
using TraineeTracker.Models;
using TraineeTracker.Service;

namespace TraineeTracker.Controllers
{
    public class TrackersController : Controller
    {
        private readonly IServiceLayer<Tracker> _service;

        public TrackersController(IServiceLayer<Tracker> service)
        {
            _service = service;
        }

        // GET: Trackers
        public async Task<IActionResult> Index(int? id)
        {
              return View((await _service.GetAllAsync()).Where(x => x.UserDataId == id));
        }

        // GET: Trackers/Details/5
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

            return View(tracker);
        }

        // GET: Trackers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trackers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
            return View(tracker);
        }

        // POST: Trackers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserDataId,Stop,Start,Continue,Comments,TechnicalSkills,ConsultantSkills")] Tracker tracker)
        {
            if (id != tracker.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Update(tracker);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_service.Exists(tracker.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tracker);
        }

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

            return View(tracker);
        }

        // POST: Trackers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_service.IsNull())
            {
                return Problem("Entity set 'TraineeTrackerContext.TrackerDB'  is null.");
            }
            var tracker = await _service.FindAsync(id);
            if (tracker != null)
            {
                await _service.RemoveAsync(tracker);
            }
            
            return RedirectToAction(nameof(Index));
        }

    }
}
