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
    public class CarsController : Controller
    {
        private readonly MeowDbContext _context;

        public CarsController(MeowDbContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var meowDbContext = _context.Cars.Include(c => c.Brand).Include(c => c.Model).Include(c => c.User_);
            return View(await meowDbContext.ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.Brand)
                .Include(c => c.Model)
                .Include(c => c.User_)
                .FirstOrDefaultAsync(m => m.CarId == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            ViewData["BrandIdF"] = new SelectList(_context.Brands, "BrandId", "Name");
            ViewData["ModelIdF"] = new SelectList(_context.Models, "ModelId", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarId,BrandIdF,ModelIdF,Price,Mileage,HorsePower,Description,UserId")] Car car)
        {
            ModelState.Clear();
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandIdF"] = new SelectList(_context.Brands, "BrandId", "Name", car.BrandIdF);
            ViewData["ModelIdF"] = new SelectList(_context.Models, "ModelId", "Name", car.ModelIdF);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", car.UserId);
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["BrandIdF"] = new SelectList(_context.Brands, "BrandId", "Name", car.BrandIdF);
            ViewData["ModelIdF"] = new SelectList(_context.Models, "ModelId", "Name", car.ModelIdF);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", car.UserId);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarId,BrandIdF,ModelIdF,Price,Mileage,HorsePower,Description,UserId")] Car car)
        {
            if (id != car.CarId)
            {
                return NotFound();
            }
            ModelState.Clear();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.CarId))
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
            ViewData["BrandIdF"] = new SelectList(_context.Brands, "BrandId", "Name", car.BrandIdF);
            ViewData["ModelIdF"] = new SelectList(_context.Models, "ModelId", "Name", car.ModelIdF);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", car.UserId);
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.Brand)
                .Include(c => c.Model)
                .Include(c => c.User_)
                .FirstOrDefaultAsync(m => m.CarId == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cars == null)
            {
                return Problem("Entity set 'MeowDbContext.Cars'  is null.");
            }
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
          return (_context.Cars?.Any(e => e.CarId == id)).GetValueOrDefault();
        }
    }
}
