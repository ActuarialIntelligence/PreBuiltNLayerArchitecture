using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AML.Infrastructure.Data.EF;
using ISHPlusTest.Data;

namespace ISHPlusTest
{
    public class DOCTORsController : Controller
    {
        private readonly ISHPlusTestContext _context;

        public DOCTORsController(ISHPlusTestContext context)
        {
            _context = context;
        }

        // GET: DOCTORs
        public async Task<IActionResult> Index()
        {
              return _context.DOCTOR != null ? 
                          View(await _context.DOCTOR.ToListAsync()) :
                          Problem("Entity set 'ISHPlusTestContext.DOCTOR'  is null.");
        }

        // GET: DOCTORs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DOCTOR == null)
            {
                return NotFound();
            }

            var dOCTOR = await _context.DOCTOR
                .FirstOrDefaultAsync(m => m.id == id);
            if (dOCTOR == null)
            {
                return NotFound();
            }

            return View(dOCTOR);
        }

        // GET: DOCTORs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DOCTORs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,DNAME,GENDER,QUALIFICATION,JOB_SPECIFICATION,HOSP_NAME")] DOCTOR dOCTOR)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dOCTOR);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dOCTOR);
        }

        // GET: DOCTORs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DOCTOR == null)
            {
                return NotFound();
            }

            var dOCTOR = await _context.DOCTOR.FindAsync(id);
            if (dOCTOR == null)
            {
                return NotFound();
            }
            return View(dOCTOR);
        }

        // POST: DOCTORs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,DNAME,GENDER,QUALIFICATION,JOB_SPECIFICATION,HOSP_NAME")] DOCTOR dOCTOR)
        {
            if (id != dOCTOR.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dOCTOR);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DOCTORExists(dOCTOR.id))
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
            return View(dOCTOR);
        }

        // GET: DOCTORs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DOCTOR == null)
            {
                return NotFound();
            }

            var dOCTOR = await _context.DOCTOR
                .FirstOrDefaultAsync(m => m.id == id);
            if (dOCTOR == null)
            {
                return NotFound();
            }

            return View(dOCTOR);
        }

        // POST: DOCTORs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DOCTOR == null)
            {
                return Problem("Entity set 'ISHPlusTestContext.DOCTOR'  is null.");
            }
            var dOCTOR = await _context.DOCTOR.FindAsync(id);
            if (dOCTOR != null)
            {
                _context.DOCTOR.Remove(dOCTOR);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DOCTORExists(int id)
        {
          return (_context.DOCTOR?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
