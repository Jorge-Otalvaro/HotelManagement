namespace HotelManagement.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Direccion { get; set; }
        public bool Habilitado { get; set; }
        public required List<Habitacion> Habitaciones { get; set; }
    }
}
