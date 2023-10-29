using Microsoft.AspNetCore.Mvc;
using API_Parcial3_AlvarezAlvarezEstefania.DAL.Entities;
using API_Parcial3_AlvarezAlvarezEstefania.Domain.Interfaces;
using API_Parcial3_AlvarezAlvarezEstefania.Domain.Services;
using Microsoft.EntityFrameworkCore;
using API_Parcial3_AlvarezAlvarezEstefania.DAL;

namespace API_Parcial3_AlvarezAlvarezEstefania.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        [Route("CheckRoomAvailability/{hotelId}/{roomNumber}")]
        public async Task<ActionResult> CheckRoomAvailability(Guid hotelId, string roomNumber)
        {
            var room = await _roomService.GetRoomByNumberWithAvailabilityAsync(hotelId, roomNumber);
            var hotel = await _roomService.GetHotel(hotelId);
            if (room == null)
            {
                // Room is not available, displays an error message.
                return BadRequest($"Room {roomNumber} of the hotel {hotel.Name} already booked");
            }

            // The room is available, return the entire room item.
            return Ok(room);
        }
    }
}
