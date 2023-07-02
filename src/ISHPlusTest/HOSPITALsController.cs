using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AML.Infrastructure.Data.EF;
using ISHPlusTest.Data;

namespace ISHPlusTest
{
    public class HOSPITALsController : Controller
    {
        private readonly ISHPlusTestContext _context;

        public HOSPITALsController(ISHPlusTestContext context)
        {
            _context = context;
        }

        // GET: HOSPITALs
        public async Task<IActionResult> Index()
        {
              return _context.HOSPITAL != null ? 
                          View(await _context.HOSPITAL.ToListAsync()) :
                          Problem("Entity set 'ISHPlusTestContext.HOSPITAL'  is null.");
        }

        // GET: HOSPITALs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HOSPITAL == null)
            {
                return NotFound();
            }

            var hOSPITAL = await _context.HOSPITAL
                .FirstOrDefaultAsync(m => m.id == id);
            if (hOSPITAL == null)
            {
                return NotFound();
            }

            return View(hOSPITAL);
        }

        // GET: HOSPITALs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HOSPITALs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,COUNTRY,ADDRESS")] HOSPITAL hOSPITAL)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hOSPITAL);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hOSPITAL);
        }

        // GET: HOSPITALs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HOSPITAL == null)
            {
                return NotFound();
            }

            var hOSPITAL = await _context.HOSPITAL.FindAsync(id);
            if (hOSPITAL == null)
            {
                return NotFound();
            }
            return View(hOSPITAL);
        }

        // POST: HOSPITALs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,COUNTRY,ADDRESS")] HOSPITAL hOSPITAL)
        {
            if (id != hOSPITAL.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hOSPITAL);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HOSPITALExists(hOSPITAL.id))
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
            return View(hOSPITAL);
        }

        // GET: HOSPITALs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HOSPITAL == null)
            {
                return NotFound();
            }

            var hOSPITAL = await _context.HOSPITAL
                .FirstOrDefaultAsync(m => m.id == id);
            if (hOSPITAL == null)
            {
                return NotFound();
            }

            return View(hOSPITAL);
        }

        // POST: HOSPITALs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HOSPITAL == null)
            {
                return Problem("Entity set 'ISHPlusTestContext.HOSPITAL'  is null.");
            }
            var hOSPITAL = await _context.HOSPITAL.FindAsync(id);
            if (hOSPITAL != null)
            {
                _context.HOSPITAL.Remove(hOSPITAL);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HOSPITALExists(int id)
        {
          return (_context.HOSPITAL?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
