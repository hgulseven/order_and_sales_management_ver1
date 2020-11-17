using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using order_and_sales_management_ver1.Data;
using order_and_sales_management_ver1.Models;

namespace order_and_sales_management_ver1.Controllers
{
    public class packedproductdetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public packedproductdetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: packedproductdetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.packedProductDetails.Include(p => p.baseProduct).Include(p => p.packedProduct);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: packedproductdetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packedproductdetail = await _context.packedProductDetails
                .Include(p => p.baseProduct)
                .Include(p => p.packedProduct)
                .FirstOrDefaultAsync(m => m.packedId == id);
            if (packedproductdetail == null)
            {
                return NotFound();
            }

            return View(packedproductdetail);
        }

        // GET: packedproductdetails/Create
        public IActionResult Create()
        {
            ViewData["baseId"] = new SelectList(_context.baseProducts, "baseId", "baseId");
            ViewData["packedId"] = new SelectList(_context.packedProducts, "packedId", "packedId");
            return View();
        }

        // POST: packedproductdetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("packedId,contentLineNo,barcodProductId,baseId,amount")] packedproductdetail packedproductdetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(packedproductdetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            ViewData["baseId"] = new SelectList(_context.baseProducts, "baseId", "baseId", packedproductdetail.baseId);
            ViewData["packedId"] = new SelectList(_context.packedProducts, "packedId", "packedId", packedproductdetail.packedId);
            return View(packedproductdetail);
        }

        // GET: packedproductdetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packedproductdetail = await _context.packedProductDetails.FindAsync(id);
            if (packedproductdetail == null)
            {
                return NotFound();
            }
            ViewData["baseId"] = new SelectList(_context.baseProducts, "baseId", "baseId", packedproductdetail.baseId);
            ViewData["packedId"] = new SelectList(_context.packedProducts, "packedId", "packedId", packedproductdetail.packedId);
            return View(packedproductdetail);
        }

        // POST: packedproductdetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("packedId,contentLineNo,barcodProductId,baseId,amount")] packedproductdetail packedproductdetail)
        {
            if (id != packedproductdetail.packedId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(packedproductdetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!packedproductdetailExists(packedproductdetail.packedId))
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
            ViewData["baseId"] = new SelectList(_context.baseProducts, "baseId", "baseId", packedproductdetail.baseId);
            ViewData["packedId"] = new SelectList(_context.packedProducts, "packedId", "packedId", packedproductdetail.packedId);
            return View(packedproductdetail);
        }

        // GET: packedproductdetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packedproductdetail = await _context.packedProductDetails
                .Include(p => p.baseProduct)
                .Include(p => p.packedProduct)
                .FirstOrDefaultAsync(m => m.packedId == id);
            if (packedproductdetail == null)
            {
                return NotFound();
            }

            return View(packedproductdetail);
        }

        // POST: packedproductdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var packedproductdetail = await _context.packedProductDetails.FindAsync(id);
            _context.packedProductDetails.Remove(packedproductdetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool packedproductdetailExists(int id)
        {
            return _context.packedProductDetails.Any(e => e.packedId == id);
        }
    }
}
