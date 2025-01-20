using Library_Management_System.Models.entities;
using Library_Management_System.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Library_Management_System.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> manager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private  List<string> Users_not_admin = new List<string>();

        public AccountController(UserManager<ApplicationUser> manager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.manager = manager;
            this.signInManager = signInManager;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            string? currentUserName = User.Identity?.Name;

            Users_not_admin = manager.Users.Where(u => u.UserName != currentUserName)
                .Select(u => u.UserName ?? "Unknown")
                .ToList();
        }


        #region Register
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveRegister(Regisiter_view_model regisiter_View)
        {
            if(ModelState.IsValid==true)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = regisiter_View.UserName;
                user.PasswordHash = regisiter_View.Password;

                var check_username = await manager.FindByNameAsync(regisiter_View.UserName);
                if (check_username == null) 
                {
                    IdentityResult result = await manager.CreateAsync(user, regisiter_View.Password);
                    if (result.Succeeded == true)
                    {
                        await manager.AddToRoleAsync(user, "User");
                        ViewData["added"] = regisiter_View.UserName + " is added successfully";
                        return View("Register");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                return View("Register", regisiter_View);
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
        #endregion

        #region login 
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Check_Login(Login_view_model login_View_)
        {
            if(ModelState.IsValid==true)
            {
                ApplicationUser applicationUser =
                    await manager.FindByNameAsync(login_View_.UserName);

                if(applicationUser != null)
                {
                    bool chech = await manager.CheckPasswordAsync(applicationUser, login_View_.Password);
                    if(chech==true)
                    {
                        await signInManager.SignInAsync(applicationUser, login_View_.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "UserName or Password is wrong");
            }
            return View("Login", login_View_);
        }
        #endregion

        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        #region settings
        [Authorize]
        public async Task<IActionResult> Setting()
        {
            ApplicationUser? user = await manager.FindByNameAsync(User.Identity.Name);
            if(User.IsInRole("Admin"))
            {
                ViewData["Users"] = Users_not_admin;
            }
            return View("Setting", new Edit_User_View_Model { UserName = user?.UserName?? "Unknown" });
        }
        [Authorize]
        public async Task<IActionResult> User_Setting(Edit_User_View_Model edit_User)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser? user          = await manager.FindByNameAsync(edit_User.UserName);
                ApplicationUser? orginial_user = await manager.FindByNameAsync(User.Identity.Name);
                bool check_pass = await manager.CheckPasswordAsync(orginial_user, edit_User.old_password);

                if (user != null || check_pass==false)
                {
                    ModelState.AddModelError("", "Name or Password is incorrect");
                    return View("Setting", new Edit_User_View_Model { UserName = edit_User.UserName });
                }
                orginial_user.UserName = edit_User.UserName;
                orginial_user.NormalizedUserName = manager.NormalizeName(edit_User.UserName);
                var passwordChangeResult=await manager.ChangePasswordAsync(orginial_user, edit_User.old_password, edit_User.new_password);
                if(!passwordChangeResult.Succeeded)
                {
                    foreach(var error in passwordChangeResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                        return View("Setting", new Edit_User_View_Model { UserName = edit_User.UserName });
                    }
                }
                var update_user = await manager.UpdateAsync(orginial_user);

                if(!update_user.Succeeded)
                {
                    foreach(var error in update_user.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                        return View("Setting", new Edit_User_View_Model { UserName = edit_User.UserName });
                    }
                }
                return RedirectToAction(actionName: "Index", controllerName: "Home");

            }
            if (User.IsInRole("Admin")) ViewData["Users"] = Users_not_admin;
            return View("Setting", new Edit_User_View_Model { UserName = edit_User.UserName });
        }

        #endregion
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(string name)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser? user = await manager.FindByNameAsync(name);
                if (user != null)
                {
                    await manager.DeleteAsync(user);
                    ViewData["result"] = $"{user.UserName} is Deleted";
                }
                else
                {
                    ViewData["result"] = $"{name} not found";
                }
            }
            return await Setting();
        }
    }
}
