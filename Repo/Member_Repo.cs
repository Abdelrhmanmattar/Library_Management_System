using Library_Management_System.Interfaces;
using Library_Management_System.Models.DATA;
using Library_Management_System.Models.Entities;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Repo
{
    public class Member_Repo : IMemberRepository
    {
        AppDbContext DbContext;
        public Member_Repo(AppDbContext appDb)
        {
            this.DbContext = appDb;
        }
        public void Add(Member entity)
        {
            DbContext.Add(entity);
        }
        public bool find(int id)
        {
            return DbContext.Members.Any(m => m.Id == id);
        }
        public Member GetById(int id)
        {
            Member member = DbContext.Members.AsNoTracking().FirstOrDefault(m => m.Id == id);
            return member;
        }

        public List<Member> Get_All()
        {
            return DbContext.Members.AsNoTracking().ToList();
        }

        public void Remove(int id)
        {
            DbContext.Remove(GetById(id));
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }

        public void Update(Member entity)
        {
            DbContext.Update(entity);
        }
        public int Member_Count()
        {
            return DbContext.Members.Count();
        }
    }
}
