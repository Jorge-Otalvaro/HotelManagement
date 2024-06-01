using HotelManagement.Models;

namespace HotelManagement.Services
{
    public interface IHabitacionService
    {
        Task<Habitacion> GetHabitacionByIdAsync(int id);
        Task<IEnumerable<Habitacion>> GetAllHabitacionesAsync();
        Task AddHabitacionAsync(Habitacion habitacion);
        Task UpdateHabitacionAsync(Habitacion habitacion);
        Task DeleteHabitacionAsync(int id);
        Task<IEnumerable<Habitacion>> BuscarHabitacionesDisponiblesAsync(DateTime fechaEntrada, DateTime fechaSalida, int cantidadPersonas, string ciudad);
    }
}
