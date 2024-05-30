using HotelManagement.Models;

namespace HotelManagement.Services
{
    public interface IHotelService
    {
        Task<Hotel> GetHotelByIdAsync(int id);
        Task<IEnumerable<Hotel>> GetAllHotelesAsync();
        Task AddHotelAsync(Hotel hotel);
        Task UpdateHotelAsync(Hotel hotel);
        Task DeleteHotelAsync(int id);
    }
}
