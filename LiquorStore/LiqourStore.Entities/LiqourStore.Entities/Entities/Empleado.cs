using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiqourStore.Entities
{
    public class Empleado 
    {
        public int EmpleadoId { get; set; }
        public string Nombres { get; set; }
        public string ApePaterno { get; set; }
        public string ApeMaterno { get; set; }
        public int Telefono { get; set; }
        public string Sexo { get; set; }
        public int FechaIngreso { get; set; }
        public string Estado { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        //Relaciones

       

        public List<Venta> Ventas { get; set; }

        public Empleado()
        {
            Ventas = new List<Venta>();
        }


    }
}
