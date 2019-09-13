using Fakebook.CoreLayer.EntitiesLayer;
using System;

namespace Fakebook.EntitiesLayer.Entities
{
    public class Like : CoreEntity
    {
        public Guid? PostID { get; set; }
        public Post Post { get; set; }
        public Guid? CommentID { get; set; }
        public Comment Comment { get; set; }
    }
}
