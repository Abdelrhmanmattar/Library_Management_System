using Library_Management_System.Models.Entities;

namespace Library_Management_System.Interfaces
{
    public interface ICategoryRepository:CRUDs<Category>
    {
        public bool IsExist(string name);
        public int Category_Count();
    }
}
