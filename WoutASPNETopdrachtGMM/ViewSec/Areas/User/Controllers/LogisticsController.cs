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
    public class LogisticsController : Controller
    {
        private readonly GmmContext _context;

        public LogisticsController(GmmContext context)
        {
            _context = context;
        }

        // GET: User/Logistics
        public async Task<IActionResult> Index()
        {
            return View(await _context.Logistics.ToListAsync());
        }

        // GET: User/Logistics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logistic = await _context.Logistics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logistic == null)
            {
                return NotFound();
            }

            return View(logistic);
        }

        // GET: User/Logistics/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Logistics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Verlengkabels,Voltage110,Comments")] Logistic logistic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logistic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(logistic);
        }

        // GET: User/Logistics/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logistic = await _context.Logistics.FindAsync(id);
            if (logistic == null)
            {
                return NotFound();
            }
            return View(logistic);
        }

        // POST: User/Logistics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Verlengkabels,Voltage110,Comments")] Logistic logistic)
        {
            if (id != logistic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logistic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogisticExists(logistic.Id))
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
            return View(logistic);
        }

        // GET: User/Logistics/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logistic = await _context.Logistics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logistic == null)
            {
                return NotFound();
            }

            return View(logistic);
        }

        // POST: User/Logistics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var logistic = await _context.Logistics.FindAsync(id);
            _context.Logistics.Remove(logistic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogisticExists(int id)
        {
            return _context.Logistics.Any(e => e.Id == id);
        }
    }
}
