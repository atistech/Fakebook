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
        CommentBLL commentBLL = new CommentBLL();
        ProfileImageBLL profileImageBLL = new ProfileImageBLL();
        CoverImageBLL coverImageBLL = new CoverImageBLL();
        // GET: Member/Home
        public ActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult GetPosts()
        {
            List<PostVM> list = new List<PostVM>();
            List<Post> ls = postBLL.getAllPostsByUserID(new Guid(HttpContext.User.Identity.Name));
            foreach(Post p in ls)
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
                postVM.UserLikeStatus = likeBLL.UserLikeStatus(Guid.Parse(HttpContext.User.Identity.Name), p.ID);
                postVM.Comments = GetComments(p.ID);
                list.Add(postVM);
            }

            return PartialView("PostArea", list);
        }

        [HttpGet]
        public JsonResult GetCurrentUser()
        {
            User u = userBLL.GetByID(new Guid(HttpContext.User.Identity.Name));
            CurrentUserVM current = new CurrentUserVM();
            current.FullName = u.FirstName + " " + u.LastName;
            current.ProfileImage = profileImageBLL.GetProfileImageByUserID(u.ID).Image.Base64;
            current.CoverImage = coverImageBLL.GetCoverImageByUserID(u.ID).Image.Base64;
            current.Email = u.Email;
            var json = new JavaScriptSerializer().Serialize(current);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void PostLike(Guid id)
        {
            likeBLL.Add(Guid.Parse(HttpContext.User.Identity.Name), id);
        }

        [HttpPost]
        public void PostUnlike(Guid id)
        {
            likeBLL.Remove(id);
        }

        [HttpGet]
        public JsonResult UserLikeStatus(Guid id)
        {
            bool result = likeBLL.UserLikeStatus(Guid.Parse(HttpContext.User.Identity.Name), id);
            var json = new JavaScriptSerializer().Serialize(result);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void AddComment(CommentVM c)
        {
            Comment newC = new Comment();
            newC.ID = Guid.NewGuid();
            newC.TextContent = c.TextContent;
            newC.PostID = c.PostID;
            newC.UserID = new Guid(HttpContext.User.Identity.Name);
            commentBLL.Add(newC);
            if (postBLL.Get(c.PostID) != null)
            {
                postBLL.Get(c.PostID).Comments.Add(newC);
            }
        }
        
        public List<UserCommentVM> GetComments(Guid postID)
        {
            List<UserCommentVM> ls = new List<UserCommentVM>();
            foreach (var c in commentBLL.GetCommentsByPostID(postID))
            {
                User u = userBLL.Get(c.UserID.Value);
                ls.Add(new UserCommentVM {
                    CommentID = c.ID, 
                    FullName = u.FirstName+" "+u.LastName,
                    UserProfile = profileImageBLL.GetProfileImageByUserID(u.ID).Image.Base64,
                    CommentText = c.TextContent
                });
            }
            return ls;
        }

        [HttpPost]
        public void AddPost(PostVM c)
        {
            postBLL.Add(new Post {
                ID = Guid.NewGuid(),
                TextContent = c.TextContent,
                ContentImage = new Image {
                    ID = Guid.NewGuid(),
                    Base64 = c.ImageContent
                },
                UserID = new Guid(HttpContext.User.Identity.Name)
            });
        }
    }
}