using LiqourStore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiqourStore.Persistence.EntitiesConfigurations
{
    public class TiendaConfiguration  : EntityTypeConfiguration<Tienda>
    {
        public TiendaConfiguration()
        {
            //Table Configurations
            ToTable("Tiendas");
            HasKey(c => c.TiendaId);

            Property(c => c.DireccionTienda)
               .IsRequired()
               .HasMaxLength(50);
            

            //Relations Configurations

            HasMany(c => c.Sucursales)
              .WithRequired(c => c.Tienda)
             .HasForeignKey(c => c.TiendaId);

        }
    }
}
