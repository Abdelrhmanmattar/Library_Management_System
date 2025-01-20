using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using Library_Management_System.Models.Entities;
namespace Library_Management_System.Models.DATA.config
{
    public class Category_Config : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd().IsRequired(true);

            builder.Property(c => c.Name).HasColumnType("NVARCHAR").HasMaxLength(50).IsRequired(true);
            builder.Property(c => c.Name).HasColumnType("NVARCHAR").HasMaxLength(200).IsRequired(true);

            builder.HasData(
               new Category { Id = 1, Name = "Fiction", Description = "Fictional works such as novels and stories." },
               new Category { Id = 2, Name = "Non-Fiction", Description = "Books based on real facts and events." },
               new Category { Id = 3, Name = "Science", Description = "Books related to scientific topics and research." },
               new Category { Id = 4, Name = "Fantasy", Description = "Books with fantastical elements and magic." },
               new Category { Id = 5, Name = "Biography", Description = "Books based on someone's life story." }
           );

        }
    }
}
