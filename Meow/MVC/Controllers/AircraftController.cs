using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BussinessLayer;
using DataLayer;

namespace MVC.Controllers
{
    public class AircraftController : Controller
    {
        private readonly MeowDbContext _context;

        public AircraftController(MeowDbContext context)
        {
            _context = context;
        }

        // GET: Aircraft
        public async Task<IActionResult> Index()
        {
            var meowDbContext = _context.Aircrafts.Include(a => a.Brand).Include(a => a.Model);
            return View(await meowDbContext.ToListAsync());
        }

        // GET: Aircraft/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Aircrafts == null)
            {
                return NotFound();
            }

            var aircraft = await _context.Aircrafts
                .Include(a => a.Brand)
                .Include(a => a.Model)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aircraft == null)
            {
                return NotFound();
            }

            return View(aircraft);
        }

        // GET: Aircraft/Create
        public IActionResult Create()
        {
            ViewData["BrandIdF"] = new SelectList(_context.Brands, "BrandId", "Name");
            ViewData["ModelIdF"] = new SelectList(_context.Models, "ModelId", "Name");
            return View();
        }

        // POST: Aircraft/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Price,Thrust,Description,BrandIdF,ModelIdF")] Aircraft aircraft)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aircraft);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandIdF"] = new SelectList(_context.Brands, "BrandId", "Name", aircraft.BrandIdF);
            ViewData["ModelIdF"] = new SelectList(_context.Models, "ModelId", "Name", aircraft.ModelIdF);
            return View(aircraft);
        }

        // GET: Aircraft/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Aircrafts == null)
            {
                return NotFound();
            }

            var aircraft = await _context.Aircrafts.FindAsync(id);
            if (aircraft == null)
            {
                return NotFound();
            }
            ViewData["BrandIdF"] = new SelectList(_context.Brands, "BrandId", "Name", aircraft.BrandIdF);
            ViewData["ModelIdF"] = new SelectList(_context.Models, "ModelId", "Name", aircraft.ModelIdF);
            return View(aircraft);
        }

        // POST: Aircraft/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Price,Thrust,Description,BrandIdF,ModelIdF")] Aircraft aircraft)
        {
            if (id != aircraft.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aircraft);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AircraftExists(aircraft.Id))
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
            ViewData["BrandIdF"] = new SelectList(_context.Brands, "BrandId", "Name", aircraft.BrandIdF);
            ViewData["ModelIdF"] = new SelectList(_context.Models, "ModelId", "Name", aircraft.ModelIdF);
            return View(aircraft);
        }

        // GET: Aircraft/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var aircraft = await _context.Aircrafts
                .Include(a => a.Brand)
                .Include(a => a.Model)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aircraft == null)
            {
                return NotFound();
            }

            return View(aircraft);
        }

        // POST: Aircraft/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'MeowDbContext.Aircrafts'  is null.");
            }
            var aircraft = await _context.Users.FindAsync(id);
            if (aircraft != null)
            {
                _context.Users.Remove(aircraft);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AircraftExists(int id)
        {
          return (_context.Aircrafts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
