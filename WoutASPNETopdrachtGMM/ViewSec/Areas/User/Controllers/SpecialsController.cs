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
    public class SpecialsController : Controller
    {
        private readonly GmmContext _context;

        public SpecialsController(GmmContext context)
        {
            _context = context;
        }

        // GET: User/Specials
        public async Task<IActionResult> Index()
        {
            return View(await _context.Specials.ToListAsync());
        }

        // GET: User/Specials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var special = await _context.Specials
                .FirstOrDefaultAsync(m => m.Id == id);
            if (special == null)
            {
                return NotFound();
            }

            return View(special);
        }

        // GET: User/Specials/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Specials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,HdWitGr,HdWitKl,HdZwartGr,HdZwartKl,Runner,Arts,Zuurstof,Kine,Vervoer,Comments")] Special special)
        {
            if (ModelState.IsValid)
            {
                _context.Add(special);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(special);
        }

        // GET: User/Specials/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var special = await _context.Specials.FindAsync(id);
            if (special == null)
            {
                return NotFound();
            }
            return View(special);
        }

        // POST: User/Specials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HdWitGr,HdWitKl,HdZwartGr,HdZwartKl,Runner,Arts,Zuurstof,Kine,Vervoer,Comments")] Special special)
        {
            if (id != special.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(special);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialExists(special.Id))
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
            return View(special);
        }

        // GET: User/Specials/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var special = await _context.Specials
                .FirstOrDefaultAsync(m => m.Id == id);
            if (special == null)
            {
                return NotFound();
            }

            return View(special);
        }

        // POST: User/Specials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var special = await _context.Specials.FindAsync(id);
            _context.Specials.Remove(special);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecialExists(int id)
        {
            return _context.Specials.Any(e => e.Id == id);
        }
    }
}
