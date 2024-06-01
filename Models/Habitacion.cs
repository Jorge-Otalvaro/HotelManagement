namespace HotelManagement.Models
{
    public class Habitacion
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public required Hotel Hotel { get; set; }
        public required string NumeroHabitacion { get; set; }
        public required string TipoHabitacion { get; set; }
        public int Capacidad { get; set; }
        public decimal CostoBase { get; set; }
        public decimal Impuestos { get; set; }
        public required string Ubicacion { get; set; }
        public bool Habilitado { get; set; }
    }
}
