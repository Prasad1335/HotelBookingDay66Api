namespace HotelBookingDay66Api.Dto
{
    public class HotelReservationDto
    {
        public int BookingId { get; set; }
      
        public string CustomerName { get; set; }
        
        public string CustomerMobile { get; set; }
      
        public string CustomerEmail { get; set; }
       
        public string CustomerAddress { get; set; }
        public int? HotelRefId { get; set; }
       
        public DateTime FromBookRoom { get; set; }
       
        public DateTime ToBookRoom { get; set; }

        
    }
}
