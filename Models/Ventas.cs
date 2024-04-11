namespace ParcialUnoP_IV.Models
{
    public class Ventas
    {
        public int id { get; set; }

        public int? total { get; set; }

        public DateTime FechaCreacion { get; set; } // Propiedad para almacenar la fecha de creación

        public Ventas()
        {
            FechaCreacion = DateTime.Now;
        }
    }
}
