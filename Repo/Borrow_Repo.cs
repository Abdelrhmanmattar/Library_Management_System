using Library_Management_System.Interfaces;
using Library_Management_System.Models.DATA;
using Library_Management_System.Models.Entities;
using Library_Management_System.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Repo
{
    public class Borrow_Repo : IBorrowRepository
    {
        AppDbContext DbContext;
        public Borrow_Repo(AppDbContext dbContext)
        {

            DbContext = dbContext;
        }
        public void Add(Borrowing entity)
        {
            DbContext.Add(entity);
        }
        public Borrowing GetById(int id)
        {
            Borrowing borrowing = DbContext.Borrowings.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return borrowing;
        }

        public List<Borrowing> Get_All()
        {
            return DbContext.Borrowings.AsNoTracking().ToList();
        }

        public void Remove(int id)
        {
            DbContext.Remove(GetById(id));
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }

        public void Update(Borrowing entity)
        {
            DbContext.Update(entity);
        }
        public bool find(int id)
        {
            return DbContext.Borrowings.Any(b => b.Id == id);
        }
        public List<Member_Borrows> Member_Borrows(int member_id)
        {
            List<Member_Borrows> member_Borrows =
                DbContext.Borrowings.Where(b => b.Member_ID == member_id)
                .Include(b => b.Book)
                .Select(m_b => new Member_Borrows
                {
                    Author = m_b.Book.Title,
                    Title = m_b.Book.Author,
                    Borrow_Date = m_b.Borrow_Date,
                    Due_Date = m_b.Due_Date
                }
                ).ToList();
            return member_Borrows;
        }

        public List<Books_borrow_VM> Borrowed_Books()
        {
            List<Books_borrow_VM> books = DbContext.Books.AsNoTracking()
                .Join(DbContext.Borrowings
                , b => b.Id
                , bo => bo.Book_ID
                , (b, bo) => new { b, bo }
                ).Where(com=>com.bo.Due_Date==null)
                .Join(DbContext.Members
                , outer => outer.bo.Member_ID
                , m => m.Id
                , (outer, m) => new Books_borrow_VM
                {
                    Id = outer.bo.Id,
                    Mem_Id = m.Id,
                    Book_Id = outer.bo.Book_ID,
                    Mem_Name = m.FName + ' ' + m.LName,
                    Book_title = outer.b.Title,
                    Book_isbn = outer.b.ISBN,
                    Borrow_Date = outer.bo.Borrow_Date,
                }
                )
                .ToList();
            return books;
        }
        public int Borrow_Count()
        {
            int books = DbContext.Borrowings.AsNoTracking()
                .Join(DbContext.Books
                , bo => bo.Book_ID
                , b => b.Id
                , (bo, b) => new { bo, b }
                )
                .Where(c => c.bo.Due_Date == null)
                .AsEnumerable()
                .DistinctBy(c => c.bo.Book_ID).Count();
            return books;
        }
        public void Borrow(int member_id, int book_id)
        {
            var check_book = DbContext.Books.Any(b=>b.Id==book_id);
            var check_member = DbContext.Members.Any(m => m.Id == member_id);
            if(!check_book || !check_member)
            {
                throw new Exception("Member or Book not found");
            }

            Borrowing borrowing = new Borrowing();
            borrowing.Member_ID = member_id;
            borrowing.Book_ID = book_id;
            borrowing.Borrow_Date = DateTime.Now;
            borrowing.Return_Date = DateTime.Now.AddDays(14);
            borrowing.Due_Date = null;
            borrowing.Fine_Amout = 0;
            DbContext.Add(borrowing);
        }
        
        public Borrowing DUE_Return(int borrow_id)
        {
            Borrowing borrowing = DbContext.Borrowings.FirstOrDefault(Return => Return.Id == borrow_id);
            if (borrowing == null) return null;

            borrowing.Due_Date = DateTime.Now;
            var number_of_days = (borrowing.Due_Date.Value - borrowing.Return_Date).Days;
            if (number_of_days > 0)
            {
                int fine = 0;
                int.TryParse(Global.Get_value("fine"), out fine);
                if (fine == 0) fine = 1;
                borrowing.Fine_Amout = number_of_days * fine;
            }
            return borrowing;
        }
        public List<Borrowing> Track_borrow_member(int member_id)
        {
            return DbContext.Borrowings.Where(b => b.Member_ID == member_id).ToList();
        }
        public List<Borrowing> Track_borrow_book(int book_id)
        {
            return DbContext.Borrowings.Where(b => b.Book_ID == book_id).ToList();
        }
    }
}
