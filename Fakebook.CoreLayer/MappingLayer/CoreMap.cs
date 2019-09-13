using Fakebook.CoreLayer.EntitiesLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakebook.CoreLayer.MappingLayer
{
    public class CoreMap<T> : EntityTypeConfiguration<T> where T : CoreEntity
    {
        public CoreMap()
        {
            Property(core => core.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(core => core.Status).IsOptional();

            //Eklemede kullanılan propertylerin mapleri
            Property(core => core.CreatedDate).HasColumnType("datetime2").IsOptional();
            Property(core => core.CreatedBy).IsOptional();

            //Güncellemede kullanılan propertylerin mapleri
            Property(core => core.ModifiedDate).HasColumnType("datetime2").IsOptional();
            Property(core => core.ModifiedBy).IsOptional();
        }
    }
}
