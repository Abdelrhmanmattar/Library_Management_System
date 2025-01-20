using Library_Management_System.Models.Entities;
using Library_Management_System.Models.ViewModel;

namespace Library_Management_System.Interfaces
{
    public interface IMemberRepository:CRUDs<Member>
    {
        public int Member_Count();
    }
}
