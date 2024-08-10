using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LCHB_BookingsMng.Models
{
    public class BookingRoom
    {
        [Key]
        public int BookingId { get; set; }
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        [ForeignKey("RoomService")]
        public int RoomServiceId { get; set; }
        public int? RoomBookingServiceId { get; set; }
        public DateTime BookingFromDate { get; set; }
        public DateTime BookingToDate { get; set; }
        public int? BookingDuration { get; set; }
        [Required]
        [EmailAddress]
        public string? BookingEmail { get; set; }
        public Room? RoomNav { get; set; }
        public RoomService? RoomServiceNav { get; set; }
        public BookingService? BookingServiceNav { get; set; }
    }
}
