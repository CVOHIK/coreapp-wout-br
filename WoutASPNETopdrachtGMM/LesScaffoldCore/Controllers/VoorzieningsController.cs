﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessFacade;
using Data;

namespace View.Controllers
{
    public class VoorzieningsController : Controller
    {
        private readonly GmmContext _context;

        public VoorzieningsController(GmmContext context)
        {
            _context = context;
        }

        // GET: Voorzienings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Voorzienings.ToListAsync());
        }

        // GET: Voorzienings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voorziening = await _context.Voorzienings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voorziening == null)
            {
                return NotFound();
            }

            return View(voorziening);
        }

        // GET: Voorzienings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Voorzienings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Wasserij,Busstock,Coolersband,CoolersGMM,Comments")] Voorziening voorziening)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voorziening);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voorziening);
        }

        // GET: Voorzienings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voorziening = await _context.Voorzienings.FindAsync(id);
            if (voorziening == null)
            {
                return NotFound();
            }
            return View(voorziening);
        }

        // POST: Voorzienings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Wasserij,Busstock,Coolersband,CoolersGMM,Comments")] Voorziening voorziening)
        {
            if (id != voorziening.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voorziening);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoorzieningExists(voorziening.Id))
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
            return View(voorziening);
        }

        // GET: Voorzienings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voorziening = await _context.Voorzienings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voorziening == null)
            {
                return NotFound();
            }

            return View(voorziening);
        }

        // POST: Voorzienings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var voorziening = await _context.Voorzienings.FindAsync(id);
            _context.Voorzienings.Remove(voorziening);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoorzieningExists(int id)
        {
            return _context.Voorzienings.Any(e => e.Id == id);
        }
    }
}
