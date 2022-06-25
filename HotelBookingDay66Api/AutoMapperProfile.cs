using AutoMapper;
using HotelBookingDay66Api.Dto;
using HotelBookingDay66Api.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<HotelBooking, HotelBookingDto>().ReverseMap();
        CreateMap<HotelReservation, HotelReservationDto>().ReverseMap();
        CreateMap<HotelRoom, HotelRoomDto>().ReverseMap();

    }
}