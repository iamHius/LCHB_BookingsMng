using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LCHB_BookingsMng.Areas.Identity.Data;
using LCHB_BookingsMng.Models;

namespace LCHB_BookingsMng.Controllers
{
    public class BookingServicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookingServices
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BookingsService.Include(b => b.RoomNav).Include(b => b.RoomServiceNav);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BookingServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingService = await _context.BookingsService
                .Include(b => b.RoomNav)
                .Include(b => b.RoomServiceNav)
                .FirstOrDefaultAsync(m => m.BookingServiceId == id);
            if (bookingService == null)
            {
                return NotFound();
            }

            return View(bookingService);
        }

        // GET: BookingServices/Create
        public IActionResult Create()
        {
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomName");
            ViewData["RoomServiceId"] = new SelectList(_context.RoomServices, "RoomServiceId", "RoomServiceName");
            return View();
        }

        // POST: BookingServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingServiceId,RoomId,RoomServiceId,BookingSVDate,Request")] BookingService bookingService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookingService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomName", bookingService.RoomId);
            ViewData["RoomServiceId"] = new SelectList(_context.RoomServices, "RoomServiceId", "RoomServiceName", bookingService.RoomServiceId);
            return View(bookingService);
        }

        // GET: BookingServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingService = await _context.BookingsService.FindAsync(id);
            if (bookingService == null)
            {
                return NotFound();
            }
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomName", bookingService.RoomId);
            ViewData["RoomServiceId"] = new SelectList(_context.RoomServices, "RoomServiceId", "RoomServiceName", bookingService.RoomServiceId);
            return View(bookingService);
        }

        // POST: BookingServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingServiceId,RoomId,RoomServiceId,BookingSVDate,Request")] BookingService bookingService)
        {
            if (id != bookingService.BookingServiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookingService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingServiceExists(bookingService.BookingServiceId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomName", bookingService.RoomId);
            ViewData["RoomServiceId"] = new SelectList(_context.RoomServices, "RoomServiceId", "RoomServiceName", bookingService.RoomServiceId);
            return View(bookingService);
        }

        // GET: BookingServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingService = await _context.BookingsService
                .Include(b => b.RoomNav)
                .Include(b => b.RoomServiceNav)
                .FirstOrDefaultAsync(m => m.BookingServiceId == id);
            if (bookingService == null)
            {
                return NotFound();
            }

            return View(bookingService);
        }

        // POST: BookingServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookingService = await _context.BookingsService.FindAsync(id);
            if (bookingService != null)
            {
                _context.BookingsService.Remove(bookingService);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingServiceExists(int id)
        {
            return _context.BookingsService.Any(e => e.BookingServiceId == id);
        }
    }
}
