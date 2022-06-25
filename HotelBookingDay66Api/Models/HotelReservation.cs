using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingDay66Api.Models
{
    [Table("HotelReservation")]
    public partial class HotelReservation
    {
        [Key]
        public int BookingId { get; set; }
        [Required]
        [StringLength(100)]
        [Unicode(false)]
        public string CustomerName { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string CustomerMobile { get; set; }
        [Required]
        [StringLength(150)]
        [Unicode(false)]
        public string CustomerEmail { get; set; }
        [Required]
        [Unicode(false)]
        public string CustomerAddress { get; set; }
        public int? HotelRefId { get; set; }
        [Column(TypeName = "date")]
        public DateTime FromBookRoom { get; set; }
        [Column(TypeName = "date")]
        public DateTime ToBookRoom { get; set; }

        [ForeignKey(nameof(HotelRefId))]
        [InverseProperty(nameof(HotelBooking.HotelReservations))]
        public virtual HotelBooking HotelRef { get; set; }
    }
}
