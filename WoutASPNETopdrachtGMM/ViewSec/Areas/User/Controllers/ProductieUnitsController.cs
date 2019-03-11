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
    public class ProductieUnitsController : Controller
    {
        private readonly GmmContext _context;

        public ProductieUnitsController(GmmContext context)
        {
            _context = context;
        }

        // GET: User/ProductieUnits
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductieUnits.ToListAsync());
        }

        // GET: User/ProductieUnits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productieUnit = await _context.ProductieUnits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productieUnit == null)
            {
                return NotFound();
            }

            return View(productieUnit);
        }

        // GET: User/ProductieUnits/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/ProductieUnits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ProductieUnit productieUnit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productieUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productieUnit);
        }

        // GET: User/ProductieUnits/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productieUnit = await _context.ProductieUnits.FindAsync(id);
            if (productieUnit == null)
            {
                return NotFound();
            }
            return View(productieUnit);
        }

        // POST: User/ProductieUnits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ProductieUnit productieUnit)
        {
            if (id != productieUnit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productieUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductieUnitExists(productieUnit.Id))
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
            return View(productieUnit);
        }

        // GET: User/ProductieUnits/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productieUnit = await _context.ProductieUnits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productieUnit == null)
            {
                return NotFound();
            }

            return View(productieUnit);
        }

        // POST: User/ProductieUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productieUnit = await _context.ProductieUnits.FindAsync(id);
            _context.ProductieUnits.Remove(productieUnit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductieUnitExists(int id)
        {
            return _context.ProductieUnits.Any(e => e.Id == id);
        }
    }
}
