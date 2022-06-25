using Microsoft.AspNetCore.Mvc;
using Website.Models.Interfaces;

namespace Website.Controllers
{
    public class HotelRoomController : Controller
    {
        private readonly IHotelRoom _hotelRoom;

        public HotelRoomController(IHotelRoom hotelRoom)
        {
            _hotelRoom = hotelRoom;
        }
        public async Task<IActionResult> Index()
        {
            var room = await _hotelRoom.GetAllAsync();
            return View(room);
        }
    }
}
