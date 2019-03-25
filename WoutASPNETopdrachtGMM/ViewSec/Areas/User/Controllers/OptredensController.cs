using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessFacade;
using Data;
using ViewSec.Areas.User.Models;
using Microsoft.AspNetCore.Authorization;

namespace ViewSec.Areas.User
{
    [Area("User")]
    [Authorize(Roles = "Admin,User")]
    public class OptredensController : Controller
    {
        private readonly GmmContext _context;

        public OptredensController(GmmContext context)
        {
            _context = context;
        }

        // GET: User/Optredens
        public async Task<IActionResult> Index()
        {
            var optredens = await _context.Optredens
               .Include(o => o.Band)
               .Include(o => o.Stage)
               .Include(o => o.Tent)
               .ToListAsync();
            return View(optredens);
        }

        // GET: User/Optredens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var optreden = await _context.Optredens
                .Include(o => o.Logistic)
                .Include(o => o.Band)
                .ThenInclude(b => b.Members)
                .ThenInclude(m => m.Function)
                .Include(o => o.Catering)
                .Include(o => o.Special)
                .Include(o => o.Stage)
                .Include(o => o.Tent)
                .Include(o => o.Voorziening)
                .FirstOrDefaultAsync(o => o.Band.Id == id);
            if (optreden == null)
            {
                return NotFound();
            }

            var rider = createNewRider(optreden);

            return View(rider);
        }

        /// <summary>
        /// Creates a RiderViewModel from an Optreden
        /// </summary>
        private RiderViewModel createNewRider(Optreden optreden)
        {
            RiderViewModel rider = new RiderViewModel();
            rider.Optreden = optreden;
            rider.Band = optreden.Band;
            rider.Catering = optreden.Catering;
            rider.Logistic = optreden.Logistic;
            rider.Special = optreden.Special;
            rider.Stage = optreden.Stage;
            rider.Tent = optreden.Tent;
            rider.Voorziening = optreden.Voorziening;

            var bandKleedkamers = _context.BandKleedkamers.Where(bk => bk.Optreden == optreden)
                                    .Include(bk => bk.Kleedkamer).ToList();
            if (bandKleedkamers != null)
            {
                rider.BandKleedkamers = bandKleedkamers;
                rider.Kleedkamers = bandKleedkamers.Select(bk => bk.Kleedkamer).ToList();
            }

            var bandProductieUnits = _context.BandProductieUnits.Where(bp => bp.Optreden == optreden)
                                    .Include(bp => bp.ProductieUnit).ToList();
            if (bandProductieUnits != null)
            {
                rider.BandProductieUnits = bandProductieUnits;
                rider.ProductieUnits = bandProductieUnits.Select(bp => bp.ProductieUnit).ToList();
            }

            return rider;
        }

        // GET: User/Optredens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Optredens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Hours")] Optreden optreden)
        {
            if (ModelState.IsValid)
            {
                _context.Add(optreden);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(optreden);
        }

        // GET: User/Optredens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var optreden = await _context.Optredens.FindAsync(id);
            if (optreden == null)
            {
                return NotFound();
            }
            return View(optreden);
        }

        // POST: User/Optredens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Hours")] Optreden optreden)
        {
            if (id != optreden.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(optreden);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OptredenExists(optreden.Id))
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
            return View(optreden);
        }

        // GET: User/Optredens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var optreden = await _context.Optredens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (optreden == null)
            {
                return NotFound();
            }

            return View(optreden);
        }

        // POST: User/Optredens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var optreden = await _context.Optredens.FindAsync(id);
            _context.Optredens.Remove(optreden);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OptredenExists(int id)
        {
            return _context.Optredens.Any(e => e.Id == id);
        }
    }
}
