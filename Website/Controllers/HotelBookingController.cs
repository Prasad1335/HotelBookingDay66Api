using Microsoft.AspNetCore.Mvc;
using Website.Models.Interfaces;

namespace Website.Controllers
{
    public class HotelBookingController : Controller
    {
        private readonly IHotelBooking _hotelBooking;

        public HotelBookingController(IHotelBooking hotelBooking)
        {
            _hotelBooking = hotelBooking;
        }
        public async Task<IActionResult> Index()
        {
            var hotelbooking =await _hotelBooking.GetAllAsync();
            return View(hotelbooking);
        }
    }
}
