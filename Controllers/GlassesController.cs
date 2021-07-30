using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlassApplication.Data;
using GlassApplication.Models;
using GlassApplication.Repositories;

namespace GlassApplication.Controllers
{
    public class GlassesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IGlassRepository _glassRepository;

        public GlassesController(ApplicationDbContext context, IGlassRepository glassRepository)
        {
            _context = context;
            _glassRepository = glassRepository;
        }

        // GET: Glasses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Glasses.Include(g => g.Order);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Glasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var glass = await _context.Glasses
                .Include(g => g.Order)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (glass == null)
            {
                return NotFound();
            }

            return View(glass);
        }

        // GET: Glasses/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id");
            return View();
        }

        // POST: Glasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderId,Thickness,Width,Height,GlassDescription")] Glass glass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(glass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", glass.OrderId);
            return View(glass);
        }

        // GET: Glasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var glass = await _context.Glasses.FindAsync(id);
            if (glass == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", glass.OrderId);
            return View(glass);
        }

        // POST: Glasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderId,Thickness,Width,Height,GlassDescription")] Glass glass)
        {
            if (id != glass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(glass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GlassExists(glass.Id))
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
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", glass.OrderId);
            return View(glass);
        }

        // GET: Glasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var glass = await _context.Glasses
                .Include(g => g.Order)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (glass == null)
            {
                return NotFound();
            }

            return View(glass);
        }

        // POST: Glasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var glass = await _context.Glasses.FindAsync(id);
            _context.Glasses.Remove(glass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GlassExists(int id)
        {
            return _context.Glasses.Any(e => e.Id == id);
        }


        public IActionResult GlassArea(int id)
        {
            double result =  _glassRepository.GlassArea(1);
            return Ok(result);
        }

        public IActionResult GetGlassesByOrderId(int id)
        {
            var glasses = _glassRepository.GetGlassesByOrderId(id);
            return View(glasses);
        }
            
    }
}
