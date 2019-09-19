using Fakebook.EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fakebook.PresentationLayer.Areas.Member.ViewModels
{
    public class PostVM
    {
        public PostVM()
        {
            Comments = new List<UserCommentVM>();
        }
        public Guid PostID { get; set; }
        public string OwnerImage { get; set; }
        public string OwnerName { get; set; }
        public DateTime PostDate { get; set; }
        public string TextContent { get; set; }
        public string ImageContent { get; set; }
        public int LikesCount { get; set; }
        public int CommentsCount { get; set; }
        public bool UserLikeStatus { get; set; }
        public List<UserCommentVM> Comments { get; set; }
    }
}