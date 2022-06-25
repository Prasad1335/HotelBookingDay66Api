using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingDay66Api.Models
{
    [Table("HotelBooking")]
    public partial class HotelBooking
    {
        public HotelBooking()
        {
            HotelReservations = new HashSet<HotelReservation>();
        }

        [Key]
        public int HotelId { get; set; }
        [Required]
        [StringLength(100)]
        [Unicode(false)]
        public string HotelName { get; set; }
        [Required]
        [StringLength(100)]
        [Unicode(false)]
        public string HotelLocation { get; set; }
        public int? RoomRefId { get; set; }
        public int HotelRating { get; set; }

        [ForeignKey(nameof(RoomRefId))]
        [InverseProperty(nameof(HotelRoom.HotelBookings))]
        public virtual HotelRoom RoomRef { get; set; }
        [InverseProperty(nameof(HotelReservation.HotelRef))]
        public virtual ICollection<HotelReservation> HotelReservations { get; set; }
    }
}
