using HotelBookingDay66Api.Dto;
using System.Diagnostics;
using Website.Models.Interfaces;

namespace Website.Models.Services
{
    public class HotelReservationService : IHotelReservation
    {
        private readonly HttpClient _httpClient;

        public HotelReservationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<HotelReservationDto>> GetAllAsync()
        {
            Debug.Assert(_httpClient.BaseAddress != null);

            var uri = new Uri(_httpClient.BaseAddress, "/api/HotelReservations");

            //var responseText = await _httpClient.GetStringAsync(uri);
            //var responseDto = JsonConvert.DeserializeObject<List<HotelRoomDto>>(responseText);
            //or
            var responseDto = await _httpClient.GetFromJsonAsync<List<HotelReservationDto>>(uri);
            return responseDto;
        }
    }
}
