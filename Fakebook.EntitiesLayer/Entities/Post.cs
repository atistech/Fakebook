using Fakebook.CoreLayer.EntitiesLayer;
using System;
using System.Collections.Generic;

namespace Fakebook.EntitiesLayer.Entities
{
    public class Post : CoreEntity
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
            Likes = new HashSet<Like>();
        }
        public DateTime PostDate { get; set; }
        public string TextContent { get; set; }
        public virtual Image ContentImage { get; set; }
        public Guid? UserID { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
    }
}
