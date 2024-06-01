using HotelManagement.Models;
using HotelManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Repositories
{
    public class HabitacionRepository(AppDbContext context) : IHabitacionRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Habitacion> GetHabitacionByIdAsync(int id)
        {
            return await _context.Habitaciones.FindAsync(id);
        }

        public async Task<IEnumerable<Habitacion>> GetAllHabitacionesAsync()
        {
            return await _context.Habitaciones.ToListAsync();
        }

        public async Task AddHabitacionAsync(Habitacion habitacion)
        {
            await _context.Habitaciones.AddAsync(habitacion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateHabitacionAsync(Habitacion habitacion)
        {
            _context.Habitaciones.Update(habitacion);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHabitacionAsync(int id)
        {
            var habitacion = await GetHabitacionByIdAsync(id);
            if (habitacion != null)
            {
                _context.Habitaciones.Remove(habitacion);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Habitacion>> BuscarHabitacionesDisponiblesAsync(DateTime fechaEntrada, DateTime fechaSalida, int cantidadPersonas, string ciudad)
        {
            var habitaciones = await _context.Habitaciones
                .Include(h => h.Hotel)
                .Where(h => h.Hotel.Direccion.Contains(ciudad)
                            && h.Capacidad >= cantidadPersonas
                            && h.Habilitado)
                .ToListAsync();

            var habitacionesReservadas = await _context.Reservas
                .Where(r => r.FechaEntrada < fechaSalida && r.FechaSalida > fechaEntrada)
                .Select(r => r.HabitacionId)
                .ToListAsync();

            return habitaciones.Where(h => !habitacionesReservadas.Contains(h.Id)).ToList();
        }
    }
}
