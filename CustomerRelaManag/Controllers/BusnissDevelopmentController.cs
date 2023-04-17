using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomerRelaManag.Data;
using CustomerRelaManag.Models;

namespace CustomerRelaManag.Controllers
{
    public class BusnissDevelopmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BusnissDevelopmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BusnissDevelopment
        public async Task<IActionResult> Index()
        {
              return _context.BDEs != null ? 
                          View(await _context.BDEs.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.BDEs'  is null.");
        }

        // GET: BusnissDevelopment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BDEs == null)
            {
                return NotFound();
            }

            var bDE = await _context.BDEs
                .FirstOrDefaultAsync(m => m.BDEId == id);
            if (bDE == null)
            {
                return NotFound();
            }

            return View(bDE);
        }

        // GET: BusnissDevelopment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BusnissDevelopment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BDEId,BDEName,ProjectId,AssignTo,CreatedDate")] BDE bDE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bDE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bDE);
        }

        // GET: BusnissDevelopment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BDEs == null)
            {
                return NotFound();
            }

            var bDE = await _context.BDEs.FindAsync(id);
            if (bDE == null)
            {
                return NotFound();
            }
            return View(bDE);
        }

        // POST: BusnissDevelopment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BDEId,BDEName,ProjectId,AssignTo,CreatedDate")] BDE bDE)
        {
            if (id != bDE.BDEId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bDE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BDEExists(bDE.BDEId))
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
            return View(bDE);
        }

        // GET: BusnissDevelopment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BDEs == null)
            {
                return NotFound();
            }

            var bDE = await _context.BDEs
                .FirstOrDefaultAsync(m => m.BDEId == id);
            if (bDE == null)
            {
                return NotFound();
            }

            return View(bDE);
        }

        // POST: BusnissDevelopment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BDEs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BDEs'  is null.");
            }
            var bDE = await _context.BDEs.FindAsync(id);
            if (bDE != null)
            {
                _context.BDEs.Remove(bDE);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BDEExists(int id)
        {
          return (_context.BDEs?.Any(e => e.BDEId == id)).GetValueOrDefault();
        }
    }
}
