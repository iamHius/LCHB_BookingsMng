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
    public class RoomStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoomStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RoomStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoomStatuses.ToListAsync());
        }

        // GET: RoomStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomStatus = await _context.RoomStatuses
                .FirstOrDefaultAsync(m => m.RoomStatusId == id);
            if (roomStatus == null)
            {
                return NotFound();
            }

            return View(roomStatus);
        }

        // GET: RoomStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomStatusId,RoomStatusName")] RoomStatus roomStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomStatus);
        }

        // GET: RoomStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomStatus = await _context.RoomStatuses.FindAsync(id);
            if (roomStatus == null)
            {
                return NotFound();
            }
            return View(roomStatus);
        }

        // POST: RoomStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomStatusId,RoomStatusName")] RoomStatus roomStatus)
        {
            if (id != roomStatus.RoomStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomStatusExists(roomStatus.RoomStatusId))
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
            return View(roomStatus);
        }

        // GET: RoomStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomStatus = await _context.RoomStatuses
                .FirstOrDefaultAsync(m => m.RoomStatusId == id);
            if (roomStatus == null)
            {
                return NotFound();
            }

            return View(roomStatus);
        }

        // POST: RoomStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomStatus = await _context.RoomStatuses.FindAsync(id);
            if (roomStatus != null)
            {
                _context.RoomStatuses.Remove(roomStatus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomStatusExists(int id)
        {
            return _context.RoomStatuses.Any(e => e.RoomStatusId == id);
        }
    }
}
