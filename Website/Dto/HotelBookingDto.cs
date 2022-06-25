namespace HotelBookingDay66Api.Dto
{
    public class HotelBookingDto
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string HotelLocation { get; set; }
        public int? RoomRefId { get; set; }
        public int HotelRating { get; set; }

        //[ForeignKey(nameof(RoomRefId))]
        //[InverseProperty(nameof(HotelRoom.HotelBookings))]
        //public virtual HotelRoom RoomRef { get; set; }
        //[InverseProperty(nameof(HotelReservation.HotelRef))]
        //public virtual ICollection<HotelReservation> HotelReservations { get; set; }
    }
}
