using BusinessFacade;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Data
{
    public interface IOptreden
    {
        ICollection<Optreden> GetAll();
        Optreden GetById(int id);
        void Save(Optreden optreden);
    }
    public class OptredenData : IOptreden
    {
        private readonly GmmContext context;
        public OptredenData(GmmContext _context)
        {
            context = _context;
        }
        public ICollection<Optreden> GetAll()
        {
            return context.Optredens.ToList();
        }

        public Optreden GetById(int id)
        {
            return context.Optredens.Where(o => o.Id == id).Single();
        }

        public void Save(Optreden optreden)
        {
            context.Optredens.Add(optreden);
            context.SaveChanges();
        }
    }
}
