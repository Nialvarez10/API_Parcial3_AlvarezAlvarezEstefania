using API_Parcial3_AlvarezAlvarezEstefania.DAL.Entities;
using API_Parcial3_AlvarezAlvarezEstefania.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Parcial3_AlvarezAlvarezEstefania.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;
       

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
            
        }

        [HttpGet]
        [Route("GetAllHotelsWithAvailableRooms")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotelsWithAvailableRoomsAsync()
        {
            var hotels = await _hotelService.GetHotelsWithAvailableRoomsAsync();

            if (hotels == null || !hotels.Any()) return NotFound();

            return Ok(hotels);
        }

        [HttpGet]
        [Route("GetHotelByIdWithAvailableRooms/{hotelId}")]
        public async Task<ActionResult<Hotel>> GetHotelByIdWithAvailableRoomsAsync(Guid hotelId)
        {
            if (hotelId == Guid.Empty) return BadRequest("HotelId is required!");

            var hotel = await _hotelService.GetHotelByIdWithAvailableRoomsAsync(hotelId);

            if (hotel == null) return NotFound(); // 404

            return Ok(hotel); // 200
        }

        [HttpGet]
        [Route("GetHotelsByCityWithAvailableRooms/{city}")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotelsByCityWithAvailableRoomsAsync(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                return BadRequest("City name is required!");
            }

            var hotels = await _hotelService.GetHotelsByCityWithAvailableRoomsAsync(city);

            if (hotels == null || !hotels.Any())
            {
                return NotFound(); 
            }

            return Ok(hotels);
        }

        [HttpPut]
        [Route("EditHotelReputation/{hotelId}/{newStars}")]
        public async Task<IActionResult> EditHotelReputationAsync(Guid hotelId, int newStars)
        {
            try
            {
                await _hotelService.EditHotelReputationAsync(hotelId, newStars);
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict("Error editing hotel reputation.");

                return Conflict(ex.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteHotel/{hotelId}")]
        public async Task<ActionResult<Hotel>> DeleteHotelAsync(Guid hotelId)
        {
            if (hotelId == Guid.Empty) return BadRequest("HotelId is required!");

            var deletedHotel = await _hotelService.DeleteHotelAsync(hotelId);

            if (deletedHotel == null) return NotFound("Hotel not found!");

            return Ok(deletedHotel);
        }



    }


}

