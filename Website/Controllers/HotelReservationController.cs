using Microsoft.AspNetCore.Mvc;
using Website.Models.Interfaces;

namespace Website.Controllers
{
    public class HotelReservationController : Controller
    {

        private readonly IHotelReservation _hotelReservation;

        public HotelReservationController(IHotelReservation hotelReservation)
        {
            _hotelReservation = hotelReservation;
        }
        public async Task<IActionResult> Index()
        {
            var hotelReservations = await _hotelReservation.GetAllAsync();
            return View(hotelReservations);
        }
    }
}

