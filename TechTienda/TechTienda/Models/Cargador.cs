using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTienda.Models
{
    public class Cargador
    {
        public int Id { get; set; }
        public string Capacidad { get; set; }
        public decimal Longitud { get; set; }
        public string Marca { get; set; }
        public int Garantia { get; set; } // Meses de garantía
    }
}
