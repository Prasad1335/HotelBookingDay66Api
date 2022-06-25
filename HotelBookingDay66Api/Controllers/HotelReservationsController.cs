using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBookingDay66Api.Data;
using HotelBookingDay66Api.Models;

namespace HotelBookingDay66Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelReservationsController : ControllerBase
    {
        private readonly HotelBookingContext _context;

        public HotelReservationsController(HotelBookingContext context)
        {
            _context = context;
        }

        // GET: api/HotelReservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelReservation>>> GetHotelReservations()
        {
          if (_context.HotelReservations == null)
          {
              return NotFound();
          }
            return await _context.HotelReservations.ToListAsync();
        }

        // GET: api/HotelReservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelReservation>> GetHotelReservation(int id)
        {
          if (_context.HotelReservations == null)
          {
              return NotFound();
          }
            var hotelReservation = await _context.HotelReservations.FindAsync(id);

            if (hotelReservation == null)
            {
                return NotFound();
            }

            return hotelReservation;
        }

        // PUT: api/HotelReservations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelReservation(int id, HotelReservation hotelReservation)
        {
            if (id != hotelReservation.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(hotelReservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelReservationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HotelReservations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelReservation>> PostHotelReservation(HotelReservation hotelReservation)
        {
          if (_context.HotelReservations == null)
          {
              return Problem("Entity set 'HotelBookingContext.HotelReservations'  is null.");
          }
            _context.HotelReservations.Add(hotelReservation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelReservation", new { id = hotelReservation.BookingId }, hotelReservation);
        }

        // DELETE: api/HotelReservations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelReservation(int id)
        {
            if (_context.HotelReservations == null)
            {
                return NotFound();
            }
            var hotelReservation = await _context.HotelReservations.FindAsync(id);
            if (hotelReservation == null)
            {
                return NotFound();
            }

            _context.HotelReservations.Remove(hotelReservation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelReservationExists(int id)
        {
            return (_context.HotelReservations?.Any(e => e.BookingId == id)).GetValueOrDefault();
        }
    }
}
