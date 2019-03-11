using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessFacade;
using Data;
using Microsoft.AspNetCore.Authorization;

namespace ViewSec.Areas.User
{
    [Area("User")]
    [Authorize(Roles = "Admin,User")]
    public class CateringsController : Controller
    {
        private readonly GmmContext _context;

        public CateringsController(GmmContext context)
        {
            _context = context;
        }

        // GET: User/Caterings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Caterings.ToListAsync());
        }

        // GET: User/Caterings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catering = await _context.Caterings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catering == null)
            {
                return NotFound();
            }

            return View(catering);
        }

        // GET: User/Caterings/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Caterings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,AfterShow")] Catering catering)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catering);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catering);
        }

        // GET: User/Caterings/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catering = await _context.Caterings.FindAsync(id);
            if (catering == null)
            {
                return NotFound();
            }
            return View(catering);
        }

        // POST: User/Caterings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AfterShow")] Catering catering)
        {
            if (id != catering.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catering);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CateringExists(catering.Id))
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
            return View(catering);
        }

        // GET: User/Caterings/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catering = await _context.Caterings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catering == null)
            {
                return NotFound();
            }

            return View(catering);
        }

        // POST: User/Caterings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catering = await _context.Caterings.FindAsync(id);
            _context.Caterings.Remove(catering);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CateringExists(int id)
        {
            return _context.Caterings.Any(e => e.Id == id);
        }
    }
}
