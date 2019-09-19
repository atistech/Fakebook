using Fakebook.CoreLayer.EntitiesLayer;
using System;
using System.Collections.Generic;

namespace Fakebook.EntitiesLayer.Entities
{
    public class Comment : CoreEntity
    {
        public string TextContent { get; set; }
        public Guid? PostID { get; set; }
        public Guid? UserID { get; set; }
    }
}
