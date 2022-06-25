using HotelBookingDay66Api.Dto;

namespace Website.Models.Interfaces
{
    public interface IHotelBooking
    {
        Task<List<HotelBookingDto>> GetAllAsync();
    }
}
