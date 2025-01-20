namespace Library_Management_System.Models.Entities
{
    public class Borrowing
    {
        public int Id { get; set; }
        public int Member_ID { get; set; }
        public int Book_ID { get; set; }
        public DateTime Borrow_Date { get; set; }
        public DateTime Return_Date { get; set; }
        public DateTime? Due_Date { get; set; }
        public int? Fine_Amout { get; set; }

        public Member? Member { get; set; }
        public Book? Book { get; set; }

    }

}
