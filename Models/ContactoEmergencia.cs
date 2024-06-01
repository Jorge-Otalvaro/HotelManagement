namespace HotelManagement.Models
{
    public class ContactoEmergencia
    {
        public int Id { get; set; }
        public required string NombresCompletos { get; set; }
        public required string TelefonoContacto { get; set; }
        public int ReservaId { get; set; }
        public required Reserva Reserva { get; set; }
    }
}
