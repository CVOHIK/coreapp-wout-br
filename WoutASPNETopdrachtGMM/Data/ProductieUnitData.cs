using BusinessFacade;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Data
{
    public interface IProductieUnit
    {
        ICollection<ProductieUnit> GetAll();
        ProductieUnit GetById(int id);
        void Save(ProductieUnit productieUnit);
    }
    public class ProductieUnitData : IProductieUnit
    {
        private readonly GmmContext context;
        public ProductieUnitData(GmmContext _context)
        {
            context = _context;
        }
        public ICollection<ProductieUnit> GetAll()
        {
            return context.ProductieUnits.ToList();
        }

        public ProductieUnit GetById(int id)
        {
            return context.ProductieUnits.Where(p => p.Id == id).Single();
        }

        public void Save(ProductieUnit productieUnit)
        {
            context.ProductieUnits.Add(productieUnit);
            context.SaveChanges();
        }
    }
}
