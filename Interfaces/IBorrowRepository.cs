using Library_Management_System.Models.Entities;
using Library_Management_System.Models.ViewModel;

namespace Library_Management_System.Interfaces
{
    public interface IBorrowRepository:CRUDs<Borrowing>
    {
        public int Borrow_Count();
        public List<Member_Borrows> Member_Borrows(int member_id);
        public void Borrow(int member_id, int book_id);
        public List<Books_borrow_VM> Borrowed_Books();
        public Borrowing DUE_Return(int borrow_id);
        public List<Borrowing> Track_borrow_member(int member_id);
        public List<Borrowing> Track_borrow_book(int book_id);
    }
}
