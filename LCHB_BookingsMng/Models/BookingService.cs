using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCHB_BookingsMng.Models
{
    public class BookingService
    {
        [Key]
        public int BookingServiceId { get; set; }
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        [ForeignKey("RoomService")]
        public int RoomServiceId { get; set; }
        [Required]
        public DateTime BookingSVDate { get; set; }
        [MaxLength(500)]
        public string? Request { get; set; }

        public Room? RoomNav { get; set; }
        public RoomService? RoomServiceNav { get; set; }

    }
}
