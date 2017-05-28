using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiqourStore.Entities
{
    public class Tienda
    {
        public int TiendaId { get; set; }
        public string  DireccionTienda { get; set; }

        public List<Sucursal> Sucursales { get; set; }
        public List<Producto> Productos { get; set; }

        public Tienda()
        {
            Sucursales = new List<Sucursal>();
            Productos = new List<Producto>();

        }

    }
}
