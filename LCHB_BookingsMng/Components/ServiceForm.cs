using LCHB_BookingsMng.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace LCHB_BookingsMng.Components
{
    public class ServiceForm : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public ServiceForm(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View("Index");
        }
    }
}
