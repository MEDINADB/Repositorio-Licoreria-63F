
using LiqourStore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiqourStore.Persistence.EntitiesConfigurations
{
    public class ProveedorConfiguration : EntityTypeConfiguration<Proveedor> 
    {

        public ProveedorConfiguration()
        {
            //Table Configurations
            ToTable("Proveedores");
            HasKey(c => c.ProveedorId);

            Property(c => c.DireccionProveedor)
               .IsRequired()
               .HasMaxLength(50);
           


            //Relations Configurations 
            HasMany(c => c.Compras)
                .WithMany(c => c.Proveedores)
             .Map(m =>
              {
                  m.ToTable("ProveedoresCompras");
                  m.MapLeftKey("ProveedorId");
                  m.MapRightKey("CompraId");
              });
        }
    }
}
