using Library_Management_System.Interfaces;
using Library_Management_System.Models.DATA;
using Library_Management_System.Models.entities;
using Library_Management_System.Models.Entities;
using Library_Management_System.Repo;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetSection("constr").Value);
}
);
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option=>
    {
    option.Password.RequiredLength = 4;
    option.Password.RequireDigit = false;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireUppercase = false;
    }
).AddEntityFrameworkStores<AppDbContext>();


builder.Services.AddScoped<IBorrowRepository, Borrow_Repo>();
builder.Services.AddScoped<IBookRepository, Book_Repo>();
builder.Services.AddScoped<IMemberRepository, Member_Repo>();
builder.Services.AddScoped<ICategoryRepository, Category_Repo>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();



app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
