using HotelBookingDay66Api.Dto;
using Newtonsoft.Json;
using System.Diagnostics;
using Website.Models.Interfaces;

namespace Website.Models.Services
{
    public class HotelRoomService : IHotelRoom
    {
        private readonly HttpClient _httpClient;

        public HotelRoomService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<HotelRoomDto>> GetAllAsync()
        {
            Debug.Assert(_httpClient.BaseAddress != null);

            var uri = new Uri(_httpClient.BaseAddress, "/api/HotelRooms");

            //var responseText = await _httpClient.GetStringAsync(uri);
            //var responseDto = JsonConvert.DeserializeObject<List<HotelRoomDto>>(responseText);
            //or
            var responseDto = await _httpClient.GetFromJsonAsync<List<HotelRoomDto>>(uri);
            return responseDto;
        }

    }
}
