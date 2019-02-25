using BusinessFacade;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Data
{
    public interface IBandKleedkamersData
    {
        ICollection<BandKleedkamers> GetAll();
        BandKleedkamers GetById(int id);
        void Save(BandKleedkamers bandKleedkamers);
    }
    public class BandKleedkamersData : IBandKleedkamersData
    {
        private readonly GmmContext context;
        public BandKleedkamersData(GmmContext _context)
        {
            context = _context;
        }
        public ICollection<BandKleedkamers> GetAll()
        {
            return context.BandKleedkamers.ToList();
        }

        public BandKleedkamers GetById(int id)
        {
            return context.BandKleedkamers.Where(b => b.Id == id).Single();
        }

        public void Save(BandKleedkamers bandKleedkamers)
        {
            context.BandKleedkamers.Add(bandKleedkamers);
            context.SaveChanges();
        }
    }
}
