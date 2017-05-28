using LiqourStore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiqourStore.Persistence.EntitiesConfigurations
{
    public class VentaConfiguration : EntityTypeConfiguration<Venta>
    {
        public VentaConfiguration()
        {
            //Table Configurations
            ToTable("Ventas");
            HasKey(c => c.VentaId);

            Property(v => v.Fecha)
                .IsRequired()
                .HasMaxLength(50);


            //Relations Configurations



            HasRequired(c => c.Empleado)
               .WithMany(c => c.Ventas);


            HasRequired(c => c.Cliente)
               .WithMany(c => c.Ventas);
              




        }
    }
}