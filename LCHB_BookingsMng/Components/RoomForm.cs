using LCHB_BookingsMng.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;


namespace LCHB_BookingsMng.Components
{
    public class RoomForm : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public RoomForm(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View("Index",_context.Rooms.ToList());
        }
    }
}
