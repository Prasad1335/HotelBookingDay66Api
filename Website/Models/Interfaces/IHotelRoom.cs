using HotelBookingDay66Api.Dto;

namespace Website.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<List<HotelRoomDto>> GetAllAsync();
    }
}
