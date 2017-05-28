using LiqourStore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiqourStore.Persistence.EntitiesConfigurations
{
   public  class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            //Table Configurations
            ToTable("Cliente");
            HasKey(c => c.ClienteId);

            Property(c => c.Nombres)
               .IsRequired()
               .HasMaxLength(100);
            Property(c => c.ApeMaterno)
                .IsRequired()
                .HasMaxLength(100);
            Property(c => c.ApePaterno)
                .IsRequired()
                .HasMaxLength(100);
            Property(c => c.Direccion)
                .IsRequired()
                .HasMaxLength(150);
            Property(c => c.Sexo)
                .IsRequired()
                .HasMaxLength(50);
            Property(c=> c.Correo)
                .IsRequired()
                .HasMaxLength(100);

        }
    }
}
