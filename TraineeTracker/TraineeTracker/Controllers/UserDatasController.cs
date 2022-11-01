﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TraineeTracker.Data;
using TraineeTracker.Models;
using TraineeTracker.Service;

namespace TraineeTracker.Controllers
{
    //[Authorize]
    public class UserDatasController : Controller
    {
        private readonly IServiceLayer<UserData> _service;
        private IUserManager<User> _userManager;

        public UserDatasController(IServiceLayer<UserData> service, IUserManager<User> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        // GET: UserDatas
        //[Authorize(Roles ="Trainee, Trainer")]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (HttpContext.User.IsInRole("Trainee"))
            {

            }
            else if(HttpContext.User.IsInRole("Trainer"))
            {
                return View(await _service.GetAllAsync());
            }

              return View(await _service.GetAllAsync());
        }

        // GET: UserDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _service.IsNull())
            {
                return NotFound();
            }

            var userData = await _service.FindAsync((int)id); 

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
                await _service.AddAsync(userData);
                return RedirectToAction(nameof(Index));
            }
            return View(userData);
        }

        // GET: UserDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _service.IsNull())
            {
                return NotFound();
            }

            var userData = await _service.FindAsync((int)id);
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
                    await _service.Update(userData);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_service.Exists(userData.ID))
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
            if (id == null || _service.IsNull())
            {
                return NotFound();
            }

            var userData = await _service.FindAsync((int)id);
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
            if (_service.IsNull())
            {
                return Problem("Entity set 'TraineeTrackerContext.UserDataDB'  is null.");
            }
            var userData = await _service.FindAsync(id);
            if (userData != null)
            {
                await _service.RemoveAsync(userData);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
