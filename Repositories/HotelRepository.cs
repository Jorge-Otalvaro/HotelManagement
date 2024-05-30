using HotelManagement.Models;
using HotelManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Repositories
{
    public class HotelRepository(AppDbContext context) : IHotelRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Hotel> GetHotelByIdAsync(int id)
        {
            return await _context.Hoteles.Include(h => h.Habitaciones).FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<IEnumerable<Hotel>> GetAllHotelesAsync()
        {
            return await _context.Hoteles.Include(h => h.Habitaciones).ToListAsync();
        }

        public async Task AddHotelAsync(Hotel hotel)
        {
            await _context.Hoteles.AddAsync(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateHotelAsync(Hotel hotel)
        {
            _context.Hoteles.Update(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHotelAsync(int id)
        {
            var hotel = await GetHotelByIdAsync(id);
            if (hotel != null)
            {
                _context.Hoteles.Remove(hotel);
                await _context.SaveChangesAsync();
            }
        }
    }
}
