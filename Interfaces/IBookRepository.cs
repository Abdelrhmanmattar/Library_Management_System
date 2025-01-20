using Library_Management_System.Models.Entities;

namespace Library_Management_System.Interfaces
{
    public interface IBookRepository:CRUDs<Book>
    {
        public List<Book> Get_All_By_Category(int id);
        public List<Book> Avaliable_Books();
        public int Book_Count();
    }
}
