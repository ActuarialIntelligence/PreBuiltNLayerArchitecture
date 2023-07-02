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
    public class NURSEsController : Controller
    {
        private readonly ISHPlusTestContext _context;

        public NURSEsController(ISHPlusTestContext context)
        {
            _context = context;
        }

        // GET: NURSEs
        public async Task<IActionResult> Index()
        {
              return _context.NURSE != null ? 
                          View(await _context.NURSE.ToListAsync()) :
                          Problem("Entity set 'ISHPlusTestContext.NURSE'  is null.");
        }

        // GET: NURSEs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NURSE == null)
            {
                return NotFound();
            }

            var nURSE = await _context.NURSE
                .FirstOrDefaultAsync(m => m.id == id);
            if (nURSE == null)
            {
                return NotFound();
            }

            return View(nURSE);
        }

        // GET: NURSEs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NURSEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,NAME,GENDER,DOC_ID,HOSP_NAME")] NURSE nURSE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nURSE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nURSE);
        }

        // GET: NURSEs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NURSE == null)
            {
                return NotFound();
            }

            var nURSE = await _context.NURSE.FindAsync(id);
            if (nURSE == null)
            {
                return NotFound();
            }
            return View(nURSE);
        }

        // POST: NURSEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,NAME,GENDER,DOC_ID,HOSP_NAME")] NURSE nURSE)
        {
            if (id != nURSE.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nURSE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NURSEExists(nURSE.id))
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
            return View(nURSE);
        }

        // GET: NURSEs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NURSE == null)
            {
                return NotFound();
            }

            var nURSE = await _context.NURSE
                .FirstOrDefaultAsync(m => m.id == id);
            if (nURSE == null)
            {
                return NotFound();
            }

            return View(nURSE);
        }

        // POST: NURSEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NURSE == null)
            {
                return Problem("Entity set 'ISHPlusTestContext.NURSE'  is null.");
            }
            var nURSE = await _context.NURSE.FindAsync(id);
            if (nURSE != null)
            {
                _context.NURSE.Remove(nURSE);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NURSEExists(int id)
        {
          return (_context.NURSE?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
