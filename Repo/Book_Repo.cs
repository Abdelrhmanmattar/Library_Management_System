using Library_Management_System.Interfaces;
using Library_Management_System.Models.DATA;
using Library_Management_System.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Repo
{
    public class Book_Repo : IBookRepository
    {
        AppDbContext DbContext;
        public Book_Repo(AppDbContext appDb)
        {
            this.DbContext = appDb;
        }
        public int Book_Count()
        {
            return DbContext.Books.Count();
        }
        public void Add(Book entity)
        {
            DbContext.Add(entity);
        }

        public Book GetById(int id)
        {
            Book book = DbContext.Books.AsNoTracking().Include(b=>b.Category).FirstOrDefault(b => b.Id == id);
            return book;
        }

        public List<Book> Get_All()
        {
            List<Book> books = DbContext.Books.AsNoTracking().ToList();
            return books;
        }
        public List<Book> Get_All_By_Category(int id)
        {
            List<Book> books = DbContext.Books.AsNoTracking().Where(b => b.Category_ID == id).ToList();
            return books;
        }
        public List<Book> Avaliable_Books()
        {
            List<Book> books = DbContext.Books.AsNoTracking()
                .GroupJoin(DbContext.Borrowings
                , b => b.Id
                , bo => bo.Book_ID
                , (b, bo) => new { b, bo }
                )
                .Where(res => res.bo.Any(x=>x.Due_Date != null) == true)
                .Select(res => res.b)
                .ToList();
            return books;
        }
        public void Remove(int id)
        {
            DbContext.Remove(GetById(id));
        }
        public bool find(int id)
        {
            return DbContext.Books.Any(b => b.Id == id);
        }
        public void Update(Book entity)
        {
            DbContext.Update(entity);
        }
        public void Save()
        {
            DbContext.SaveChanges();
        }
    }
}
