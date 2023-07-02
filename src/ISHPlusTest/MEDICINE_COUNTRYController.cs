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
    public class MEDICINE_COUNTRYController : Controller
    {
        private readonly ISHPlusTestContext _context;

        public MEDICINE_COUNTRYController(ISHPlusTestContext context)
        {
            _context = context;
        }

        // GET: MEDICINE_COUNTRY
        public async Task<IActionResult> Index()
        {
              return _context.MEDICINE_COUNTRY != null ? 
                          View(await _context.MEDICINE_COUNTRY.ToListAsync()) :
                          Problem("Entity set 'ISHPlusTestContext.MEDICINE_COUNTRY'  is null.");
        }

        // GET: MEDICINE_COUNTRY/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MEDICINE_COUNTRY == null)
            {
                return NotFound();
            }

            var mEDICINE_COUNTRY = await _context.MEDICINE_COUNTRY
                .FirstOrDefaultAsync(m => m.id == id);
            if (mEDICINE_COUNTRY == null)
            {
                return NotFound();
            }

            return View(mEDICINE_COUNTRY);
        }

        // GET: MEDICINE_COUNTRY/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MEDICINE_COUNTRY/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,MAN_COUNTRY")] MEDICINE_COUNTRY mEDICINE_COUNTRY)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mEDICINE_COUNTRY);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mEDICINE_COUNTRY);
        }

        // GET: MEDICINE_COUNTRY/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MEDICINE_COUNTRY == null)
            {
                return NotFound();
            }

            var mEDICINE_COUNTRY = await _context.MEDICINE_COUNTRY.FindAsync(id);
            if (mEDICINE_COUNTRY == null)
            {
                return NotFound();
            }
            return View(mEDICINE_COUNTRY);
        }

        // POST: MEDICINE_COUNTRY/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,MAN_COUNTRY")] MEDICINE_COUNTRY mEDICINE_COUNTRY)
        {
            if (id != mEDICINE_COUNTRY.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mEDICINE_COUNTRY);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MEDICINE_COUNTRYExists(mEDICINE_COUNTRY.id))
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
            return View(mEDICINE_COUNTRY);
        }

        // GET: MEDICINE_COUNTRY/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MEDICINE_COUNTRY == null)
            {
                return NotFound();
            }

            var mEDICINE_COUNTRY = await _context.MEDICINE_COUNTRY
                .FirstOrDefaultAsync(m => m.id == id);
            if (mEDICINE_COUNTRY == null)
            {
                return NotFound();
            }

            return View(mEDICINE_COUNTRY);
        }

        // POST: MEDICINE_COUNTRY/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MEDICINE_COUNTRY == null)
            {
                return Problem("Entity set 'ISHPlusTestContext.MEDICINE_COUNTRY'  is null.");
            }
            var mEDICINE_COUNTRY = await _context.MEDICINE_COUNTRY.FindAsync(id);
            if (mEDICINE_COUNTRY != null)
            {
                _context.MEDICINE_COUNTRY.Remove(mEDICINE_COUNTRY);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MEDICINE_COUNTRYExists(int id)
        {
          return (_context.MEDICINE_COUNTRY?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
