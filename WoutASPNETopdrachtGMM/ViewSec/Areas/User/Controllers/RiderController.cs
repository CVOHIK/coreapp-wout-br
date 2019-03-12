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

namespace ViewSec.Areas.User.Views
{
    [Area("User")]
    [Authorize(Roles = "Admin,User")]
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

            var optreden = await _context.Optredens
                .Include(o => o.Logistic)
                .Include(o => o.Band)
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

            var bandKleedkamers = _context.BandKleedkamers.Where(bk => bk.Optreden == optreden).ToList();
            if (bandKleedkamers != null)
            {
                rider.Kleedkamers = bandKleedkamers.Select(bk => bk.Kleedkamer).ToList();
            }

            var bandProductieUnits = _context.BandProductieUnits.Where(bp => bp.Optreden == optreden).ToList();
            if (bandProductieUnits != null)
            {
                rider.ProductieUnits = bandProductieUnits.Select(bp => bp.ProductieUnit).ToList();
            }

            return rider;
        }

        // GET: Rider/BandName
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
