using BusinessFacade;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Data
{
    public interface IBand
    {
        ICollection<Band> GetAll();
        Band GetById(int id);
        void Save(Band band);
    }
    public class BandData : IBand
    {
        private readonly GmmContext context;
        public BandData(GmmContext _context)
        {
            context = _context;
        }
        public ICollection<Band> GetAll()
        {
            return context.Bands.ToList();
        }

        public Band GetById(int id)
        {
            return context.Bands.Where(b => b.Id == id).Single();
        }

        public void Save(Band band)
        {
            context.Bands.Add(band);
            context.SaveChanges();
        }
    }
}
