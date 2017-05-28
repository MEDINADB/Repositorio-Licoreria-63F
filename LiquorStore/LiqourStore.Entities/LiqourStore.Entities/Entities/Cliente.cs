using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiqourStore.Entities
{
    public class Cliente 

    {
        public int ClienteId { get; set; }
        public int Dni      { get; set; }
        public int RucCliente { get; set; }
        public string Nombres { get; set; }
        public string ApePaterno { get; set; }
        public string ApeMaterno { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string Sexo { get; set; }
        public string Correo { get; set; }
        //Relaciones

        public List<Venta> Ventas { get; set; }

        public Cliente()
        {
           Ventas= new List<Venta>();
        }

    }

}
