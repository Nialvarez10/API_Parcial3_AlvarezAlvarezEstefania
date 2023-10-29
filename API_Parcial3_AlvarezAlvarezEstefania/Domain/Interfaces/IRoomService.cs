using API_Parcial3_AlvarezAlvarezEstefania.DAL.Entities;

namespace API_Parcial3_AlvarezAlvarezEstefania.Domain.Interfaces
{
    public interface IRoomService
    {
        Task<Room> GetRoomByNumberWithAvailabilityAsync(Guid hotelId, string roomNumber);
        Task<Hotel> GetHotel(Guid hotelId);
    }
}

