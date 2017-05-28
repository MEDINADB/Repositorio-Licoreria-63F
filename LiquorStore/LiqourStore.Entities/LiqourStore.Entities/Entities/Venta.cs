using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiqourStore.Entities
{
    public class Venta
    {
        public int VentaId { get; set; }
        public string Fecha { get; set; }

        public List<Producto> Productos { get; set; }
        
        public Venta()
        {
            Productos = new List<Producto>();
          

        }

        public TipoVenta TipoVenta   { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }






    }
}
