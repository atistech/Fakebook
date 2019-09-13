using Fakebook.BusinessLogicLayer.Concrete;
using Fakebook.EntitiesLayer.Entities;
using Fakebook.PresentationLayer.Areas.Member.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Fakebook.PresentationLayer.Areas.Member.Controllers
{
    public class HomeController : Controller
    {
        PostBLL postBLL = new PostBLL();
        UserBLL userBLL = new UserBLL();
        LikeBLL likeBLL = new LikeBLL();
        ProfileImageBLL profileImageBLL = new ProfileImageBLL();
        // GET: Member/Home
        public ActionResult Home()
        {
            List<PostVM> list = new List<PostVM>();
            List<Post> ls = postBLL.getAllPostsByUserID(new Guid(HttpContext.User.Identity.Name));
            foreach(Post p in ls)
            {
                PostVM postVM = new PostVM();
                postVM.OwnerImage = profileImageBLL.GetProfileImageByUserID(p.User.ID).Image.Base64;
                postVM.OwnerName = p.User.FirstName + " " + p.User.LastName;
                postVM.PostDate = p.PostDate;
                postVM.TextContent = p.TextContent;
                postVM.ImageContent = p.ContentImage.Base64;
                postVM.LikesCount = likeBLL.LikesCountByPostID(p.ID);
                postVM.CommentsCount = p.Comments.Count;
                list.Add(postVM);
            }
            return View(list);
        }

        [HttpGet]
        public JsonResult GetCurrentUser()
        {
            User u = userBLL.GetByID(new Guid(HttpContext.User.Identity.Name));
            CurrentUserVM current = new CurrentUserVM();
            current.FullName = u.FirstName + " " + u.LastName;
            current.ProfileImage = profileImageBLL.GetProfileImageByUserID(u.ID).Image.Base64;
            var json = new JavaScriptSerializer().Serialize(current);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PostLiked(Guid id)
        {

            return View();
        }

        [HttpPost]
        public ActionResult CommentLiked(Guid id)
        {
            return View();
        }
    }
}