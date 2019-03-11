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
    public class KleedkamersController : Controller
    {
        private readonly GmmContext _context;

        public KleedkamersController(GmmContext context)
        {
            _context = context;
        }

        // GET: User/Kleedkamers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kleedkamers.ToListAsync());
        }

        // GET: User/Kleedkamers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kleedkamer = await _context.Kleedkamers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kleedkamer == null)
            {
                return NotFound();
            }

            return View(kleedkamer);
        }

        // GET: User/Kleedkamers/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Kleedkamers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Name")] Kleedkamer kleedkamer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kleedkamer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kleedkamer);
        }

        // GET: User/Kleedkamers/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kleedkamer = await _context.Kleedkamers.FindAsync(id);
            if (kleedkamer == null)
            {
                return NotFound();
            }
            return View(kleedkamer);
        }

        // POST: User/Kleedkamers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Kleedkamer kleedkamer)
        {
            if (id != kleedkamer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kleedkamer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KleedkamerExists(kleedkamer.Id))
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
            return View(kleedkamer);
        }

        // GET: User/Kleedkamers/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kleedkamer = await _context.Kleedkamers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kleedkamer == null)
            {
                return NotFound();
            }

            return View(kleedkamer);
        }

        // POST: User/Kleedkamers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kleedkamer = await _context.Kleedkamers.FindAsync(id);
            _context.Kleedkamers.Remove(kleedkamer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KleedkamerExists(int id)
        {
            return _context.Kleedkamers.Any(e => e.Id == id);
        }
    }
}
