using BusinessFacade;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Data
{
    public interface IStage
    {
        ICollection<Stage> GetAll();
        Stage GetById(int id);
        void Save(Stage stage);
    }
    public class StageData : IStage
    {
        private readonly GmmContext context;
        public StageData(GmmContext _context)
        {
            context = _context;
        }
        public ICollection<Stage> GetAll()
        {
            return context.Stages.ToList();
        }

        public Stage GetById(int id)
        {
            return context.Stages.Where(s => s.Id == id).Single();
        }

        public void Save(Stage stage)
        {
            context.Stages.Add(stage);
            context.SaveChanges();
        }
    }
}
