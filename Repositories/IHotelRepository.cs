using HotelManagement.Models;

namespace HotelManagement.Repositories
{
    public interface IHotelRepository
    {
        Task<Hotel> GetHotelByIdAsync(int id);
        Task<IEnumerable<Hotel>> GetAllHotelesAsync();
        Task AddHotelAsync(Hotel hotel);
        Task UpdateHotelAsync(Hotel hotel);
        Task DeleteHotelAsync(int id);
    }
}
