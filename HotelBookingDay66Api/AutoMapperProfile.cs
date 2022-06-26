using AutoMapper;
using HotelBookingDay66Api.Dto;
using HotelBookingDay66Api.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<HotelBooking, HotelBookingDto>().ReverseMap();
        CreateMap<HotelReservation, HotelReservationDto>()
            .ForMember(evw => evw.HotelName, opt => opt.MapFrom(em => em.HotelRef.HotelName))
            .ReverseMap()
            .ForPath(em => em.HotelRef.HotelName, opt => opt.Ignore());

        CreateMap<HotelRoom, HotelRoomDto>().ReverseMap();

    }
}