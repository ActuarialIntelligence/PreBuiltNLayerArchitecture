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
    public class MEDICINEsController : Controller
    {
        private readonly ISHPlusTestContext _context;

        public MEDICINEsController(ISHPlusTestContext context)
        {
            _context = context;
        }

        // GET: MEDICINEs
        public async Task<IActionResult> Index()
        {
              return _context.MEDICINE != null ? 
                          View(await _context.MEDICINE.ToListAsync()) :
                          Problem("Entity set 'ISHPlusTestContext.MEDICINE'  is null.");
        }

        // GET: MEDICINEs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MEDICINE == null)
            {
                return NotFound();
            }

            var mEDICINE = await _context.MEDICINE
                .FirstOrDefaultAsync(m => m.id == id);
            if (mEDICINE == null)
            {
                return NotFound();
            }

            return View(mEDICINE);
        }

        // GET: MEDICINEs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MEDICINEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,MED_NAME,PRICE,EXP_DATE")] MEDICINE mEDICINE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mEDICINE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mEDICINE);
        }

        // GET: MEDICINEs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MEDICINE == null)
            {
                return NotFound();
            }

            var mEDICINE = await _context.MEDICINE.FindAsync(id);
            if (mEDICINE == null)
            {
                return NotFound();
            }
            return View(mEDICINE);
        }

        // POST: MEDICINEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,MED_NAME,PRICE,EXP_DATE")] MEDICINE mEDICINE)
        {
            if (id != mEDICINE.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mEDICINE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MEDICINEExists(mEDICINE.id))
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
            return View(mEDICINE);
        }

        // GET: MEDICINEs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MEDICINE == null)
            {
                return NotFound();
            }

            var mEDICINE = await _context.MEDICINE
                .FirstOrDefaultAsync(m => m.id == id);
            if (mEDICINE == null)
            {
                return NotFound();
            }

            return View(mEDICINE);
        }

        // POST: MEDICINEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MEDICINE == null)
            {
                return Problem("Entity set 'ISHPlusTestContext.MEDICINE'  is null.");
            }
            var mEDICINE = await _context.MEDICINE.FindAsync(id);
            if (mEDICINE != null)
            {
                _context.MEDICINE.Remove(mEDICINE);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MEDICINEExists(int id)
        {
          return (_context.MEDICINE?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
