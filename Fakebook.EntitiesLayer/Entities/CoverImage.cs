using Fakebook.CoreLayer.EntitiesLayer;

namespace Fakebook.EntitiesLayer.Entities
{
    public class CoverImage : CoreEntity
    {
        public virtual User User { get; set; }
        public virtual Image Image { get; set; }
    }
}
