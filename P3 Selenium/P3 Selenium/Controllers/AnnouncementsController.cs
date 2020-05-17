using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P3_Selenium.Data;
using P3_Selenium.Models;

namespace P3_Selenium.Controllers
{
    
    public class AnnouncementsController : Controller
    {
        private readonly P3_SeleniumContext _context;

        public AnnouncementsController(P3_SeleniumContext context)
        {
            _context = context;
        }

        // GET: Announcements
        public async Task<IActionResult> Index(int? min, int? max)
        {
            


            var p3_SeleniumContext = _context.Announcement.Include(a => a.Car).Include(a => a.Owner);
            IQueryable<Announcement> xD = p3_SeleniumContext;
            
            if(min != null)
            {

                xD = xD.Where(a => a.Price >= min);

            }

            if (max != null)
            {

                xD = xD.Where(a => a.Price <= max);

            }

            return View(await xD.ToListAsync());

        }

     

        // GET: Announcements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcement
                .Include(a => a.Car)
                .Include(a => a.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (announcement == null)
            {
                return NotFound();
            }

            return View(announcement);
        }
        [Authorize]
        // GET: Announcements/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Set<Car>(), "Id", "ModelName");
            ViewData["OwnerId"] = new SelectList(_context.Set<Owner>(), "Id", "EmailAdress");
            return View();
        }

        // POST: Announcements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HorsePower,Price,ProductionDate,FuelType,Description,CarId,OwnerId")] Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(announcement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Set<Car>(), "Id", "ModelName", announcement.CarId);
            ViewData["OwnerId"] = new SelectList(_context.Set<Owner>(), "Id", "EmailAdress", announcement.OwnerId);
            return View(announcement);
        }
        [Authorize]
        // GET: Announcements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcement.FindAsync(id);
            if (announcement == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Set<Car>(), "Id", "ModelName", announcement.CarId);
            ViewData["OwnerId"] = new SelectList(_context.Set<Owner>(), "Id", "EmailAdress", announcement.OwnerId);
            return View(announcement);
        }

        // POST: Announcements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HorsePower,Price,ProductionDate,FuelType,Description,CarId,OwnerId")] Announcement announcement)
        {
            if (id != announcement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(announcement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnnouncementExists(announcement.Id))
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
            ViewData["CarId"] = new SelectList(_context.Set<Car>(), "Id", "ModelName", announcement.CarId);
            ViewData["OwnerId"] = new SelectList(_context.Set<Owner>(), "Id", "EmailAdress", announcement.OwnerId);
            return View(announcement);
        }
        [Authorize]
        // GET: Announcements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcement
                .Include(a => a.Car)
                .Include(a => a.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (announcement == null)
            {
                return NotFound();
            }

            return View(announcement);
        }

        // POST: Announcements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var announcement = await _context.Announcement.FindAsync(id);
            _context.Announcement.Remove(announcement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnnouncementExists(int id)
        {
            return _context.Announcement.Any(e => e.Id == id);
        }
    }
}
