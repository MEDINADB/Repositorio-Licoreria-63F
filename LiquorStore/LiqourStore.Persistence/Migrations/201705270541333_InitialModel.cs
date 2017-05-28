namespace LiqourStore.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Dni = c.Int(nullable: false),
                        RuCCliente = c.Int(nullable: false),
                        Nombres = c.String(nullable: false, maxLength: 100),
                        ApePaterno = c.String(nullable: false, maxLength: 100),
                        ApeMaterno = c.String(nullable: false, maxLength: 100),
                        Direccion = c.String(nullable: false, maxLength: 150),
                        Telefono = c.Int(nullable: false),
                        Sexo = c.String(nullable: false, maxLength: 50),
                        Correo = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        VentaId = c.Int(nullable: false, identity: true),
                        Fecha = c.String(nullable: false, maxLength: 50),
                        TipoVenta = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        EmpleadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VentaId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Empleados", t => t.EmpleadoId, cascadeDelete: true)
                .Index(t => t.ClienteId)
                .Index(t => t.EmpleadoId);
            
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        EmpleadoId = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false, maxLength: 50),
                        ApePaterno = c.String(nullable: false, maxLength: 100),
                        ApeMaterno = c.String(nullable: false, maxLength: 100),
                        Telefono = c.Int(nullable: false),
                        Sexo = c.String(nullable: false, maxLength: 25),
                        FechaIngreso = c.Int(nullable: false),
                        Estado = c.String(nullable: false, maxLength: 200),
                        Direccion = c.String(nullable: false, maxLength: 255),
                        Correo = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.EmpleadoId);
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        ProductoId = c.Int(nullable: false, identity: true),
                        NombreCliente = c.String(nullable: false, maxLength: 50),
                        DescripcionProducto = c.String(nullable: false, maxLength: 100),
                        StockProducto = c.Int(nullable: false),
                        TipoProducto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductoId);
            
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        MarcaId = c.Int(nullable: false, identity: true),
                        NombreMarca = c.String(nullable: false, maxLength: 50),
                        LogoMarca = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.MarcaId);
            
            CreateTable(
                "dbo.Proveedores",
                c => new
                    {
                        ProveedorId = c.Int(nullable: false, identity: true),
                        DireccionProveedor = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ProveedorId);
            
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        CompraId = c.Int(nullable: false, identity: true),
                        DescripcionCompra = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.CompraId);
            
            CreateTable(
                "dbo.Tiendas",
                c => new
                    {
                        TiendaId = c.Int(nullable: false, identity: true),
                        DireccionTienda = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.TiendaId);
            
            CreateTable(
                "dbo.Sucursales",
                c => new
                    {
                        SucursalId = c.Int(nullable: false, identity: true),
                        DireccionSucursal = c.String(nullable: false, maxLength: 50),
                        TiendaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SucursalId)
                .ForeignKey("dbo.Tiendas", t => t.TiendaId, cascadeDelete: true)
                .Index(t => t.TiendaId);
            
            CreateTable(
                "dbo.ProductosMarcass",
                c => new
                    {
                        MarcasId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MarcasId, t.ProductoId })
                .ForeignKey("dbo.Productos", t => t.MarcasId, cascadeDelete: true)
                .ForeignKey("dbo.Marcas", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.MarcasId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.ProveedoresCompras",
                c => new
                    {
                        ProveedorId = c.Int(nullable: false),
                        CompraId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProveedorId, t.CompraId })
                .ForeignKey("dbo.Proveedores", t => t.ProveedorId, cascadeDelete: true)
                .ForeignKey("dbo.Compras", t => t.CompraId, cascadeDelete: true)
                .Index(t => t.ProveedorId)
                .Index(t => t.CompraId);
            
            CreateTable(
                "dbo.ProductosProveedores",
                c => new
                    {
                        ProveedorId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProveedorId, t.ProductoId })
                .ForeignKey("dbo.Productos", t => t.ProveedorId, cascadeDelete: true)
                .ForeignKey("dbo.Proveedores", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.ProveedorId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.ProductosTiendas",
                c => new
                    {
                        TiendaId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TiendaId, t.ProductoId })
                .ForeignKey("dbo.Productos", t => t.TiendaId, cascadeDelete: true)
                .ForeignKey("dbo.Tiendas", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.TiendaId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.ProductosVentas",
                c => new
                    {
                        VentaId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VentaId, t.ProductoId })
                .ForeignKey("dbo.Productos", t => t.VentaId, cascadeDelete: true)
                .ForeignKey("dbo.Ventas", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.VentaId)
                .Index(t => t.ProductoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductosVentas", "ProductoId", "dbo.Ventas");
            DropForeignKey("dbo.ProductosVentas", "VentaId", "dbo.Productos");
            DropForeignKey("dbo.ProductosTiendas", "ProductoId", "dbo.Tiendas");
            DropForeignKey("dbo.ProductosTiendas", "TiendaId", "dbo.Productos");
            DropForeignKey("dbo.Sucursales", "TiendaId", "dbo.Tiendas");
            DropForeignKey("dbo.ProductosProveedores", "ProductoId", "dbo.Proveedores");
            DropForeignKey("dbo.ProductosProveedores", "ProveedorId", "dbo.Productos");
            DropForeignKey("dbo.ProveedoresCompras", "CompraId", "dbo.Compras");
            DropForeignKey("dbo.ProveedoresCompras", "ProveedorId", "dbo.Proveedores");
            DropForeignKey("dbo.ProductosMarcass", "ProductoId", "dbo.Marcas");
            DropForeignKey("dbo.ProductosMarcass", "MarcasId", "dbo.Productos");
            DropForeignKey("dbo.Ventas", "EmpleadoId", "dbo.Empleados");
            DropForeignKey("dbo.Ventas", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.ProductosVentas", new[] { "ProductoId" });
            DropIndex("dbo.ProductosVentas", new[] { "VentaId" });
            DropIndex("dbo.ProductosTiendas", new[] { "ProductoId" });
            DropIndex("dbo.ProductosTiendas", new[] { "TiendaId" });
            DropIndex("dbo.ProductosProveedores", new[] { "ProductoId" });
            DropIndex("dbo.ProductosProveedores", new[] { "ProveedorId" });
            DropIndex("dbo.ProveedoresCompras", new[] { "CompraId" });
            DropIndex("dbo.ProveedoresCompras", new[] { "ProveedorId" });
            DropIndex("dbo.ProductosMarcass", new[] { "ProductoId" });
            DropIndex("dbo.ProductosMarcass", new[] { "MarcasId" });
            DropIndex("dbo.Sucursales", new[] { "TiendaId" });
            DropIndex("dbo.Ventas", new[] { "EmpleadoId" });
            DropIndex("dbo.Ventas", new[] { "ClienteId" });
            DropTable("dbo.ProductosVentas");
            DropTable("dbo.ProductosTiendas");
            DropTable("dbo.ProductosProveedores");
            DropTable("dbo.ProveedoresCompras");
            DropTable("dbo.ProductosMarcass");
            DropTable("dbo.Sucursales");
            DropTable("dbo.Tiendas");
            DropTable("dbo.Compras");
            DropTable("dbo.Proveedores");
            DropTable("dbo.Marcas");
            DropTable("dbo.Productos");
            DropTable("dbo.Empleados");
            DropTable("dbo.Ventas");
            DropTable("dbo.Cliente");
        }
    }
}
