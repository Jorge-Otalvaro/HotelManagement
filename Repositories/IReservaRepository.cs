using HotelManagement.Models;

namespace HotelManagement.Repositories
{
    public interface IReservaRepository
    {
        Task<Reserva> GetReservaByIdAsync(int id);
        Task<IEnumerable<Reserva>> GetAllReservasAsync();
        Task AddReservaAsync(Reserva reserva);
        Task UpdateReservaAsync(Reserva reserva);
        Task DeleteReservaAsync(int id);
    }
}
