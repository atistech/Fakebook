using Fakebook.CoreLayer.EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakebook.EntitiesLayer.Entities
{
    public class ProfileImage : CoreEntity
    {
        public virtual Image Image { get; set; }
        public virtual User User { get; set; }
    }
}
