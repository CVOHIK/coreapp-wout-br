using BusinessFacade;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Data
{
    public interface IBandProductieUnits
    {
        ICollection<BandProductieUnits> GetAll();
        BandProductieUnits GetById(int id);
        void Save(BandProductieUnits bandProductieUnits);
    }
    public class BandProductieUnitsData : IBandProductieUnits
    {
        private readonly GmmContext context;
        public BandProductieUnitsData(GmmContext _context)
        {
            context = _context;
        }
        public ICollection<BandProductieUnits> GetAll()
        {
            return context.BandProductieUnits.ToList();
        }

        public BandProductieUnits GetById(int id)
        {
            return context.BandProductieUnits.Where(b => b.Id == id).Single();
        }

        public void Save(BandProductieUnits bandProductieUnits)
        {
            context.BandProductieUnits.Add(bandProductieUnits);
            context.SaveChanges();
        }
    }
}
