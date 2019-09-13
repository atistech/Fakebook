using Fakebook.CoreLayer.MappingLayer;
using Fakebook.EntitiesLayer.Entities;

namespace Fakebook.MappingLayer.Mapping
{
    public class UserMap : CoreMap<User>
    {
        public UserMap()
        {
            ToTable("dbo.Users");
        }
    }
}
