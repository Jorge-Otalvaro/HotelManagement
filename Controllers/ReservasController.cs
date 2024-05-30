using Microsoft.AspNetCore.Mvc;
using HotelManagement.Models;
using HotelManagement.Services;

namespace HotelManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController(IReservaService reservaService) : ControllerBase
    {
        private readonly IReservaService _reservaService = reservaService;

        [HttpGet]
        public async Task<IActionResult> GetAllReservas()
        {
            var reservas = await _reservaService.GetAllReservasAsync();
            return Ok(reservas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservaById(int id)
        {
            var reserva = await _reservaService.GetReservaByIdAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            return Ok(reserva);
        }

        [HttpPost]
        public async Task<IActionResult> AddReserva([FromBody] Reserva reserva)
        {
            await _reservaService.AddReservaAsync(reserva);            
            return CreatedAtAction(nameof(GetReservaById), new { id = reserva.Id }, reserva);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReserva(int id, [FromBody] Reserva reserva)
        {
            if (id != reserva.Id)
            {
                return BadRequest();
            }

            await _reservaService.UpdateReservaAsync(reserva);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReserva(int id)
        {
            await _reservaService.DeleteReservaAsync(id);
            return NoContent();
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarHoteles([FromQuery] DateTime fechaEntrada, [FromQuery] DateTime fechaSalida, [FromQuery] int cantidadPersonas, [FromQuery] string ciudad)
        {
            var hoteles = await _reservaService.BuscarHotelesAsync(fechaEntrada, fechaSalida, cantidadPersonas, ciudad);
            return Ok(hoteles);
        }
    }
}
