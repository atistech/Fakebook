using Fakebook.CoreLayer.MappingLayer;
using Fakebook.EntitiesLayer.Entities;

namespace Fakebook.MappingLayer.Mapping
{
    public class ProfileImageMap : CoreMap<ProfileImage>
    {
        public ProfileImageMap()
        {
            ToTable("dbo.ProfileImages");
        }
    }
}
