using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessFacade;
using Data;
using ViewSec.Models;

namespace ViewSec.Views
{
    public class RiderController : Controller
    {
        private readonly GmmContext _context;

        public RiderController(GmmContext context)
        {
            _context = context;
        }

        // GET: Rider/5
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var band = await _context.Bands.FirstOrDefaultAsync(b => b.Id == id);
            if (band == null)
            {
                return NotFound();
            }

            RiderViewModel rider = new RiderViewModel();
            rider.Band = band;

            return View(rider);
        }

        // GET: Rider/5
        public async Task<IActionResult> Name2(string name)
        {
            if (name == null)
            {
                return NotFound();
            }

            var band = await _context.Bands.FirstOrDefaultAsync(b => b.Name == name);
            if (band == null)
            {
                return NotFound();
            }

            RiderViewModel rider = new RiderViewModel();
            rider.Band = band;

            return View(rider);
        }
    }
}
