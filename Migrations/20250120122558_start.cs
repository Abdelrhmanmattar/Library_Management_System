using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class start : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    LName = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: true),
                    Date_of_Membership = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Author = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    ISBN = table.Column<string>(type: "CHAR(13)", fixedLength: true, maxLength: 13, nullable: true),
                    Genre = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    PublishDate = table.Column<DateOnly>(type: "DATE", nullable: false),
                    Category_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Category_Category_ID",
                        column: x => x.Category_ID,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Borrowing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Member_ID = table.Column<int>(type: "int", nullable: false),
                    Book_ID = table.Column<int>(type: "int", nullable: false),
                    Borrow_Date = table.Column<DateTime>(type: "DATE", nullable: false),
                    Return_Date = table.Column<DateTime>(type: "DATE", nullable: false),
                    Due_Date = table.Column<DateTime>(type: "DATE", nullable: true),
                    Fine_Amout = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrowing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Borrowing_Book_Book_ID",
                        column: x => x.Book_ID,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Borrowing_Member_Member_ID",
                        column: x => x.Member_ID,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            //insert admin user :
            // Hash the admin password
            var passwordHasher = new PasswordHasher<string>();
            string adminPasswordHash = passwordHasher.HashPassword(null, "admin");
            string adminUserId = Guid.NewGuid().ToString();
            // Insert the admin user
            migrationBuilder.InsertData(
                           table: "AspNetUsers",
                           columns: new[] { "Id", "UserName", "NormalizedUserName", "Email",
                               "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp",
                               "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled",
                               "LockoutEnd", "LockoutEnabled", "AccessFailedCount" },
                           values: new object[]
                           {
                    adminUserId,  // Unique Id for the admin
                    "admin",
                    "ADMIN",
                    null,
                    null,
                    true,
                    adminPasswordHash,
                    Guid.NewGuid().ToString(),
                    Guid.NewGuid().ToString(),
                    null,
                    false,
                    false,
                    null,
                    true,
                    0
                           });
            migrationBuilder.Sql("INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('1', 'Admin', 'ADMIN')");
            migrationBuilder.Sql("INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('2', 'User', 'USER')");


            migrationBuilder.Sql($"INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES ('{adminUserId}', '1')");



            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Fictional works such as novels and stories.", "Fiction" },
                    { 2, "Books based on real facts and events.", "Non-Fiction" },
                    { 3, "Books related to scientific topics and research.", "Science" },
                    { 4, "Books with fantastical elements and magic.", "Fantasy" },
                    { 5, "Books based on someone's life story.", "Biography" }
                });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "Id", "Date_of_Membership", "Email", "FName", "LName", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John", "Doe", "01234567890" },
                    { 2, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane", "Smith", "09876543210" },
                    { 3, new DateTime(2021, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice.johnson@example.com", "Alice", "Johnson", "01122334455" },
                    { 4, new DateTime(2020, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob.brown@example.com", "Bob", "Brown", "02233445566" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Author", "Category_ID", "Genre", "ISBN", "PublishDate", "Title" },
                values: new object[,]
                {
                    { 1, "Harper Lee", 1, "Fiction", "9780061120084", new DateOnly(1960, 7, 11), "To Kill a Mockingbird" },
                    { 2, "George Orwell", 2, "Dystopian", "9780451524935", new DateOnly(1949, 6, 8), "1984" },
                    { 3, "F. Scott Fitzgerald", 3, "Classic", "9780743273565", new DateOnly(1925, 4, 10), "The Great Gatsby" },
                    { 4, "J.D. Salinger", 1, "Fiction", "9780316769488", new DateOnly(1951, 7, 16), "The Catcher in the Rye" },
                    { 5, "Aldous Huxley", 2, "Dystopian", "9780060850524", new DateOnly(1932, 8, 30), "Brave New World" }
                });

            migrationBuilder.InsertData(
                table: "Borrowing",
                columns: new[] { "Id", "Book_ID", "Borrow_Date", "Due_Date", "Fine_Amout", "Member_ID", "Return_Date" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2, new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 3, new DateTime(2023, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 4, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Category_ID",
                table: "Book",
                column: "Category_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowing_Book_ID",
                table: "Borrowing",
                column: "Book_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowing_Member_ID",
                table: "Borrowing",
                column: "Member_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Borrowing");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
