using BusinessFacade;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Data
{
    public interface IKleedkamer
    {
        ICollection<Kleedkamer> GetAll();
        Kleedkamer GetById(int id);
        void Save(Kleedkamer kleedkamer);
    }
    public class KleedkamerData : IKleedkamer
    {
        private readonly GmmContext context;
        public KleedkamerData(GmmContext _context)
        {
            context = _context;
        }
        public ICollection<Kleedkamer> GetAll()
        {
            return context.Kleedkamers.ToList();
        }

        public Kleedkamer GetById(int id)
        {
            return context.Kleedkamers.Where(k => k.Id == id).Single();
        }

        public void Save(Kleedkamer kleedkamer)
        {
            context.Kleedkamers.Add(kleedkamer);
            context.SaveChanges();
        }
    }
}
