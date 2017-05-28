using LiqourStore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiqourStore.Persistence.EntitiesConfigurations
{
    public class ProductoConfiguration : EntityTypeConfiguration<Producto> 
    {

        public ProductoConfiguration()
        {
            //Table Configurations
            ToTable("Productos");
            HasKey(c => c.ProductoId);

           

            Property(c => c.NombreCliente)
                .IsRequired()
                .HasMaxLength(50);
            Property(c => c.DescripcionProducto)
                .IsRequired()
                .HasMaxLength(100);
           




            //Relations Configurations
            HasMany(c => c.Marcas)
                .WithMany(c => c.Productos)
               .Map(m =>
                {
                    m.ToTable("ProductosMarcass");
                    m.MapLeftKey("MarcasId");
                    m.MapRightKey("ProductoId");
                });


            HasMany(c => c.Tiendas)
                .WithMany(c => c.Productos)
            .Map(m =>
             {
                 m.ToTable("ProductosTiendas");
                 m.MapLeftKey("TiendaId");
                 m.MapRightKey("ProductoId");
             });


            HasMany(c => c.Proveedores)
                .WithMany(c => c.Productos)
                .Map(m =>
                {
                    m.ToTable("ProductosProveedores");
                    m.MapLeftKey("ProveedorId");
                    m.MapRightKey("ProductoId");
                });


            HasMany(c => c.Ventas)
                .WithMany(c => c.Productos)
              .Map(m =>
               {
                   m.ToTable("ProductosVentas");
                   m.MapLeftKey("VentaId");
                   m.MapRightKey("ProductoId");
               });



            //HasMany(c => c.TipoProductos)
            //    .WithRequired(c => c.Producto);
            //     .HasForeignKey(c => c.ProductoId);



        }
    }
}
