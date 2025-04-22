// Celular.cs
using System;

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

// Cargador.cs
public class Cargador
{
    public int Id { get; set; }
    public string Capacidad { get; set; }
    public decimal Longitud { get; set; }
    public string Marca { get; set; }
    public int Garantia { get; set; } // Meses de garantía
}