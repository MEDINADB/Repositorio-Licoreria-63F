using LiqourStore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiqourStore.Persistence.EntitiesConfigurations
{
    class MarcaConfiguration  : EntityTypeConfiguration<Marca>
    {
        public MarcaConfiguration()
        {
            //Table Configurations
            ToTable("Marcas");
            HasKey(c => c.MarcaId);

          

            Property(v => v.NombreMarca)
                .IsRequired()
                .HasMaxLength(50);
            Property(c => c.LogoMarca)
                .IsRequired()
                .HasMaxLength(50);
           

        }
    }
}
