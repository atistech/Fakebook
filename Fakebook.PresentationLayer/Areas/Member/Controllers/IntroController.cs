using Fakebook.BusinessLogicLayer.Concrete;
using Fakebook.EntitiesLayer.Entities;
using Fakebook.PresentationLayer.Areas.Member.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fakebook.PresentationLayer.Areas.Member.Controllers
{
    public class IntroController : Controller
    {
        UserBLL userBLL = new UserBLL();
        ProfileImageBLL profileImageBLL = new ProfileImageBLL();
        CoverImageBLL coverImageBLL = new CoverImageBLL();
        // GET: Member/Intro
        public ActionResult Intro()
        {
            User u = userBLL.GetByID(new Guid(HttpContext.User.Identity.Name));
            IntroVM intro = new IntroVM();
            intro.FirstName = u.FirstName;
            intro.LastName = u.LastName;
            /*intro.ProfileImage = profileImageBLL.GetProfileImageByUserID(u.ID).Image.Base64;
            intro.CoverImage = coverImageBLL.GetCoverImageByUserID(u.ID).Image.Base64;*/
            intro.Email = u.Email;
            intro.Password = u.Password;
            return View(intro);
        }

        [HttpPost]
        public ActionResult SaveChanges(IntroVM i)
        {
            User u = userBLL.GetByID(new Guid(HttpContext.User.Identity.Name));
            u.FirstName = i.FirstName;
            u.LastName = i.LastName;
            u.Email = i.Email;
            u.Password = i.Password;
            userBLL.Update(u);
            return RedirectToAction("Intro");
        }
    }
}