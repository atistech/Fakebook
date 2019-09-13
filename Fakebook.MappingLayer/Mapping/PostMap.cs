using Fakebook.CoreLayer.MappingLayer;
using Fakebook.EntitiesLayer.Entities;

namespace Fakebook.MappingLayer.Mapping
{
    public class PostMap : CoreMap<Post>
    {
        public PostMap()
        {
            ToTable("dbo.Posts");
            Property(x => x.PostDate).HasColumnType("datetime2").IsRequired();
            Property(x => x.TextContent).IsRequired();
        }
    }
}
