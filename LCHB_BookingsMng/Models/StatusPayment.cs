using System.ComponentModel.DataAnnotations;

namespace LCHB_BookingsMng.Models
{
    public class StatusPayment
    {
        [Key]
        public int PaymentStatusId { get; set; }
        [Required]
        public string PaymentStatus { get; set; }

    }
}
