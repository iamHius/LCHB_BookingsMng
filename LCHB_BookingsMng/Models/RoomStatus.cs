using System.ComponentModel.DataAnnotations;

namespace LCHB_BookingsMng.Models
{
    public class RoomStatus
    {
        [Key]
        public int RoomStatusId { get; set; }
        [Required]
        [StringLength(200)]
        public string? RoomStatusName { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
    }
}
