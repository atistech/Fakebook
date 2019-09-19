using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fakebook.PresentationLayer.Areas.Member.ViewModels
{
    public class UserCommentVM
    {
        public Guid CommentID { get; set; }
        public string FullName { get; set; }
        public string UserProfile { get; set; }
        public string CommentText { get; set; }
    }
}