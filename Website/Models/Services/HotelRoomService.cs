using HotelBookingDay66Api.Dto;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Text;
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

        public async Task AddAsync(HotelRoomDto hotelRoomDto)
        {
            var uri = new Uri($"https://localhost:7167/api/HotelRooms");

            var hotelRoomDtoJsonText = JsonConvert.SerializeObject(hotelRoomDto);
            var content = new StringContent(hotelRoomDtoJsonText, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, content);

            //  if (response.StatusCode != HttpStatusCode.Created)
            //  throw new LocationApiFailedException(response.StatusCode);
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
        public async Task<HotelRoomDto> GetByIdAsync(int id)
        {
            var uri = new Uri($"https://localhost:7167/api/HotelRooms/{id}");

            /*
            var locationText = await _httpClient.GetStringAsync(uri);
            var locationDto = JsonConvert.DeserializeObject<LocationDto>(locationText);
            */

            var locationDto = await _httpClient.GetFromJsonAsync<HotelRoomDto>(uri);

            return locationDto;
        }




        //public async Task DeleteAsync(int id)
        //{
        //    var uri = new Uri($"https://localhost:7167/api/HotelRooms/{id}");

        //    var response = await _httpClient.DeleteAsync(uri);

        //    // if (response.StatusCode != HttpStatusCode.NoContent)
        //    //  throw new LocationApiFailedException(response.StatusCode);
        //}
        public async Task DeleteAsync(int id)
        {
            var uri = new Uri($"https://localhost:7167/api/HotelRooms/{id}");

            var response = await _httpClient.DeleteAsync(uri);

            if (response.StatusCode != HttpStatusCode.NoContent)
                throw new LocationApiFailedException(response.StatusCode);
        }
    }

    class LocationApiFailedException : Exception
    {
        public HttpStatusCode ResponseStatusCode { get; }

        public LocationApiFailedException(HttpStatusCode responseStatusCode)
        {
            ResponseStatusCode = responseStatusCode;
        }
    }
}




