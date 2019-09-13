using Fakebook.CoreLayer.MappingLayer;
using Fakebook.EntitiesLayer.Entities;

namespace Fakebook.MappingLayer.Mapping
{
    public class CoverImageMap : CoreMap<CoverImage>
    {
        public CoverImageMap()
        {
            ToTable("dbo.CoverImages");
        }
    }
}
