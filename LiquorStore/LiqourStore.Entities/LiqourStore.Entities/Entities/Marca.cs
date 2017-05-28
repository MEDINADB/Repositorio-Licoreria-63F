using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiqourStore.Entities
{
    public class Marca
    {
        public int MarcaId { get; set; }
        public string NombreMarca { get; set; }
        public string  LogoMarca { get; set; }


        public List<Producto> Productos { get; set; }

        public Marca()
        {
            Productos = new List<Producto>();
        }
    }

}

