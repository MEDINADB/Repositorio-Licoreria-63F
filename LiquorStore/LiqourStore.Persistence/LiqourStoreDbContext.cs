using LiqourStore.Entities;
using LiqourStore.Persistence.EntitiesConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiqourStore.Persistence
{
    public class LiqourStoreDbContext : DbContext 
    {
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Tienda> Tiendas { get; set; }
        //public DbSet<TipoProducto> TipoProductos { get; set; }
        //public DbSet<TipoVenta> TipoVentas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        //public DbSet<Persona> Personas { get; set; }
        public LiqourStoreDbContext()
			:base("LiquorStore")
		{

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new VentaConfiguration());
            modelBuilder.Configurations.Add(new EmpleadoConfiguration());
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            //modelBuilder.Configurations.Add(new PersonaConfiguration());
            modelBuilder.Configurations.Add(new MarcaConfiguration());    
            modelBuilder.Configurations.Add(new ProductoConfiguration());
            modelBuilder.Configurations.Add(new ProveedorConfiguration());
            modelBuilder.Configurations.Add(new SucursalConfiguration());
            modelBuilder.Configurations.Add(new TiendaConfiguration());
            //modelBuilder.Configurations.Add(new TipoProductoConfiguration());
            //modelBuilder.Configurations.Add(new TipoVentaConfiguration());
            modelBuilder.Configurations.Add(new CompraConfiguration());
            

            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<LiqourStore.Entities.Venta> Ventas { get; set; }
    }
}
