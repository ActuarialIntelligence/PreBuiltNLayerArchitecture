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
    public class PURCHASEsController : Controller
    {
        private readonly ISHPlusTestContext _context;

        public PURCHASEsController(ISHPlusTestContext context)
        {
            _context = context;
        }

        // GET: PURCHASEs
        public async Task<IActionResult> Index()
        {
              return _context.PURCHASE != null ? 
                          View(await _context.PURCHASE.ToListAsync()) :
                          Problem("Entity set 'ISHPlusTestContext.PURCHASE'  is null.");
        }

        // GET: PURCHASEs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PURCHASE == null)
            {
                return NotFound();
            }

            var pURCHASE = await _context.PURCHASE
                .FirstOrDefaultAsync(m => m.id == id);
            if (pURCHASE == null)
            {
                return NotFound();
            }

            return View(pURCHASE);
        }

        // GET: PURCHASEs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PURCHASEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,REG_NO")] PURCHASE pURCHASE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pURCHASE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pURCHASE);
        }

        // GET: PURCHASEs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PURCHASE == null)
            {
                return NotFound();
            }

            var pURCHASE = await _context.PURCHASE.FindAsync(id);
            if (pURCHASE == null)
            {
                return NotFound();
            }
            return View(pURCHASE);
        }

        // POST: PURCHASEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,REG_NO")] PURCHASE pURCHASE)
        {
            if (id != pURCHASE.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pURCHASE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PURCHASEExists(pURCHASE.id))
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
            return View(pURCHASE);
        }

        // GET: PURCHASEs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PURCHASE == null)
            {
                return NotFound();
            }

            var pURCHASE = await _context.PURCHASE
                .FirstOrDefaultAsync(m => m.id == id);
            if (pURCHASE == null)
            {
                return NotFound();
            }

            return View(pURCHASE);
        }

        // POST: PURCHASEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PURCHASE == null)
            {
                return Problem("Entity set 'ISHPlusTestContext.PURCHASE'  is null.");
            }
            var pURCHASE = await _context.PURCHASE.FindAsync(id);
            if (pURCHASE != null)
            {
                _context.PURCHASE.Remove(pURCHASE);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PURCHASEExists(int id)
        {
          return (_context.PURCHASE?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
