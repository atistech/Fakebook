using Fakebook.CoreLayer.EntitiesLayer;
using System;

namespace Fakebook.EntitiesLayer.Entities
{
    public class Like : CoreEntity
    {
        public Guid? OwnerID { get; set; }
        public Guid? ItemID { get; set; }
    }
}
