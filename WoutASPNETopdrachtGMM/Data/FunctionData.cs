using BusinessFacade;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Data
{
    public interface IFunction
    {
        ICollection<Function> GetAll();
        Function GetById(int id);
        void Save(Function function);
    }
    public class FunctionData : IFunction
    {
        private readonly GmmContext context;
        public FunctionData(GmmContext _context)
        {
            context = _context;
        }
        public ICollection<Function> GetAll()
        {
            return context.Functions.ToList();
        }

        public Function GetById(int id)
        {
            return context.Functions.Where(f => f.Id == id).Single();
        }

        public void Save(Function function)
        {
            context.Functions.Add(function);
            context.SaveChanges();
        }
    }
}
