using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiqourStore.Entities
{
    public class Sucursal
    {
        public int  SucursalId { get; set; }
        public string DireccionSucursal { get; set; }

        public int TiendaId { get; set; }

        public Tienda Tienda { get; set; }

    }
}
