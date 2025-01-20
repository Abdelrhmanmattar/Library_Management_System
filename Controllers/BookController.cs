using Library_Management_System.Interfaces;
using Library_Management_System.Models.Entities;
using Library_Management_System.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private IBookRepository Dbbook;
        private ICategoryRepository DbCategory;

        public BookController(IBookRepository _book , ICategoryRepository cRU)
        {
            Dbbook = _book;
            DbCategory = cRU;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return Get_All();
        }
        [AllowAnonymous]
        public IActionResult Get_All()
        {
            if(ModelState.IsValid)
            {
                List<Book> books = Dbbook.Get_All();
                return View("Get_All", books);
            }
            return RedirectToAction("Error", "Home");
        }
        [AllowAnonymous]
        public IActionResult Get(int id)
        {
            if(ModelState.IsValid)
            {
                Book book = Dbbook.GetById(id);
                if(book!=null)
                {
                    return View("Get",book);
                }
            }
            return RedirectToAction("Error", "Home");
        }


        public IActionResult NEW()
        {
            ViewData["categories"] = DbCategory.Get_All();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult AddBook(Book book)
        {
            if(ModelState.IsValid)
            {
                Dbbook.Add(book);
                Dbbook.Save();
                ViewData["added"]= book.Title + " is added successfully";
                return NEW();
            }
            return RedirectToAction("Error", "Home");
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            if(ModelState.IsValid)
            {
                if(Dbbook.find(id))
                {
                    Dbbook.Remove(id);
                    Dbbook.Save();
                    ViewData["deleted"] = "Book is deleted successfully";
                    return Get_All();
                }
                ViewData["error"]="Book not found";
                return Get_All();
            }
            return RedirectToAction("Error", "Home");
        }

        public IActionResult Edit(int id)
        {
            Book book = Dbbook.GetById(id);
            ViewData["categories"] = DbCategory.Get_All();
            return View("Edit",book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult SaveEdit(Book _book)
        {
            if(ModelState.IsValid)
            {
                if(Dbbook.find(_book.Id))
                {
                    Dbbook.Update(_book);
                    Dbbook.Save();
                    ViewData["edited"] = _book.Title + " is edited successfully";
                    return Get_All();
                }
                ViewData["error"] = "Book not found";
            }
            return RedirectToAction("Error", "Home");
        }
    }
}
