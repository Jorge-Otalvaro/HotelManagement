using HotelManagement.Models;
using HotelManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Repositories
{
    public class ReservaRepository(AppDbContext context) : IReservaRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Reserva> GetReservaByIdAsync(int id)
        {
            return await _context.Reservas
                .Include(r => r.Pasajeros)
                .Include(r => r.ContactoEmergencia)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Reserva>> GetAllReservasAsync()
        {
            return await _context.Reservas
                .Include(r => r.Pasajeros)
                .Include(r => r.ContactoEmergencia)
                .ToListAsync();
        }

        public async Task AddReservaAsync(Reserva reserva)
        {
            await _context.Reservas.AddAsync(reserva);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReservaAsync(Reserva reserva)
        {
            _context.Reservas.Update(reserva);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReservaAsync(int id)
        {
            var reserva = await GetReservaByIdAsync(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
                await _context.SaveChangesAsync();
            }
        }
    }
}
