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
    public class EXAMINEsController : Controller
    {
        private readonly ISHPlusTestContext _context;

        public EXAMINEsController(ISHPlusTestContext context)
        {
            _context = context;
        }

        // GET: EXAMINEs
        public async Task<IActionResult> Index()
        {
              return _context.EXAMINE != null ? 
                          View(await _context.EXAMINE.ToListAsync()) :
                          Problem("Entity set 'ISHPlusTestContext.EXAMINE'  is null.");
        }

        // GET: EXAMINEs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EXAMINE == null)
            {
                return NotFound();
            }

            var eXAMINE = await _context.EXAMINE
                .FirstOrDefaultAsync(m => m.id == id);
            if (eXAMINE == null)
            {
                return NotFound();
            }

            return View(eXAMINE);
        }

        // GET: EXAMINEs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EXAMINEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,DOC_ID")] EXAMINE eXAMINE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eXAMINE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eXAMINE);
        }

        // GET: EXAMINEs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EXAMINE == null)
            {
                return NotFound();
            }

            var eXAMINE = await _context.EXAMINE.FindAsync(id);
            if (eXAMINE == null)
            {
                return NotFound();
            }
            return View(eXAMINE);
        }

        // POST: EXAMINEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,DOC_ID")] EXAMINE eXAMINE)
        {
            if (id != eXAMINE.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eXAMINE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EXAMINEExists(eXAMINE.id))
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
            return View(eXAMINE);
        }

        // GET: EXAMINEs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EXAMINE == null)
            {
                return NotFound();
            }

            var eXAMINE = await _context.EXAMINE
                .FirstOrDefaultAsync(m => m.id == id);
            if (eXAMINE == null)
            {
                return NotFound();
            }

            return View(eXAMINE);
        }

        // POST: EXAMINEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EXAMINE == null)
            {
                return Problem("Entity set 'ISHPlusTestContext.EXAMINE'  is null.");
            }
            var eXAMINE = await _context.EXAMINE.FindAsync(id);
            if (eXAMINE != null)
            {
                _context.EXAMINE.Remove(eXAMINE);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EXAMINEExists(int id)
        {
          return (_context.EXAMINE?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
