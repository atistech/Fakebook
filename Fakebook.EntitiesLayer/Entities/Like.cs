using Fakebook.CoreLayer.EntitiesLayer;
using System;

namespace Fakebook.EntitiesLayer.Entities
{
    public class Like : CoreEntity
    {
        public Guid? UserID { get; set; }
        public Guid? PostID { get; set; }
    }
}
