using Library_Management_System.Interfaces;
using Library_Management_System.Models;
using Library_Management_System.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace Library_Management_System.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookRepository book;
        private readonly ICategoryRepository category;
        private readonly IMemberRepository member;
        private readonly IBorrowRepository borrow;

        public HomeController(ILogger<HomeController> logger
            ,IBookRepository _book,ICategoryRepository _category
            ,IMemberRepository _member , IBorrowRepository _borrow)
        {
            _logger = logger;
            book = _book;
            category = _category;
            member = _member;
            borrow = _borrow;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            Counts_Data counts_Data = new Counts_Data();
            counts_Data.Book_nums = book.Book_Count();
            counts_Data.Member_nums = member.Member_Count();
            counts_Data.Category_nums = category.Category_Count();
            counts_Data.Borrow_nums = borrow.Borrow_Count();
            counts_Data.Book_ava = counts_Data.Book_nums - counts_Data.Borrow_nums;

            return View("Index",counts_Data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
