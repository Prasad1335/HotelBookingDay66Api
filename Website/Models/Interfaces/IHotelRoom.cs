using HotelBookingDay66Api.Dto;

namespace Website.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<List<HotelRoomDto>> GetAllAsync();
        Task AddAsync(HotelRoomDto hotelRoomDto);
        Task<HotelRoomDto?> GetByIdAsync(int id);
        Task DeleteAsync(int id);

    }
}


