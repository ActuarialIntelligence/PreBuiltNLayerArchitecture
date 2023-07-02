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
    public class PATIENTsController : Controller
    {
        private readonly ISHPlusTestContext _context;

        public PATIENTsController(ISHPlusTestContext context)
        {
            _context = context;
        }

        // GET: PATIENTs
        public async Task<IActionResult> Index()
        {
              return _context.PATIENT != null ? 
                          View(await _context.PATIENT.ToListAsync()) :
                          Problem("Entity set 'ISHPlusTestContext.PATIENT'  is null.");
        }

        // GET: PATIENTs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PATIENT == null)
            {
                return NotFound();
            }

            var pATIENT = await _context.PATIENT
                .FirstOrDefaultAsync(m => m.id == id);
            if (pATIENT == null)
            {
                return NotFound();
            }

            return View(pATIENT);
        }

        // GET: PATIENTs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PATIENTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,FNAME,LNAME,AGE,GENDER,NURSE_ID,REC_ID")] PATIENT pATIENT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pATIENT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pATIENT);
        }

        // GET: PATIENTs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PATIENT == null)
            {
                return NotFound();
            }

            var pATIENT = await _context.PATIENT.FindAsync(id);
            if (pATIENT == null)
            {
                return NotFound();
            }
            return View(pATIENT);
        }

        // POST: PATIENTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,FNAME,LNAME,AGE,GENDER,NURSE_ID,REC_ID")] PATIENT pATIENT)
        {
            if (id != pATIENT.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pATIENT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PATIENTExists(pATIENT.id))
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
            return View(pATIENT);
        }

        // GET: PATIENTs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PATIENT == null)
            {
                return NotFound();
            }

            var pATIENT = await _context.PATIENT
                .FirstOrDefaultAsync(m => m.id == id);
            if (pATIENT == null)
            {
                return NotFound();
            }

            return View(pATIENT);
        }

        // POST: PATIENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PATIENT == null)
            {
                return Problem("Entity set 'ISHPlusTestContext.PATIENT'  is null.");
            }
            var pATIENT = await _context.PATIENT.FindAsync(id);
            if (pATIENT != null)
            {
                _context.PATIENT.Remove(pATIENT);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PATIENTExists(int id)
        {
          return (_context.PATIENT?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
