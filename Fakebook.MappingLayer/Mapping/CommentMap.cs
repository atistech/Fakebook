using Fakebook.CoreLayer.MappingLayer;
using Fakebook.EntitiesLayer.Entities;

namespace Fakebook.MappingLayer.Mapping
{
    public class CommentMap : CoreMap<Comment>
    {
        public CommentMap()
        {
            ToTable("dbo.Comments");
        }
    }
}
