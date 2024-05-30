namespace HotelManagement.Models
{
    public class Habitacion
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public decimal CostoBase { get; set; }
        public decimal Impuestos { get; set; }
        public string Ubicacion { get; set; }
        public bool Habilitado { get; set; }
    }
}
