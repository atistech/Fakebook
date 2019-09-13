using Fakebook.CoreLayer.EntitiesLayer;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fakebook.EntitiesLayer.Entities
{
    public class Image : CoreEntity
    {
        [Column(TypeName = "ntext")]
        [MaxLength]
        public string Base64 { get; set; }
    }
}
