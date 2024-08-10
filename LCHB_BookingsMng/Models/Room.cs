using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LCHB_BookingsMng.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        [Required]
        [StringLength(200)]
        public string? RoomName { get; set; }
        [ForeignKey("RoomType")]
        public int RoomTypeId { get; set; }
        [ForeignKey("RoomStatus")]
        public int RoomStatusId { get; set; }
        public RoomType? RoomTypeNav { get; set; }
        public RoomStatus? RoomStatusNav { get; set; }
    }
}
