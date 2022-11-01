using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TraineeTracker.Data;
using TraineeTracker.Models;

namespace TraineeTracker.Controllers
{
    public class UserDatasController : Controller
    {
        private readonly TraineeTrackerContext _context;

        public UserDatasController(TraineeTrackerContext context)
        {
            _context = context;
        }

        // GET: UserDatas
        public async Task<IActionResult> Index()
        {
              return View(await _context.UserDataDB.ToListAsync());
        }

        // GET: UserDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserDataDB == null)
            {
                return NotFound();
            }

            var userData = await _context.UserDataDB
                .FirstOrDefaultAsync(m => m.ID == id);
            if (userData == null)
            {
                return NotFound();
            }

            return View(userData);
        }

        // GET: UserDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,ID,FirstName,LastName,Title,Education,Experience,Activity,Biography,Skills")] UserData userData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userData);
        }

        // GET: UserDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserDataDB == null)
            {
                return NotFound();
            }

            var userData = await _context.UserDataDB.FindAsync(id);
            if (userData == null)
            {
                return NotFound();
            }
            return View(userData);
        }

        // POST: UserDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserID,ID,FirstName,LastName,Title,Education,Experience,Activity,Biography,Skills")] UserData userData)
        {
            if (id != userData.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserDataExists(userData.ID))
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
            return View(userData);
        }

        // GET: UserDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserDataDB == null)
            {
                return NotFound();
            }

            var userData = await _context.UserDataDB
                .FirstOrDefaultAsync(m => m.ID == id);
            if (userData == null)
            {
                return NotFound();
            }

            return View(userData);
        }

        // POST: UserDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserDataDB == null)
            {
                return Problem("Entity set 'TraineeTrackerContext.UserDataDB'  is null.");
            }
            var userData = await _context.UserDataDB.FindAsync(id);
            if (userData != null)
            {
                _context.UserDataDB.Remove(userData);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserDataExists(int id)
        {
          return _context.UserDataDB.Any(e => e.ID == id);
        }
    }
}
