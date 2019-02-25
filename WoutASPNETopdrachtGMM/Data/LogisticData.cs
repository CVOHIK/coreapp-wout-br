using BusinessFacade;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Data
{
    public interface ILogistic
    {
        ICollection<Logistic> GetAll();
        Logistic GetById(int id);
        void Save(Logistic logistic);
    }
    public class LogisticData : ILogistic
    {
        private readonly GmmContext context;
        public LogisticData(GmmContext _context)
        {
            context = _context;
        }
        public ICollection<Logistic> GetAll()
        {
            return context.Logistics.ToList();
        }

        public Logistic GetById(int id)
        {
            return context.Logistics.Where(l => l.Id == id).Single();
        }

        public void Save(Logistic logistic)
        {
            context.Logistics.Add(logistic);
            context.SaveChanges();
        }
    }
}
