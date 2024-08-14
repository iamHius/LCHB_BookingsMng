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
    public class BookingRoomsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingRoomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookingRooms
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Bookings.Include(b => b.RoomNav).Include(b => b.RoomServiceNav).Include(b => b.StatusPaymentNav);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BookingRooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingRoom = await _context.Bookings
                .Include(b => b.RoomNav)
                .Include(b => b.RoomServiceNav)
                .Include(b => b.StatusPaymentNav)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (bookingRoom == null)
            {
                return NotFound();
            }

            return View(bookingRoom);
        }

        // GET: BookingRooms/Create
        public IActionResult Create()
        {
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomName");
            ViewData["RoomServiceId"] = new SelectList(_context.RoomServices, "RoomServiceId", "RoomServiceName");
            ViewData["StatusPaymentId"] = new SelectList(_context.StatusPayments, "PaymentStatusId", "PaymentStatus");
            return View();
        }

        // POST: BookingRooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,RoomId,RoomServiceId,StatusPaymentId,BookingFromDate,BookingToDate,BookingEmail")] BookingRoom bookingRoom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookingRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomName", bookingRoom.RoomId);
            ViewData["RoomServiceId"] = new SelectList(_context.RoomServices, "RoomServiceId", "RoomServiceName", bookingRoom.RoomServiceId);
            ViewData["StatusPaymentId"] = new SelectList(_context.StatusPayments, "PaymentStatusId", "PaymentStatus", bookingRoom.StatusPaymentId);
            return View(bookingRoom);
        }

        // GET: BookingRooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingRoom = await _context.Bookings.FindAsync(id);
            if (bookingRoom == null)
            {
                return NotFound();
            }
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomName", bookingRoom.RoomId);
            ViewData["RoomServiceId"] = new SelectList(_context.RoomServices, "RoomServiceId", "RoomServiceName", bookingRoom.RoomServiceId);
            ViewData["StatusPaymentId"] = new SelectList(_context.StatusPayments, "PaymentStatusId", "PaymentStatus", bookingRoom.StatusPaymentId);
            return View(bookingRoom);
        }

        // POST: BookingRooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingId,RoomId,RoomServiceId,StatusPaymentId,BookingFromDate,BookingToDate,BookingEmail")] BookingRoom bookingRoom)
        {
            if (id != bookingRoom.BookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookingRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingRoomExists(bookingRoom.BookingId))
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
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomName", bookingRoom.RoomId);
            ViewData["RoomServiceId"] = new SelectList(_context.RoomServices, "RoomServiceId", "RoomServiceName", bookingRoom.RoomServiceId);
            ViewData["StatusPaymentId"] = new SelectList(_context.StatusPayments, "PaymentStatusId", "PaymentStatus", bookingRoom.StatusPaymentId);
            return View(bookingRoom);
        }

        // GET: BookingRooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingRoom = await _context.Bookings
                .Include(b => b.RoomNav)
                .Include(b => b.RoomServiceNav)
                .Include(b => b.StatusPaymentNav)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (bookingRoom == null)
            {
                return NotFound();
            }

            return View(bookingRoom);
        }

        // POST: BookingRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookingRoom = await _context.Bookings.FindAsync(id);
            if (bookingRoom != null)
            {
                _context.Bookings.Remove(bookingRoom);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingRoomExists(int id)
        {
            return _context.Bookings.Any(e => e.BookingId == id);
        }
    }
}
