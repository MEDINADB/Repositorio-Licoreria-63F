using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiqourStore.Entities
{
    public class Compra
    {
        public int CompraId { get; set; }
        public string DescripcionCompra  { get; set; }

        public List<Proveedor> Proveedores { get; set; }

        public Compra()
        {
            Proveedores = new List<Proveedor>();
        }


    }
}
