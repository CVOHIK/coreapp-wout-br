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
    public class TentsController : Controller
    {
        private readonly GmmContext _context;

        public TentsController(GmmContext context)
        {
            _context = context;
        }

        // GET: User/Tents
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tents.ToListAsync());
        }

        // GET: User/Tents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tent = await _context.Tents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tent == null)
            {
                return NotFound();
            }

            return View(tent);
        }

        // GET: User/Tents/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Tents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Tent tent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tent);
        }

        // GET: User/Tents/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tent = await _context.Tents.FindAsync(id);
            if (tent == null)
            {
                return NotFound();
            }
            return View(tent);
        }

        // POST: User/Tents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Tent tent)
        {
            if (id != tent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TentExists(tent.Id))
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
            return View(tent);
        }

        // GET: User/Tents/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tent = await _context.Tents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tent == null)
            {
                return NotFound();
            }

            return View(tent);
        }

        // POST: User/Tents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tent = await _context.Tents.FindAsync(id);
            _context.Tents.Remove(tent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TentExists(int id)
        {
            return _context.Tents.Any(e => e.Id == id);
        }
    }
}
