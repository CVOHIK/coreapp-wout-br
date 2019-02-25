using BusinessFacade;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Data
{
    public interface ITent
    {
        ICollection<Tent> GetAll();
        Tent GetById(int id);
        void Save(Tent tent);
    }
    public class TentData : ITent
    {
        private readonly GmmContext context;
        public TentData(GmmContext _context)
        {
            context = _context;
        }
        public ICollection<Tent> GetAll()
        {
            return context.Tents.ToList();
        }

        public Tent GetById(int id)
        {
            return context.Tents.Where(t => t.Id == id).Single();
        }

        public void Save(Tent tent)
        {
            context.Tents.Add(tent);
            context.SaveChanges();
        }
    }
}
