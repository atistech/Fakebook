using Fakebook.BusinessLogicLayer.Concrete;
using Fakebook.EntitiesLayer.Entities;
using Fakebook.PresentationLayer.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fakebook.PresentationLayer.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        UserBLL userBLL = new UserBLL();
        ProfileImageBLL p = new ProfileImageBLL();
        // GET: Admin/List
        public ActionResult List()
        {
            List<UserVM> ls = new List<UserVM>();
            foreach (User u in userBLL.GetAllUsers())
            {
                UserVM userVM = new UserVM();
                userVM.ID = u.ID;
                userVM.ProfileImage = p.GetProfileImageByUserID(u.ID).Image.Base64;
                userVM.FirstName = u.FirstName;
                userVM.LastName = u.LastName;
                userVM.Email = u.Email;
                userVM.Password = u.Password;
                userVM.Role = u.Role.ToString();
                ls.Add(userVM);
            }
            return View(ls);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            User u = userBLL.GetByID(id);
            UserVM userVM = new UserVM();
            userVM.ID = u.ID;
            userVM.ProfileImage = p.GetProfileImageByUserID(u.ID).Image.Base64;
            userVM.FirstName = u.FirstName;
            userVM.LastName = u.LastName;
            userVM.Email = u.Email;
            userVM.Password = u.Password;
            userVM.Role = u.Role.ToString();
            return View(userVM);
        }

        [HttpPost]
        public ActionResult Edit(UserVM userVM)
        {
            User u = new User();
            u.ID = userVM.ID;
            ProfileImage pi = p.GetProfileImageByUserID(userVM.ID);
            pi.Image.Base64 = userVM.ProfileImage;
            u.FirstName = userVM.FirstName;
            u.LastName = userVM.LastName;
            u.Email = userVM.Email;
            u.Password = userVM.Password;
            u.Role = (Role)Enum.Parse(typeof(Role), userVM.Role);
            //p.Update(pi);
            userBLL.UpdateUser(u);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            userBLL.DeleteUser(id);
            return RedirectToAction("List");
        }
    }
}