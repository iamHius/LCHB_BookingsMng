using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCHB_BookingsMng.Models
{
    public class Bill
    {
        [Key]
        public int BillId { get; set; }
        [ForeignKey("BookingRoom")]
        public int BookingRoomId { get; set; }
        [ForeignKey("BookingService")]
        public int? BookingServiceId { get; set; }
        [ForeignKey("Payment")]
        public int PayId { get; set; }
        public BookingRoom? BookingRoomNav { get; set; }
        public Payment? PaymentNav { get; set; }
        public BookingService? BookingServiceNav { get; set; }
        

    }
}
