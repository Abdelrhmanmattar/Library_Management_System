using Microsoft.EntityFrameworkCore;

using Library_Management_System.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Library_Management_System.Models.DATA.config
{
    public class Borrowing_Config : IEntityTypeConfiguration<Borrowing>
    {
        public void Configure(EntityTypeBuilder<Borrowing> builder)
        {
            builder.ToTable("Borrowing");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id).ValueGeneratedOnAdd().IsRequired(true);

            builder.Property(b=>b.Member_ID).IsRequired(true);
            builder.Property(b => b.Book_ID).IsRequired(true);

            builder.Property(b=>b.Borrow_Date).HasColumnType("DATE").IsRequired(true);
            builder.Property(b => b.Return_Date).HasColumnType("DATE").IsRequired(true);
            builder.Property(b => b.Due_Date).HasColumnType("DATE").IsRequired(false);

            builder.Property(B => B.Fine_Amout).IsRequired(false);
            builder.HasData(GetSeedBorrowings());


        }
        private List<Borrowing> GetSeedBorrowings()
        {
            return new List<Borrowing>
            {
        new Borrowing
        {
            Id = 1,
            Member_ID = 1,
            Book_ID = 1,
            Borrow_Date = new DateTime(2023, 12, 1),
            Return_Date = new DateTime(2023, 12, 15),
            Due_Date = new DateTime(2023, 12, 10),
            Fine_Amout = 0
        },
        new Borrowing
        {
            Id = 2,
            Member_ID = 2,
            Book_ID = 2,
            Borrow_Date = new DateTime(2023, 11, 20),
            Return_Date = new DateTime(2023, 12, 5),
            Due_Date = new DateTime(2023, 11, 30),
            Fine_Amout = 5
        },
        new Borrowing
        {
            Id = 3,
            Member_ID = 3,
            Book_ID = 3,
            Borrow_Date = new DateTime(2023, 10, 15),
            Return_Date = new DateTime(2023, 10, 25),
            Due_Date = new DateTime(2023, 10, 20),
            Fine_Amout = 10
        },
        new Borrowing
        {
            Id = 4,
            Member_ID = 4,
            Book_ID = 4,
            Borrow_Date = new DateTime(2023, 9, 5),
            Return_Date = new DateTime(2023, 9, 15),
            Due_Date = new DateTime(2023, 9, 10),
            Fine_Amout = 0
        }
            };
        }
    }

}
