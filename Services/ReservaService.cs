using HotelManagement.Models;
using HotelManagement.Repositories;

namespace HotelManagement.Services
{
    public class ReservaService(IReservaRepository reservaRepository, IHotelRepository hotelRepository) : IReservaService
    {
        private readonly IReservaRepository _reservaRepository = reservaRepository;
        private readonly IHotelRepository _hotelRepository = hotelRepository;

        public async Task<Reserva> GetReservaByIdAsync(int id)
        {
            return await _reservaRepository.GetReservaByIdAsync(id);
        }

        public async Task<IEnumerable<Reserva>> GetAllReservasAsync()
        {
            return await _reservaRepository.GetAllReservasAsync();
        }

        public async Task AddReservaAsync(Reserva reserva)
        {
            await _reservaRepository.AddReservaAsync(reserva);
        }

        public async Task UpdateReservaAsync(Reserva reserva)
        {
            await _reservaRepository.UpdateReservaAsync(reserva);
        }

        public async Task DeleteReservaAsync(int id)
        {
            await _reservaRepository.DeleteReservaAsync(id);
        }

        public async Task<IEnumerable<Hotel>> BuscarHotelesAsync(DateTime fechaEntrada, DateTime fechaSalida, int cantidadPersonas, string ciudad)
        {
            var hoteles = await _hotelRepository.GetAllHotelesAsync();            
            return hoteles.Where(h => h.Direccion.Contains(ciudad)).ToList();
        }
    }
}
