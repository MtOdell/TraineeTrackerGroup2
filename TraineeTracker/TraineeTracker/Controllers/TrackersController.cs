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

namespace TraineeTracker.Controllers
{
    public class TrackersController : Controller
    {
        private readonly TraineeTrackerContext _context;

        public TrackersController(TraineeTrackerContext context)
        {
            _context = context;
        }

        // GET: Trackers
        public async Task<IActionResult> Index(int? id)
        {
              return View((await _context.TrackerDB.ToListAsync()).Where(x => x.UserDataId == id));
        }

        // GET: Trackers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TrackerDB == null)
            {
                return NotFound();
            }

            var tracker = await _context.TrackerDB
                .FirstOrDefaultAsync(m => m.ID == id);
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
                _context.Add(tracker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tracker);
        }

        // GET: Trackers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TrackerDB == null)
            {
                return NotFound();
            }

            var tracker = await _context.TrackerDB.FindAsync(id);
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
                    _context.Update(tracker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrackerExists(tracker.ID))
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
            if (id == null || _context.TrackerDB == null)
            {
                return NotFound();
            }

            var tracker = await _context.TrackerDB
                .FirstOrDefaultAsync(m => m.ID == id);
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
            if (_context.TrackerDB == null)
            {
                return Problem("Entity set 'TraineeTrackerContext.TrackerDB'  is null.");
            }
            var tracker = await _context.TrackerDB.FindAsync(id);
            if (tracker != null)
            {
                _context.TrackerDB.Remove(tracker);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrackerExists(int id)
        {
          return _context.TrackerDB.Any(e => e.ID == id);
        }
    }
}
