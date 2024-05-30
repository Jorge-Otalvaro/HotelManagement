using Microsoft.AspNetCore.Mvc;
using HotelManagement.Models;
using HotelManagement.Services;

namespace HotelManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelesController(IHotelService hotelService) : ControllerBase
    {
        private readonly IHotelService _hotelService = hotelService;

        [HttpGet]
        public async Task<IActionResult> GetAllHoteles()
        {
            var hoteles = await _hotelService.GetAllHotelesAsync();
            return Ok(hoteles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            var hotel = await _hotelService.GetHotelByIdAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }

        [HttpPost]
        public async Task<IActionResult> AddHotel([FromBody] Hotel hotel)
        {
            await _hotelService.AddHotelAsync(hotel);
            return CreatedAtAction(nameof(GetHotelById), new { id = hotel.Id }, hotel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, [FromBody] Hotel hotel)
        {
            if (id != hotel.Id)
            {
                return BadRequest();
            }

            await _hotelService.UpdateHotelAsync(hotel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            await _hotelService.DeleteHotelAsync(id);
            return NoContent();
        }
    }
}
