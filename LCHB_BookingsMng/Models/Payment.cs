using System.ComponentModel.DataAnnotations;

namespace LCHB_BookingsMng.Models
{
    public class Payment
    {
        [Key]
        public int PayId { get; set; }
        public string? PaymentCode { get; set; }
        public int? PayStatus { get; set; }
    }
}
