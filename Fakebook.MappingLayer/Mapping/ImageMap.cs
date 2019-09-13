using Fakebook.CoreLayer.MappingLayer;
using Fakebook.EntitiesLayer.Entities;

namespace Fakebook.MappingLayer.Mapping
{
    public class ImageMap : CoreMap<Image>
    {
        public ImageMap()
        {
            ToTable("dbo.Images");
            Property(x => x.Base64).IsRequired();
        }
    }
}
