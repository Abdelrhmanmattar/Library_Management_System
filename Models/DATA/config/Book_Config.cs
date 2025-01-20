using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using Library_Management_System.Models.Entities;
namespace Library_Management_System.Models.DATA.config
{
    public class Book_Config : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");

            builder.HasKey(p => p.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd().IsRequired(true);

            builder.Property(b => b.Title)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50).IsRequired(true);

            builder.Property(b => b.Author)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50).IsRequired(true);
            //ISBN MUST BE 13
            builder.Property(b => b.ISBN).HasColumnType("CHAR(13)")
                .IsFixedLength(true).IsRequired(false);


            builder.Property(b => b.Genre)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50).IsRequired(true);

            builder.Property(b => b.PublishDate)
                .HasColumnType("DATE")
                .IsRequired(true);

            builder.Property(x => x.Category_ID)
                .IsRequired(true);

            builder.HasData(GetSeedBooks());
        }
        private List<Book> GetSeedBooks()
        {
            return new List<Book>
            {
        new Book
        {
            Id = 1,
            Title = "To Kill a Mockingbird",
            Author = "Harper Lee",
            ISBN = "9780061120084",
            Genre = "Fiction",
            PublishDate = new DateOnly(1960, 7, 11),
            Category_ID = 1
        },
        new Book
        {
            Id = 2,
            Title = "1984",
            Author = "George Orwell",
            ISBN = "9780451524935",
            Genre = "Dystopian",
            PublishDate = new DateOnly(1949, 6, 8),
            Category_ID = 2
        },
        new Book
        {
            Id = 3,
            Title = "The Great Gatsby",
            Author = "F. Scott Fitzgerald",
            ISBN = "9780743273565",
            Genre = "Classic",
            PublishDate = new DateOnly(1925, 4, 10),
            Category_ID = 3
        },
        new Book
        {
            Id = 4,
            Title = "The Catcher in the Rye",
            Author = "J.D. Salinger",
            ISBN = "9780316769488",
            Genre = "Fiction",
            PublishDate = new DateOnly(1951, 7, 16),
            Category_ID = 1
        },
        new Book
        {
            Id = 5,
            Title = "Brave New World",
            Author = "Aldous Huxley",
            ISBN = "9780060850524",
            Genre = "Dystopian",
            PublishDate = new DateOnly(1932, 8, 30),
            Category_ID = 2
        }
        };
        }
    }

}
