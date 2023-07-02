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
    public class RECEPTIONsController : Controller
    {
        private readonly ISHPlusTestContext _context;

        public RECEPTIONsController(ISHPlusTestContext context)
        {
            _context = context;
        }

        // GET: RECEPTIONs
        public async Task<IActionResult> Index()
        {
              return _context.RECEPTION != null ? 
                          View(await _context.RECEPTION.ToListAsync()) :
                          Problem("Entity set 'ISHPlusTestContext.RECEPTION'  is null.");
        }

        // GET: RECEPTIONs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RECEPTION == null)
            {
                return NotFound();
            }

            var rECEPTION = await _context.RECEPTION
                .FirstOrDefaultAsync(m => m.id == id);
            if (rECEPTION == null)
            {
                return NotFound();
            }

            return View(rECEPTION);
        }

        // GET: RECEPTIONs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RECEPTIONs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,TEL_NO,EMAIL,HOSP_NAME")] RECEPTION rECEPTION)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rECEPTION);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rECEPTION);
        }

        // GET: RECEPTIONs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RECEPTION == null)
            {
                return NotFound();
            }

            var rECEPTION = await _context.RECEPTION.FindAsync(id);
            if (rECEPTION == null)
            {
                return NotFound();
            }
            return View(rECEPTION);
        }

        // POST: RECEPTIONs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,TEL_NO,EMAIL,HOSP_NAME")] RECEPTION rECEPTION)
        {
            if (id != rECEPTION.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rECEPTION);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RECEPTIONExists(rECEPTION.id))
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
            return View(rECEPTION);
        }

        // GET: RECEPTIONs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RECEPTION == null)
            {
                return NotFound();
            }

            var rECEPTION = await _context.RECEPTION
                .FirstOrDefaultAsync(m => m.id == id);
            if (rECEPTION == null)
            {
                return NotFound();
            }

            return View(rECEPTION);
        }

        // POST: RECEPTIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RECEPTION == null)
            {
                return Problem("Entity set 'ISHPlusTestContext.RECEPTION'  is null.");
            }
            var rECEPTION = await _context.RECEPTION.FindAsync(id);
            if (rECEPTION != null)
            {
                _context.RECEPTION.Remove(rECEPTION);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RECEPTIONExists(int id)
        {
          return (_context.RECEPTION?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
