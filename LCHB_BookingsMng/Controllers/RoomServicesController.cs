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
    public class RoomServicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoomServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RoomServices
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoomServices.ToListAsync());
        }

        // GET: RoomServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomService = await _context.RoomServices
                .FirstOrDefaultAsync(m => m.RoomServiceId == id);
            if (roomService == null)
            {
                return NotFound();
            }

            return View(roomService);
        }

        // GET: RoomServices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomServiceId,RoomServiceName,RoomServicePrice,Quantity")] RoomService roomService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomService);
        }

        // GET: RoomServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomService = await _context.RoomServices.FindAsync(id);
            if (roomService == null)
            {
                return NotFound();
            }
            return View(roomService);
        }

        // POST: RoomServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomServiceId,RoomServiceName,RoomServicePrice,Quantity")] RoomService roomService)
        {
            if (id != roomService.RoomServiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomServiceExists(roomService.RoomServiceId))
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
            return View(roomService);
        }

        // GET: RoomServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomService = await _context.RoomServices
                .FirstOrDefaultAsync(m => m.RoomServiceId == id);
            if (roomService == null)
            {
                return NotFound();
            }

            return View(roomService);
        }

        // POST: RoomServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomService = await _context.RoomServices.FindAsync(id);
            if (roomService != null)
            {
                _context.RoomServices.Remove(roomService);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomServiceExists(int id)
        {
            return _context.RoomServices.Any(e => e.RoomServiceId == id);
        }
    }
}
