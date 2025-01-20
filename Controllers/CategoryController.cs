using Library_Management_System.Interfaces;
using Library_Management_System.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository caContext;
        private readonly IBookRepository bDbcontex;

        public CategoryController(ICategoryRepository CaContext , IBookRepository bDbcontex )
        {
            this.caContext = CaContext;
            this.bDbcontex = bDbcontex;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return Get_all();
        }
        [AllowAnonymous]
        public IActionResult Get_all()
        {
            IEnumerable<Category> categories = caContext.Get_All();
            return View("Get_all",categories);
        }
        [AllowAnonymous]
        public IActionResult Get(int id)
        {
            if (ModelState.IsValid)
            {
                List<Book> category = bDbcontex.Get_All_By_Category(id);
                Category category1 = caContext.GetById(id);
                ViewData["Name"] = category1.Name;
                ViewData["Description"] = category1.Description;
                return View("Get", category);
            }
            return RedirectToAction("Error", "Home");
        }

        public IActionResult NEW()
        {
            return View("NEW",null);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult NEW_CAT(Category category)
        {
            if(ModelState.IsValid)
            {
                if(caContext.IsExist(category.Name)==false)
                {
                    caContext.Add(category);
                    caContext.Save();
                    ViewData["added"] = category.Name + " is added successfully";
                    return View("NEW", null);
                }
                else
                {
                    ViewData["added"] = category.Name + " is already exist";
                    return View("NEW",category);
                }

            }
            return RedirectToAction("Error", "Home");
        }
    
        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult SaveEdit(Category category)
        {
            if(ModelState.IsValid)
            {
                if(caContext.IsExist(category.Name)==false)
                {
                    caContext.Update(category);
                    caContext.Save();
                    ViewData["edited"] = category.Name + " is updated successfully";
                    return View("Edit");
                }
                else
                {
                    ViewData["edited"] = category.Name + " is already exist";
                    return View("Edit");
                }
            }
            return RedirectToAction("Error", "Home");
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                caContext.Remove(id);
                caContext.Save();
                ViewData["deleted"] = "Category is deleted successfully";
                return RedirectToAction("Get_all");
            }
            return RedirectToAction("Error", "Home");
        }


    }
}
