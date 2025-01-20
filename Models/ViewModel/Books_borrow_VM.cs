namespace Library_Management_System.Models.ViewModel
{
    public class Books_borrow_VM
    {
        public int Id { get; set; }
        public int Mem_Id { get; set; }
        public int Book_Id { get; set; }
        public string? Mem_Name { get; set; }
        public string? Book_title { get; set; }
        public string? Book_isbn { get; set; }
        public DateTime Borrow_Date { get; set; }
    }
}
