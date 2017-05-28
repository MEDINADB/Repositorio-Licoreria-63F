using LiqourStore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiqourStore.Persistence.EntitiesConfigurations
{
    public class CompraConfiguration  : EntityTypeConfiguration<Compra>
    {

        public CompraConfiguration()
        {
            //Table Configurations
            ToTable("Compras");
            HasKey(c => c.CompraId);

            Property(c => c.DescripcionCompra)
               .IsRequired()
               .HasMaxLength(100);
           
        }
    }
}
