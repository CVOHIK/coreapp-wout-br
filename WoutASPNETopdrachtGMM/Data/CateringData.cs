using BusinessFacade;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Data
{
    public interface ICatering
    {
        ICollection<Catering> GetAll();
        Catering GetById(int id);
        void Save(Catering catering);
    }
    public class CateringData : ICatering
    {
        private readonly GmmContext context;
        public CateringData(GmmContext _context)
        {
            context = _context;
        }
        public ICollection<Catering> GetAll()
        {
            return context.Caterings.ToList();
        }

        public Catering GetById(int id)
        {
            return context.Caterings.Where(c => c.Id == id).Single();
        }

        public void Save(Catering catering)
        {
            context.Caterings.Add(catering);
            context.SaveChanges();
        }
    }
}
