using API_Parcial3_AlvarezAlvarezEstefania.DAL.Entities;
using API_Parcial3_AlvarezAlvarezEstefania.DAL;
using API_Parcial3_AlvarezAlvarezEstefania.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Parcial3_AlvarezAlvarezEstefania.Domain.Services
{
    public class RoomService : IRoomService
    {
        private readonly DataBaseContext _context;

        public RoomService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<Room> GetRoomByNumberWithAvailabilityAsync(Guid hotelId, string roomNumber)
        {
            var room = await _context.Rooms
                .Where(r => r.HotelId == hotelId && r.Number == roomNumber && r.Availability)
                .FirstOrDefaultAsync();

            return room;
        }
    }
}
