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
    public class DIAGNOSIsController : Controller
    {
        private readonly ISHPlusTestContext _context;

        public DIAGNOSIsController(ISHPlusTestContext context)
        {
            _context = context;
        }

        // GET: DIAGNOSIs
        public async Task<IActionResult> Index()
        {
              return _context.DIAGNOSI != null ? 
                          View(await _context.DIAGNOSI.ToListAsync()) :
                          Problem("Entity set 'ISHPlusTestContext.DIAGNOSI'  is null.");
        }

        // GET: DIAGNOSIs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DIAGNOSI == null)
            {
                return NotFound();
            }

            var dIAGNOSI = await _context.DIAGNOSI
                .FirstOrDefaultAsync(m => m.id == id);
            if (dIAGNOSI == null)
            {
                return NotFound();
            }

            return View(dIAGNOSI);
        }

        // GET: DIAGNOSIs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DIAGNOSIs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,ISSUE_DATE,TREATMENT,REMARKS,NURSE_ID,DOC_ID")] DIAGNOSI dIAGNOSI)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dIAGNOSI);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dIAGNOSI);
        }

        // GET: DIAGNOSIs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DIAGNOSI == null)
            {
                return NotFound();
            }

            var dIAGNOSI = await _context.DIAGNOSI.FindAsync(id);
            if (dIAGNOSI == null)
            {
                return NotFound();
            }
            return View(dIAGNOSI);
        }

        // POST: DIAGNOSIs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,ISSUE_DATE,TREATMENT,REMARKS,NURSE_ID,DOC_ID")] DIAGNOSI dIAGNOSI)
        {
            if (id != dIAGNOSI.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dIAGNOSI);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DIAGNOSIExists(dIAGNOSI.id))
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
            return View(dIAGNOSI);
        }

        // GET: DIAGNOSIs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DIAGNOSI == null)
            {
                return NotFound();
            }

            var dIAGNOSI = await _context.DIAGNOSI
                .FirstOrDefaultAsync(m => m.id == id);
            if (dIAGNOSI == null)
            {
                return NotFound();
            }

            return View(dIAGNOSI);
        }

        // POST: DIAGNOSIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DIAGNOSI == null)
            {
                return Problem("Entity set 'ISHPlusTestContext.DIAGNOSI'  is null.");
            }
            var dIAGNOSI = await _context.DIAGNOSI.FindAsync(id);
            if (dIAGNOSI != null)
            {
                _context.DIAGNOSI.Remove(dIAGNOSI);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DIAGNOSIExists(int id)
        {
          return (_context.DIAGNOSI?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
