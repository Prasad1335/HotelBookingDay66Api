using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingDay66Api.Models
{
    [Table("HotelRoom")]
    public partial class HotelRoom
    {
        public HotelRoom()
        {
            HotelBookings = new HashSet<HotelBooking>();
        }

        [Key]
        public int RoomId { get; set; }
        [Required]
        [StringLength(100)]
        [Unicode(false)]
        public string RoomType { get; set; }
        public int RoomRent { get; set; }

        [InverseProperty(nameof(HotelBooking.RoomRef))]
        public virtual ICollection<HotelBooking> HotelBookings { get; set; }
    }
}
