using Library_Management_System.Interfaces;
using Library_Management_System.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers
{
    [Authorize]
    public class BorrowingController : Controller
    {
        private readonly IBookRepository bookRepository;
        private readonly IMemberRepository memberRepository;
        private readonly IBorrowRepository borrowRepository;

        public BorrowingController(IBookRepository _bookRepository, IMemberRepository _memberRepository,IBorrowRepository _borrowRepository)
        {
            this.bookRepository   = _bookRepository;
            this.memberRepository = _memberRepository;
            this.borrowRepository = _borrowRepository;
        }
        public IActionResult Index()
        {
            ViewData["members"] = memberRepository.Get_All();
            ViewData["books"] = bookRepository.Avaliable_Books();
            ViewData["Borrowed_Books"] = borrowRepository.Borrowed_Books();
            return View();
        }

        [HttpPost]
        public IActionResult Borrow(int MemberId,int bookId)
        {
            if(ModelState.IsValid)
            {
                if(bookRepository.find(bookId)!=false && memberRepository.find(MemberId)!=false)
                {
                    borrowRepository.Borrow(MemberId, bookId);
                    borrowRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpPost]
        public IActionResult Return(int returId)
        {
            if(ModelState.IsValid)
            {
                if(borrowRepository.find(returId) !=false)
                {
                    Borrowing borrowing = borrowRepository.DUE_Return(returId);
                    borrowRepository.Update(borrowing);
                    borrowRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Error", "Home");

        }


    }

}
