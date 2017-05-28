using LiqourStore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiqourStore.Persistence.EntitiesConfigurations
{
    public class SucursalConfiguration : EntityTypeConfiguration<Sucursal>
    {

        public SucursalConfiguration()
        {
            //Table Configurations
            ToTable("Sucursales");
            HasKey(c => c.SucursalId);

            Property(c => c.DireccionSucursal)
               .IsRequired()
               .HasMaxLength(50);
          


        }
    }
}
