using Fakebook.CoreLayer.MappingLayer;
using Fakebook.EntitiesLayer.Entities;

namespace Fakebook.MappingLayer.Mapping
{
    public class LikeMap : CoreMap<Like>
    {
        public LikeMap()
        {
            ToTable("dbo.Likes");
        }
    }
}
