using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fakebook.PresentationLayer.Areas.Admin.ViewModels
{
    public class PostVM
    {
        public Guid ID { get; set; }
        public string ImageContent { get; set; }
        public string TextContent { get; set; }
    }
}