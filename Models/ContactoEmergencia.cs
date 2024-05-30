namespace HotelManagement.Models
{
    public class ContactoEmergencia
    {
        public int Id { get; set; }
        public string NombresCompletos { get; set; }
        public string TelefonoContacto { get; set; }
        public int ReservaId { get; set; }
        public Reserva Reserva { get; set; }
    }
}
