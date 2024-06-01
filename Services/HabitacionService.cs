using HotelManagement.Models;
using HotelManagement.Repositories;

namespace HotelManagement.Services
{
    public class HabitacionService(IHabitacionRepository habitacionRepository) : IHabitacionService
    {
        private readonly IHabitacionRepository _habitacionRepository = habitacionRepository;

        public async Task<Habitacion> GetHabitacionByIdAsync(int id)
        {
            return await _habitacionRepository.GetHabitacionByIdAsync(id);
        }

        public async Task<IEnumerable<Habitacion>> GetAllHabitacionesAsync()
        {
            return await _habitacionRepository.GetAllHabitacionesAsync();
        }

        public async Task AddHabitacionAsync(Habitacion habitacion)
        {
            await _habitacionRepository.AddHabitacionAsync(habitacion);
        }

        public async Task UpdateHabitacionAsync(Habitacion habitacion)
        {
            await _habitacionRepository.UpdateHabitacionAsync(habitacion);
        }

        public async Task DeleteHabitacionAsync(int id)
        {
            await _habitacionRepository.DeleteHabitacionAsync(id);
        }

        public async Task<IEnumerable<Habitacion>> BuscarHabitacionesDisponiblesAsync(DateTime fechaEntrada, DateTime fechaSalida, int cantidadPersonas, string ciudad)
        {
            return await _habitacionRepository.BuscarHabitacionesDisponiblesAsync(fechaEntrada, fechaSalida, cantidadPersonas, ciudad);
        }
    }
}
