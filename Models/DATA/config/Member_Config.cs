using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using Library_Management_System.Models.Entities;
namespace Library_Management_System.Models.DATA.config
{
    public class Member_Config : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Member");

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired(true);

            builder.Property(m => m.FName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50).IsRequired(true);

            builder.Property(m => m.LName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50).IsRequired(true);

            builder.Property(m => m.Email)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50).IsRequired(false);

            builder.Property(m => m.Phone)
                .HasColumnType("VARCHAR")
                .HasMaxLength(11).IsRequired(false);

            builder.Property(M => M.Date_of_Membership)
                .HasColumnType("DATE").IsRequired(true);

            builder.HasData(GetSeedMembers());
        }

        private List<Member> GetSeedMembers()
        {
            return new List<Member>
            {
        new Member
        {
            Id = 1,
            FName = "John",
            LName = "Doe",
            Email = "john.doe@example.com",
            Phone = "01234567890",
            Date_of_Membership = new DateTime(2022, 1, 15)
        },
        new Member
        {
            Id = 2,
            FName = "Jane",
            LName = "Smith",
            Email = "jane.smith@example.com",
            Phone = "09876543210",
            Date_of_Membership = new DateTime(2023, 3, 10)
        },
        new Member
        {
            Id = 3,
            FName = "Alice",
            LName = "Johnson",
            Email = "alice.johnson@example.com",
            Phone = "01122334455",
            Date_of_Membership = new DateTime(2021, 6, 20)
        },
        new Member
        {
            Id = 4,
            FName = "Bob",
            LName = "Brown",
            Email = "bob.brown@example.com",
            Phone = "02233445566",
            Date_of_Membership = new DateTime(2020, 11, 5)
        }
            };
        }
    }
}
