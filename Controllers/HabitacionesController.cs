using Microsoft.AspNetCore.Mvc;
using HotelManagement.Models;
using HotelManagement.Services;

namespace HotelManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HabitacionesController : ControllerBase
    {
        private readonly IHabitacionService _habitacionService;

        public HabitacionesController(IHabitacionService habitacionService)
        {
            _habitacionService = habitacionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHabitaciones()
        {
            var habitaciones = await _habitacionService.GetAllHabitacionesAsync();
            return Ok(habitaciones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHabitacionById(int id)
        {
            var habitacion = await _habitacionService.GetHabitacionByIdAsync(id);
            if (habitacion == null)
            {
                return NotFound();
            }
            return Ok(habitacion);
        }

        [HttpPost]
        public async Task<IActionResult> AddHabitacion([FromBody] Habitacion habitacion)
        {
            await _habitacionService.AddHabitacionAsync(habitacion);
            return CreatedAtAction(nameof(GetHabitacionById), new { id = habitacion.Id }, habitacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHabitacion(int id, [FromBody] Habitacion habitacion)
        {
            if (id != habitacion.Id)
            {
                return BadRequest();
            }

            await _habitacionService.UpdateHabitacionAsync(habitacion);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabitacion(int id)
        {
            await _habitacionService.DeleteHabitacionAsync(id);
            return NoContent();
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarHabitacionesDisponibles([FromQuery] DateTime fechaEntrada, [FromQuery] DateTime fechaSalida, [FromQuery] int cantidadPersonas, [FromQuery] string ciudad)
        {
            var habitaciones = await _habitacionService.BuscarHabitacionesDisponiblesAsync(fechaEntrada, fechaSalida, cantidadPersonas, ciudad);
            return Ok(habitaciones);
        }

        [HttpPatch("{id}/habilitar")]
        public async Task<IActionResult> HabilitarHabitacion(int id)
        {
            var habitacion = await _habitacionService.GetHabitacionByIdAsync(id);
            if (habitacion == null)
            {
                return NotFound();
            }

            habitacion.Habilitado = true;
            await _habitacionService.UpdateHabitacionAsync(habitacion);
            return NoContent();
        }

        [HttpPatch("{id}/inhabilitar")]
        public async Task<IActionResult> InhabilitarHabitacion(int id)
        {
            var habitacion = await _habitacionService.GetHabitacionByIdAsync(id);
            if (habitacion == null)
            {
                return NotFound();
            }

            habitacion.Habilitado = false;
            await _habitacionService.UpdateHabitacionAsync(habitacion);
            return NoContent();
        }
    }
}
