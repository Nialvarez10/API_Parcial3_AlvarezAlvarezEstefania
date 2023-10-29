using API_Parcial3_AlvarezAlvarezEstefania.DAL.Entities;
using API_Parcial3_AlvarezAlvarezEstefania.DAL;
using API_Parcial3_AlvarezAlvarezEstefania.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Parcial3_AlvarezAlvarezEstefania.Domain.Services
{
    public class HotelService : IHotelService
    {
        private readonly DataBaseContext _context;

        public HotelService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hotel>> GetHotelsWithAvailableRoomsAsync()
        {
            var hotelsWithAvailableRooms = await _context.Hotels
                .Include(h => h.Rooms)
                .Where(h => h.Rooms.Any(r => r.Availability))
                .ToListAsync();

            return hotelsWithAvailableRooms;
        }

        public async Task<Hotel> GetHotelByIdWithAvailableRoomsAsync(Guid hotelId)
        {
            var hotel = await _context.Hotels
                .Where(h => h.Id == hotelId)
                .Select(h => new Hotel
                {
                    Id = h.Id,
                    Name = h.Name,

                    Rooms = h.Rooms.Where(r => r.Availability).ToList()
                })
                .FirstOrDefaultAsync();

            return hotel;
        }

        public async Task<IEnumerable<Hotel>> GetHotelsByCityWithAvailableRoomsAsync(string city)
        {
            var hotelsInCityWithAvailableRooms = await _context.Hotels
            .Where(h => h.City == city)
                .Select(h => new Hotel
                {
                    Id = h.Id,
                    Name = h.Name,
                    Address = h.Address,
                    Phone= h.Phone,
                    Stars= h.Stars,
                    City= h.City,

                    Rooms = h.Rooms.Where(r => r.Availability).ToList()
                })
                .ToListAsync();

            return hotelsInCityWithAvailableRooms;
        }

        public async Task EditHotelReputationAsync(Guid hotelId, int newStars)
        {
            var hotel = await _context.Hotels.FindAsync(hotelId);
            if (hotel != null)
            {
                hotel.Stars = newStars;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Hotel> DeleteHotelAsync(Guid hotelId)
        {
            var hotel = await _context.Hotels
                .Include(h => h.Rooms)
                .FirstOrDefaultAsync(h => h.Id == hotelId);

            if (hotel != null)
            {
                _context.Hotels.Remove(hotel);
                await _context.SaveChangesAsync();
            }

            return hotel;
        }
    }
}
