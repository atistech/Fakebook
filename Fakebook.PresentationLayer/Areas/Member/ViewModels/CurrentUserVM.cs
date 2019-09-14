using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fakebook.PresentationLayer.Areas.Member.ViewModels
{
    public class CurrentUserVM
    {
        public string FullName { get; set; }
        public string ProfileImage { get; set; }
        public string CoverImage { get; set; }
    }
}