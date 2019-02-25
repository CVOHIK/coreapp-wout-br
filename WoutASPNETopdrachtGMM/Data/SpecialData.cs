using BusinessFacade;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Data
{
    public interface ISpecial
    {
        ICollection<Special> GetAll();
        Special GetById(int id);
        void Save(Special special);
    }
    public class SpecialData : ISpecial
    {
        private readonly GmmContext context;
        public SpecialData(GmmContext _context)
        {
            context = _context;
        }
        public ICollection<Special> GetAll()
        {
            return context.Specials.ToList();
        }

        public Special GetById(int id)
        {
            return context.Specials.Where(s => s.Id == id).Single();
        }

        public void Save(Special special)
        {
            context.Specials.Add(special);
            context.SaveChanges();
        }
    }
}
