using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fakebook.PresentationLayer.Areas.Member.ViewModels
{
    public class CommentVM
    {
        public string TextContent { get; set; }
        public Guid PostID { get; set; }
    }
}