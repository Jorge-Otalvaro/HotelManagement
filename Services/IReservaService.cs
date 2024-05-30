using HotelManagement.Models;

namespace HotelManagement.Services
{
    public interface IReservaService
    {
        Task<Reserva> GetReservaByIdAsync(int id);
        Task<IEnumerable<Reserva>> GetAllReservasAsync();
        Task AddReservaAsync(Reserva reserva);
        Task UpdateReservaAsync(Reserva reserva);
        Task DeleteReservaAsync(int id);
        Task<IEnumerable<Hotel>> BuscarHotelesAsync(DateTime fechaEntrada, DateTime fechaSalida, int cantidadPersonas, string ciudad);
    }
}
