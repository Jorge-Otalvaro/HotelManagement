using HotelManagement.Models;
using HotelManagement.Repositories;

namespace HotelManagement.Services
{
    public class HotelService(IHotelRepository hotelRepository) : IHotelService
    {
        private readonly IHotelRepository _hotelRepository = hotelRepository;

        public async Task<Hotel> GetHotelByIdAsync(int id)
        {
            return await _hotelRepository.GetHotelByIdAsync(id);
        }

        public async Task<IEnumerable<Hotel>> GetAllHotelesAsync()
        {
            return await _hotelRepository.GetAllHotelesAsync();
        }

        public async Task AddHotelAsync(Hotel hotel)
        {
            await _hotelRepository.AddHotelAsync(hotel);
        }

        public async Task UpdateHotelAsync(Hotel hotel)
        {
            await _hotelRepository.UpdateHotelAsync(hotel);
        }

        public async Task DeleteHotelAsync(int id)
        {
            await _hotelRepository.DeleteHotelAsync(id);
        }
    }
}
