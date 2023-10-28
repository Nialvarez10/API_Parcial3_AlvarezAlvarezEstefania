using API_Parcial3_AlvarezAlvarezEstefania.DAL.Entities;
using System.Diagnostics.Metrics;

namespace API_Parcial3_AlvarezAlvarezEstefania.Domain.Interfaces
{
    public interface IHotelService
    {

            Task<IEnumerable<Hotel>> GetHotelsWithAvailableRoomsAsync();
            Task<Hotel> GetHotelByIdWithAvailableRoomsAsync(Guid hotelId);
            Task<IEnumerable<Hotel>> GetHotelsByCityWithAvailableRoomsAsync(string city);
            Task EditHotelReputationAsync(Guid hotelId, int newStars);
            Task<Hotel> DeleteHotelAsync(Guid hotelId);
        

    }
}

