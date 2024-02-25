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
    public class BoatsController : Controller
    {
        private readonly MeowDbContext _context;

        public BoatsController(MeowDbContext context)
        {
            _context = context;
        }

        // GET: Boats
        public async Task<IActionResult> Index()
        {
            var meowDbContext = _context.Boats.Include(b => b.Brand).Include(b => b.Model);
            return View(await meowDbContext.ToListAsync());
        }

        // GET: Boats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Boats == null)
            {
                return NotFound();
            }

            var boat = await _context.Boats
                .Include(b => b.Brand)
                .Include(b => b.Model)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boat == null)
            {
                return NotFound();
            }

            return View(boat);
        }

        // GET: Boats/Create
        public IActionResult Create()
        {
            ViewData["BrandIdF"] = new SelectList(_context.Brands, "BrandId", "Name");
            ViewData["ModelIdF"] = new SelectList(_context.Models, "ModelId", "Name");
            return View();
        }

        // POST: Boats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Price,Hp,Description,BrandIdF,ModelIdF")] Boat boat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandIdF"] = new SelectList(_context.Brands, "BrandId", "Name", boat.BrandIdF);
            ViewData["ModelIdF"] = new SelectList(_context.Models, "ModelId", "Name", boat.ModelIdF);
            return View(boat);
        }

        // GET: Boats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Boats == null)
            {
                return NotFound();
            }

            var boat = await _context.Boats.FindAsync(id);
            if (boat == null)
            {
                return NotFound();
            }
            ViewData["BrandIdF"] = new SelectList(_context.Brands, "BrandId", "Name", boat.BrandIdF);
            ViewData["ModelIdF"] = new SelectList(_context.Models, "ModelId", "Name", boat.ModelIdF);
            return View(boat);
        }

        // POST: Boats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Price,Hp,Description,BrandIdF,ModelIdF")] Boat boat)
        {
            if (id != boat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoatExists(boat.Id))
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
            ViewData["BrandIdF"] = new SelectList(_context.Brands, "BrandId", "Name", boat.BrandIdF);
            ViewData["ModelIdF"] = new SelectList(_context.Models, "ModelId", "Name", boat.ModelIdF);
            return View(boat);
        }

        // GET: Boats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Boats == null)
            {
                return NotFound();
            }

            var boat = await _context.Boats
                .Include(b => b.Brand)
                .Include(b => b.Model)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boat == null)
            {
                return NotFound();
            }

            return View(boat);
        }

        // POST: Boats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Boats == null)
            {
                return Problem("Entity set 'MeowDbContext.Boats'  is null.");
            }
            var boat = await _context.Boats.FindAsync(id);
            if (boat != null)
            {
                _context.Boats.Remove(boat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoatExists(int id)
        {
          return (_context.Boats?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
