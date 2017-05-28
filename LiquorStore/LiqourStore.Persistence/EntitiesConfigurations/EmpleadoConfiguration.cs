using LiqourStore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiqourStore.Persistence.EntitiesConfigurations
{
    public  class EmpleadoConfiguration : EntityTypeConfiguration<Empleado>
    {
        public EmpleadoConfiguration()
        {
            //Table Configurations
            ToTable("Empleados");
            HasKey(c => c.EmpleadoId);
  
            Property(c => c.Nombres)
                .IsRequired()
                .HasMaxLength(50);
            Property(c => c.ApePaterno)
                .IsRequired()
                .HasMaxLength(100);
            Property(c => c.ApeMaterno)
                .IsRequired()
                .HasMaxLength(100);
            Property(c => c.Sexo)
                .IsRequired()
                .HasMaxLength(25);
            Property(c => c.Estado)
                .IsRequired()
                .HasMaxLength(200);
            Property(c=> c.Direccion)
                .IsRequired()
                .HasMaxLength(255);
            Property(c=> c.Correo)
                .IsRequired()
                .HasMaxLength(150);

        }
    }
}
