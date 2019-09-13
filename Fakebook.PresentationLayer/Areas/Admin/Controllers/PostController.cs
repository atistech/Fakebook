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
    public class PostController : Controller
    {
        PostBLL postBLL = new PostBLL();

        public ActionResult List()
        {
            List<PostVM> ls = new List<PostVM>();
            foreach (Post p in postBLL.GetAllPosts())
            {
                PostVM postVM = new PostVM();
                postVM.ID = p.ID;
                postVM.ImageContent = p.ContentImage.Base64;
                postVM.TextContent = p.TextContent;
                ls.Add(postVM);
            }
            return View(ls);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            Post p = postBLL.GetById(id);
            PostVM postVM = new PostVM();
            postVM.ID = p.ID;
            postVM.ImageContent = p.ContentImage.Base64;
            postVM.TextContent = p.TextContent;
            return View(postVM);
        }

        [HttpPost]
        public ActionResult Edit(PostVM postVM)
        {
            Post p = postBLL.GetById(postVM.ID);
            p.ContentImage.Base64 = postVM.ImageContent;
            p.TextContent = postVM.TextContent;
            postBLL.Update(p);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            postBLL.DeletePost(id);
            return RedirectToAction("List");
        }
    }
}