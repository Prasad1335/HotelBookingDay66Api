using HotelBookingDay66Api.Dto;

namespace Website.Models.Interfaces
{
    public interface IHotelReservation
    {
        Task<List<HotelReservationDto>> GetAllAsync();
    }
}
