using HotelBookingDay66Api.Dto;
using Microsoft.AspNetCore.Mvc;
using Website.Models.Interfaces;

namespace Website.Controllers
{
    public class HotelRoomController : Controller
    {
        private readonly IHotelRoom _hotelRoom;

        private readonly ILogger<HotelRoomController> _logger;


        public HotelRoomController(IHotelRoom hotelRoom, ILogger<HotelRoomController> logger)
        {
            _hotelRoom = hotelRoom;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var room = await _hotelRoom.GetAllAsync();
            return View(room);
        }

        [HttpGet]
        public async Task<IActionResult> AddAsync()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(HotelRoomDto hotelRoomDto)
        {

            await _hotelRoom.AddAsync(hotelRoomDto);
            ViewData["SuccessMessage"] = "Hotel Room Added Successfully";

            return View();
        }


        public async Task<IActionResult> Search(int? id)
        {
            HotelRoomDto hotelRoomDto = null;

            if (id != null)
            {
                try
                {
                    hotelRoomDto = await _hotelRoom.GetByIdAsync((int)id);
                }
                catch (Exception e)
                {
                    ViewData["ErrorMessage"] = $"Hotel Room Id {id} not found";
                    _logger.LogError(e, "Error Getting Hotel Room By Id");
                }
            }

            return View(hotelRoomDto);
        }



        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int? id)
        {
            if (id == null)
            {
                ViewData["ErrorMessage"] = $"Hotel Room Id {id} missing in parameter";
                return View();
            }

            try
            {
                var hotelRoomDto = await _hotelRoom.GetByIdAsync((int)id);
                return View(hotelRoomDto);
            }
            catch (Exception e)
            {
                ViewData["ErrorMessage"] = $"Hotel Room Id {id} not found";
                _logger.LogError(e, "Error Getting Location By Id");

                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteHotelRoomAsync(int? id)
        {
            if (id == null)
            {
                ViewData["ErrorMessage"] = $"Hotel Room Id {id} missing in parameter";
                return View("Delete");
            }

            try
            {
                await _hotelRoom.DeleteAsync((int)id);
                ViewData["SuccessMessage"] = "Hotel Room Deleted Successfully";
                return View("Delete");
            }
            catch (Exception e)
            {
                ViewData["ErrorMessage"] = $"Hotel Room Id {id} not found";
                _logger.LogError(e, "Error Getting Hotel Room By Id");

                return View("Delete");
            }
        }
    }

}

