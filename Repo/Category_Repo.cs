using Library_Management_System.Interfaces;
using Library_Management_System.Models.DATA;
using Library_Management_System.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Repo
{
    public class Category_Repo : ICategoryRepository
    {
        public AppDbContext DbContext { get; set; }
        public Category_Repo(AppDbContext appDb)
        {
            DbContext = appDb;
        }


        public int Category_Count()
        {
            return DbContext.Categories.Count();
        }
        public void Add(Category entity)
        {
            DbContext.Add(entity);
        }

        public Category GetById(int id)
        {
            Category category = DbContext.Categories.AsNoTracking().FirstOrDefault(c => c.Id == id);
            return category;
        }

        public List<Category> Get_All()
        {
            return DbContext.Categories.AsNoTracking().ToList();
        }

        public void Remove(int id)
        {
            DbContext.Remove(GetById(id));
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }

        public void Update(Category entity)
        {
            DbContext.Update(entity);
        }

        public bool find(int id)
        {
            return DbContext.Categories.Any(c => c.Id == id);
        }
        public bool IsExist(string name)
        {
            return DbContext.Categories.Any(c => c.Name.ToLower() == name.ToLower());
        }
    }
}
