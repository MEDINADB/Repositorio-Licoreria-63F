using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiqourStore.Entities
{
    public class Proveedor
    {
        public int ProveedorId { get; set; }
        public int NumeroTelefono { get; set; }
        public string DireccionProveedor { get; set; }


        public List<Compra> Compras { get; set; }
        public List<Producto> Productos { get; set; }


        public Proveedor()
        {
            Compras = new List<Compra>();
            Productos = new List<Producto>();

        }
    }
}

