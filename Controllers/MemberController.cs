using Library_Management_System.Interfaces;
using Library_Management_System.Models.Entities;
using Library_Management_System.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        private readonly IMemberRepository Dbmember;
        private readonly IBorrowRepository borrowRepository;

        public MemberController(IMemberRepository dbmember , IBorrowRepository borrowRepository)
        {
            this.Dbmember = dbmember;
            this.borrowRepository = borrowRepository;
        }
        public IActionResult Index()
        {
            return Members();
        }
        public IActionResult Members() 
        {
            return View("Members",Dbmember.Get_All());
        }
        public IActionResult Get(int id)
        {
            if(ModelState.IsValid)
            {
                Member member = Dbmember.GetById(id);
                
                if (member!=null)
                {
                    List<Member_Borrows> member_Borrows = borrowRepository.Member_Borrows(id);
                    ViewData["member_name"] = member.FName+" "+member.LName;
                    ViewData["Phone"] =member.Phone;
                    return View("Get", member_Borrows);
                }
            }
            return RedirectToAction("Error", "Home");
        }
        public IActionResult NEW()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddMember(Member member)
        {
            if(ModelState.IsValid)
            {
                Dbmember.Add(member);
                Dbmember.Save();
                ViewData["added"] = $"{ member.FName} {member.LName} is added successfully";
                return View("NEW");
            }
            return RedirectToAction("Error", "Home");
        }

        public IActionResult Edit(int id)
        {
            if(ModelState.IsValid)
            {
                Member member = Dbmember.GetById(id);
                if(member!=null)
                {
                    ViewData["edited"] = $"{member.FName} {member.LName} is edited successfully";
                    return View("Edit", member);
                }
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditMember(Member member)
        {
            if(ModelState.IsValid)
            {
                Dbmember.Update(member);
                Dbmember.Save();
                ViewData["edited"] = $"{member.FName} {member.LName} is edited successfully";
                return View("Members", Dbmember.Get_All());
            }
            return RedirectToAction("Error", "Home");
        }
        public IActionResult Delete(int id)
        {
            if(ModelState.IsValid)
            {
                Member member = Dbmember.GetById(id);
                    Dbmember.Remove(id);
                    Dbmember.Save();
                    ViewData["deleted"] = $"{member.FName} {member.LName} is deleted successfully";
                    return View("Members");
            }
            return RedirectToAction("Error", "Home");
        }

    }
}
