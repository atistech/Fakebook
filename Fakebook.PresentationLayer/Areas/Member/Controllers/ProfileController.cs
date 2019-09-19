using Fakebook.BusinessLogicLayer.Concrete;
using Fakebook.EntitiesLayer.Entities;
using Fakebook.PresentationLayer.Areas.Member.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Fakebook.PresentationLayer.Areas.Member.Controllers
{
    public class ProfileController : Controller
    {
        PostBLL postBLL = new PostBLL();
        UserBLL userBLL = new UserBLL();
        LikeBLL likeBLL = new LikeBLL();
        ProfileImageBLL profileImageBLL = new ProfileImageBLL();
        // GET: Member/Profile

        public new ActionResult Profile()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Friends()
        {
            User u = userBLL.Get(new Guid(HttpContext.User.Identity.Name));
            List<FriendsVM> ls = new List<FriendsVM>();
            foreach(var item in u.Users)
            {
                ls.Add(new FriendsVM
                {
                    FullName = item.FirstName + " " + u.LastName,
                    Email = item.Email,
                    ProfilePhoto = profileImageBLL.GetProfileImageByUserID(item.ID).Image.Base64
                });
            }
            return View(ls);
        }

        [HttpGet]
        public ActionResult Photos()
        {
            User u = userBLL.Get(new Guid(HttpContext.User.Identity.Name));
            return View(u.Images);
        }
        
        [HttpGet]
        public PartialViewResult GetPosts()
        {
            List<PostVM> list = new List<PostVM>();
            List<Post> ls = postBLL.getProfilePostsByUserID(new Guid(HttpContext.User.Identity.Name));
            foreach (Post p in ls)
            {
                User u = userBLL.GetByID(p.UserID.Value);
                PostVM postVM = new PostVM();
                postVM.PostID = p.ID;
                postVM.OwnerImage = profileImageBLL.GetProfileImageByUserID(u.ID).Image.Base64;
                postVM.OwnerName = u.FirstName + " " + u.LastName;
                postVM.PostDate = p.PostDate;
                postVM.TextContent = p.TextContent;
                postVM.ImageContent = p.ContentImage.Base64;
                postVM.LikesCount = likeBLL.LikesCount(p.ID);
                postVM.CommentsCount = p.Comments.Count;
                list.Add(postVM);
            }

            return PartialView("PostArea", list);
        }

        [HttpGet]
        public JsonResult GetPhotos()
        {
            User u = userBLL.GetByID(new Guid(HttpContext.User.Identity.Name));
            var json = new JavaScriptSerializer().Serialize(u.Images);
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}