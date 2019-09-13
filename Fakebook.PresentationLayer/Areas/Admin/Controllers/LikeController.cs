using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fakebook.PresentationLayer.Areas.Admin.Controllers
{
    public class LikeController : Controller
    {
        // GET: Admin/Like
        public ActionResult Index()
        {
            return View();
        }
    }
}