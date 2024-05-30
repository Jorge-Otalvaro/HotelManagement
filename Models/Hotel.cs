namespace HotelManagement.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public bool Habilitado { get; set; }
        public List<Habitacion> Habitaciones { get; set; }
    }
}
