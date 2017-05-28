using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiqourStore.Entities
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string NombreCliente { get; set; }
        public string DescripcionProducto { get; set; }
        public int StockProducto { get; set; }

        //Relaciones
        public Collection<Venta> Ventas { get; set; }
        public Collection<Tienda> Tiendas { get; set; }
        public Collection<Proveedor> Proveedores { get; set; }
        public Collection<Marca> Marcas { get; set; }
        public TipoProducto TipoProducto { get; set; }


        public Producto()
        {
            TipoProducto = TipoProducto;
            Ventas = new Collection<Venta>();
            Tiendas = new Collection<Tienda>();
            Marcas = new Collection<Marca>();
            Proveedores = new Collection<Proveedor>();


        }

    }

    }
