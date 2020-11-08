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
    public class baseproductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public baseproductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: baseproducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.baseProducts.ToListAsync());
        }

        // GET: baseproducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseproduct = await _context.baseProducts
                .FirstOrDefaultAsync(m => m.baseId == id);
            if (baseproduct == null)
            {
                return NotFound();
            }

            return View(baseproduct);
        }

        // GET: baseproducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: baseproducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("baseId,retailPrice,wholeSalePrice,name,sellersID,detailsId")] baseproduct baseproduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baseproduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baseproduct);
        }

        // GET: baseproducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseproduct = await _context.baseProducts.FindAsync(id);
            if (baseproduct == null)
            {
                return NotFound();
            }
            return View(baseproduct);
        }

        // POST: baseproducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("baseId,retailPrice,wholeSalePrice,name,sellersID,detailsId")] baseproduct baseproduct)
        {
            if (id != baseproduct.baseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baseproduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!baseproductExists(baseproduct.baseId))
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
            return View(baseproduct);
        }

        // GET: baseproducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseproduct = await _context.baseProducts
                .FirstOrDefaultAsync(m => m.baseId == id);
            if (baseproduct == null)
            {
                return NotFound();
            }

            return View(baseproduct);
        }

        // POST: baseproducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var baseproduct = await _context.baseProducts.FindAsync(id);
            _context.baseProducts.Remove(baseproduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool baseproductExists(int id)
        {
            return _context.baseProducts.Any(e => e.baseId == id);
        }
    }
}
