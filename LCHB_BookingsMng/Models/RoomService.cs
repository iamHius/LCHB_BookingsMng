using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LCHB_BookingsMng.Models
{
    public class RoomService
    {
        [Key]
        public int RoomServiceId { get; set; }
        [Required]
        [StringLength(200)]
        public string? RoomServiceName { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal RoomServicePrice { get; set; }
        
    }
}
