using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreFront.DATA.EF.Models;

namespace StoreFront.UI.MVC.Controllers
{
    public class WaresController : Controller
    {
        private readonly UndeadBurgGeneralContext _context;

        public WaresController(UndeadBurgGeneralContext context)
        {
            _context = context;
        }

        // GET: Wares
        public async Task<IActionResult> Index()
        {
            var undeadBurgGeneralContext = _context.Wares.Include(w => w.Manufacturer).Include(w => w.StockStatus).Include(w => w.Type);
            return View(await undeadBurgGeneralContext.ToListAsync());
        }

        public IActionResult Shop()
        {
            var wares = _context.Wares.Include(w => w.Manufacturer).Include(w => w.StockStatus).Include(w => w.Type);
            return View(wares.ToList());
        }

        // GET: Wares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Wares == null)
            {
                return NotFound();
            }

            var ware = await _context.Wares
                .Include(w => w.Manufacturer)
                .Include(w => w.StockStatus)
                .Include(w => w.Type)
                .FirstOrDefaultAsync(m => m.WaresId == id);
            if (ware == null)
            {
                return NotFound();
            }

            return View(ware);
        }

        // GET: Wares/Create
        public IActionResult Create()
        {
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "ManufacturerId", "ManufacturerName");
            ViewData["StockStatusId"] = new SelectList(_context.StockStatuses, "Id", "StockStatus1");
            ViewData["TypeId"] = new SelectList(_context.Types, "TypeId", "Type1");
            return View();
        }

        // POST: Wares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WaresName,WaresId,Description,TypeId,Price,ManufacturerId,StockStatusId,Quantity,WareImage")] Ware ware)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ware);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "ManufacturerId", "ManufacturerName", ware.ManufacturerId);
            ViewData["StockStatusId"] = new SelectList(_context.StockStatuses, "Id", "StockStatus1", ware.StockStatusId);
            ViewData["TypeId"] = new SelectList(_context.Types, "TypeId", "Type1", ware.TypeId);
            return View(ware);
        }

        // GET: Wares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Wares == null)
            {
                return NotFound();
            }

            var ware = await _context.Wares.FindAsync(id);
            if (ware == null)
            {
                return NotFound();
            }
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "ManufacturerId", "ManufacturerName", ware.ManufacturerId);
            ViewData["StockStatusId"] = new SelectList(_context.StockStatuses, "Id", "StockStatus1", ware.StockStatusId);
            ViewData["TypeId"] = new SelectList(_context.Types, "TypeId", "Type1", ware.TypeId);
            return View(ware);
        }

        // POST: Wares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WaresName,WaresId,Description,TypeId,Price,ManufacturerId,StockStatusId,Quantity,WareImage")] Ware ware)
        {
            if (id != ware.WaresId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ware);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WareExists(ware.WaresId))
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
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "ManufacturerId", "ManufacturerName", ware.ManufacturerId);
            ViewData["StockStatusId"] = new SelectList(_context.StockStatuses, "Id", "StockStatus1", ware.StockStatusId);
            ViewData["TypeId"] = new SelectList(_context.Types, "TypeId", "Type1", ware.TypeId);
            return View(ware);
        }

        // GET: Wares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Wares == null)
            {
                return NotFound();
            }

            var ware = await _context.Wares
                .Include(w => w.Manufacturer)
                .Include(w => w.StockStatus)
                .Include(w => w.Type)
                .FirstOrDefaultAsync(m => m.WaresId == id);
            if (ware == null)
            {
                return NotFound();
            }

            return View(ware);
        }

        // POST: Wares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Wares == null)
            {
                return Problem("Entity set 'UndeadBurgGeneralContext.Wares'  is null.");
            }
            var ware = await _context.Wares.FindAsync(id);
            if (ware != null)
            {
                _context.Wares.Remove(ware);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WareExists(int id)
        {
          return (_context.Wares?.Any(e => e.WaresId == id)).GetValueOrDefault();
        }
    }
}
