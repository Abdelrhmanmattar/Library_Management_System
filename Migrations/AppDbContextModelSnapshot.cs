﻿// <auto-generated />
using System;
using Library_Management_System.Models.DATA;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Library_Management_System.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Library_Management_System.Models.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR");

                    b.Property<int>("Category_ID")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("ISBN")
                        .HasMaxLength(13)
                        .HasColumnType("CHAR(13)")
                        .IsFixedLength();

                    b.Property<DateOnly>("PublishDate")
                        .HasColumnType("DATE");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR");

                    b.HasKey("Id");

                    b.HasIndex("Category_ID");

                    b.ToTable("Book", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Harper Lee",
                            Category_ID = 1,
                            Genre = "Fiction",
                            ISBN = "9780061120084",
                            PublishDate = new DateOnly(1960, 7, 11),
                            Title = "To Kill a Mockingbird"
                        },
                        new
                        {
                            Id = 2,
                            Author = "George Orwell",
                            Category_ID = 2,
                            Genre = "Dystopian",
                            ISBN = "9780451524935",
                            PublishDate = new DateOnly(1949, 6, 8),
                            Title = "1984"
                        },
                        new
                        {
                            Id = 3,
                            Author = "F. Scott Fitzgerald",
                            Category_ID = 3,
                            Genre = "Classic",
                            ISBN = "9780743273565",
                            PublishDate = new DateOnly(1925, 4, 10),
                            Title = "The Great Gatsby"
                        },
                        new
                        {
                            Id = 4,
                            Author = "J.D. Salinger",
                            Category_ID = 1,
                            Genre = "Fiction",
                            ISBN = "9780316769488",
                            PublishDate = new DateOnly(1951, 7, 16),
                            Title = "The Catcher in the Rye"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Aldous Huxley",
                            Category_ID = 2,
                            Genre = "Dystopian",
                            ISBN = "9780060850524",
                            PublishDate = new DateOnly(1932, 8, 30),
                            Title = "Brave New World"
                        });
                });

            modelBuilder.Entity("Library_Management_System.Models.Entities.Borrowing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Book_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Borrow_Date")
                        .HasColumnType("DATE");

                    b.Property<DateTime?>("Due_Date")
                        .HasColumnType("DATE");

                    b.Property<int?>("Fine_Amout")
                        .HasColumnType("int");

                    b.Property<int>("Member_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Return_Date")
                        .HasColumnType("DATE");

                    b.HasKey("Id");

                    b.HasIndex("Book_ID");

                    b.HasIndex("Member_ID");

                    b.ToTable("Borrowing", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Book_ID = 1,
                            Borrow_Date = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Due_Date = new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fine_Amout = 0,
                            Member_ID = 1,
                            Return_Date = new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Book_ID = 2,
                            Borrow_Date = new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Due_Date = new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fine_Amout = 5,
                            Member_ID = 2,
                            Return_Date = new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Book_ID = 3,
                            Borrow_Date = new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Due_Date = new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fine_Amout = 10,
                            Member_ID = 3,
                            Return_Date = new DateTime(2023, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Book_ID = 4,
                            Borrow_Date = new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Due_Date = new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fine_Amout = 0,
                            Member_ID = 4,
                            Return_Date = new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Library_Management_System.Models.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Fictional works such as novels and stories.",
                            Name = "Fiction"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Books based on real facts and events.",
                            Name = "Non-Fiction"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Books related to scientific topics and research.",
                            Name = "Science"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Books with fantastical elements and magic.",
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Books based on someone's life story.",
                            Name = "Biography"
                        });
                });

            modelBuilder.Entity("Library_Management_System.Models.Entities.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date_of_Membership")
                        .HasColumnType("DATE");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("Phone")
                        .HasMaxLength(11)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Member", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date_of_Membership = new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "john.doe@example.com",
                            FName = "John",
                            LName = "Doe",
                            Phone = "01234567890"
                        },
                        new
                        {
                            Id = 2,
                            Date_of_Membership = new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jane.smith@example.com",
                            FName = "Jane",
                            LName = "Smith",
                            Phone = "09876543210"
                        },
                        new
                        {
                            Id = 3,
                            Date_of_Membership = new DateTime(2021, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "alice.johnson@example.com",
                            FName = "Alice",
                            LName = "Johnson",
                            Phone = "01122334455"
                        },
                        new
                        {
                            Id = 4,
                            Date_of_Membership = new DateTime(2020, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "bob.brown@example.com",
                            FName = "Bob",
                            LName = "Brown",
                            Phone = "02233445566"
                        });
                });

            modelBuilder.Entity("Library_Management_System.Models.entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Library_Management_System.Models.Entities.Book", b =>
                {
                    b.HasOne("Library_Management_System.Models.Entities.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("Category_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Library_Management_System.Models.Entities.Borrowing", b =>
                {
                    b.HasOne("Library_Management_System.Models.Entities.Book", "Book")
                        .WithMany("Borrowings")
                        .HasForeignKey("Book_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library_Management_System.Models.Entities.Member", "Member")
                        .WithMany("Borrowings")
                        .HasForeignKey("Member_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Library_Management_System.Models.entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Library_Management_System.Models.entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library_Management_System.Models.entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Library_Management_System.Models.entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Library_Management_System.Models.Entities.Book", b =>
                {
                    b.Navigation("Borrowings");
                });

            modelBuilder.Entity("Library_Management_System.Models.Entities.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Library_Management_System.Models.Entities.Member", b =>
                {
                    b.Navigation("Borrowings");
                });
#pragma warning restore 612, 618
        }
    }
}
