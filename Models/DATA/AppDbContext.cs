using Library_Management_System.Models.entities;
using Library_Management_System.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Models.DATA
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var config_file = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();

            var constr = config_file.GetSection("constr").Value;
            optionsBuilder.UseSqlServer(constr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.Category_ID);

            modelBuilder.Entity<Borrowing>()
                .HasOne(b => b.Member)
                .WithMany(m => m.Borrowings)
                .HasForeignKey(b => b.Member_ID);

            modelBuilder.Entity<Borrowing>()
                .HasOne(b => b.Book)
                .WithMany(b => b.Borrowings)
                .HasForeignKey(b => b.Book_ID);

            modelBuilder.ApplyConfigurationsFromAssembly((typeof(AppDbContext).Assembly));

        }
    }
}
