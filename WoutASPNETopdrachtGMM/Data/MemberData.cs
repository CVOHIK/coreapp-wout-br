using BusinessFacade;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Data
{
    public interface IMember
    {
        ICollection<Member> GetAll();
        Member GetById(int id);
        void Save(Member member);
    }
    public class MemberData : IMember
    {
        private readonly GmmContext context;
        public MemberData(GmmContext _context)
        {
            context = _context;
        }
        public ICollection<Member> GetAll()
        {
            return context.Members.ToList();
        }

        public Member GetById(int id)
        {
            return context.Members.Where(m => m.Id == id).Single();
        }

        public void Save(Member member)
        {
            context.Members.Add(member);
            context.SaveChanges();
        }
    }
}
