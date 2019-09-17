using Fakebook.BusinessLogicLayer.Concrete;
using Fakebook.EntitiesLayer.Entities;
using Fakebook.PresentationLayer.Areas.Member.ViewModels;
using Fakebook.PresentationLayer.ViewModels;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace Fakebook.PresentationLayer.Controllers
{
    public class AccountController : Controller
    {
        private UserBLL _userBLL;
        public AccountController()
        {
            _userBLL = new UserBLL();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            //Session.Remove("sepet");
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                User currentUser = _userBLL.GetByID(new Guid(HttpContext.User.Identity.Name));
                if (currentUser.Role == Role.Admin)
                {
                    return RedirectToAction("List", "User", new { area = "Admin" });
                }
                else if (currentUser.Role == Role.Member)
                {
                    return RedirectToAction("Home", "Home", new { area = "Member" });
                }
                else
                {
                    return RedirectToAction("Register");
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM data)
        {
            if (ModelState.IsValid)
            {
                User currentUser = _userBLL.GetByEmailandPassword(data.Email, data.Password);

                if (currentUser != null)
                {
                    string cookie = ""+currentUser.ID;

                    FormsAuthentication.SetAuthCookie(cookie, true);

                    if (currentUser.Role == Role.Admin)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else if (currentUser.Role == Role.Member)
                    {
                        return RedirectToAction("Home", "Home", new { area = "Member" });
                    }
                    else
                    {
                        //Size Kalmış
                        return RedirectToAction("Register");
                    }


                }
                else
                {
                    return View();
                }

            }
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterVM r)
        {
            User u = new User();
            u.ID = new Guid();
            u.FirstName = r.FirstName;
            u.LastName = r.LastName;
            u.Email = r.Email;
            u.Password = r.Password;
            u.Role = Role.Member;
            _userBLL.Add(u);
            string cookie = "" + u.ID;
            FormsAuthentication.SetAuthCookie(cookie, true);
            return RedirectToAction("Home", "Home", new { area = "Member" });
        }
    }
}