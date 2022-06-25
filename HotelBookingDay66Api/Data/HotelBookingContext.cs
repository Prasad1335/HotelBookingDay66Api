using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HotelBookingDay66Api.Models;

namespace HotelBookingDay66Api.Data
{
    public partial class HotelBookingContext : DbContext
    {
        public virtual DbSet<HotelBooking> HotelBookings { get; set; }
        public virtual DbSet<HotelReservation> HotelReservations { get; set; }
        public virtual DbSet<HotelRoom> HotelRooms { get; set; }

        public HotelBookingContext()
        {

        }
        public HotelBookingContext(DbContextOptions<HotelBookingContext> options) : base(options)
        {
        }


    }
}
