using Fakebook.CoreLayer.EntitiesLayer;
using System.Collections.Generic;

namespace Fakebook.EntitiesLayer.Entities
{
    public class Comment : CoreEntity
    {
        public Comment()
        {
            Comments = new HashSet<Comment>();
            Likes = new HashSet<Like>();
        }

        public string TextContent { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
    }
}
