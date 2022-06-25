using HotelBookingDay66Api.Dto;
using System.Diagnostics;
using Website.Models.Interfaces;

namespace Website.Models.Services
{
    public class HotelBookingService : IHotelBooking
    {
        private readonly HttpClient _httpClient;

        public HotelBookingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<HotelBookingDto>> GetAllAsync()
        {
            Debug.Assert(_httpClient.BaseAddress != null);

            var uri = new Uri(_httpClient.BaseAddress, "/api/HotelBookings");

            //var responseText = await _httpClient.GetStringAsync(uri);
            //var responseDto = JsonConvert.DeserializeObject<List<HotelRoomDto>>(responseText);
            //or
            var responseDto = await _httpClient.GetFromJsonAsync<List<HotelBookingDto>>(uri);
            return responseDto;
        }
    }
}

