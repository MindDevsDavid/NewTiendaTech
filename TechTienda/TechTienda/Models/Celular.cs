using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTienda.Models
{
    public class Celular
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Marca { get; set; }
        public int Almacenamiento { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public Cargador Cargador { get; set; }

        public Celular()
        {
            // Cargador por defecto
            Cargador = new Cargador
            {
                Capacidad = "Estándar",
                Longitud = 1.5m,
                Marca = "Genérico",
                Garantia = 12
            };
        }
    }
}
