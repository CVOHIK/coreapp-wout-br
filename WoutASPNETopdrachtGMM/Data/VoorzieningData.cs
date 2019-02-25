using BusinessFacade;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Data
{
    public interface IVoorziening
    {
        ICollection<Voorziening> GetAll();
        Voorziening GetById(int id);
        void Save(Voorziening voorziening);
    }
    public class VoorzieningData : IVoorziening
    {
        private readonly GmmContext context;
        public VoorzieningData(GmmContext _context)
        {
            context = _context;
        }
        public ICollection<Voorziening> GetAll()
        {
            return context.Voorzienings.ToList();
        }

        public Voorziening GetById(int id)
        {
            return context.Voorzienings.Where(v => v.Id == id).Single();
        }

        public void Save(Voorziening voorziening)
        {
            context.Voorzienings.Add(voorziening);
            context.SaveChanges();
        }
    }
}
