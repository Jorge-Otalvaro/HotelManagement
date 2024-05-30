namespace HotelManagement.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public int HabitacionId { get; set; }
        public Habitacion Habitacion { get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public string NombreCliente { get; set; }
        public string DetallesReserva { get; set; }
        public List<Pasajero> Pasajeros { get; set; }
        public ContactoEmergencia ContactoEmergencia { get; set; }
    }
}
