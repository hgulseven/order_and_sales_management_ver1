using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using order_and_sales_management_ver1.Models;
using order_and_sales_management_ver1.Data;

namespace order_and_sales_management_ver1.Controllers
{
    public class stockitemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public stockitemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: stockitems
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.stockitems.Include(s => s.stocklocationmodel).Include(s => s.product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: stockitems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockItem = await _context.stockitems
                .Include(s => s.stocklocationmodel)
                .Include(s => s.product)
                .FirstOrDefaultAsync(m => m.productID == id);
            if (stockItem == null)
            {
                return NotFound();
            }

            return View(stockItem);
        }

        // GET: stockitems/Create
        public IActionResult Create()
        {
            ViewData["locationName"] = new SelectList(_context.stocklocationmodel, nameof(stocklocationmodel.locationID),nameof(stocklocationmodel.locationName));
            ViewData["productName"] = new SelectList(_context.productmodels, nameof(ProductModel.productID), nameof(ProductModel.ProductName));
            return View();
        }

        // POST: stockitems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("productID,locationID,productionLotID,stockAmount,recStatus")] StockItem stockItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stockItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["locationName"] = new SelectList(_context.stocklocationmodel, nameof(stocklocationmodel.locationID), nameof(stocklocationmodel.locationName));
            ViewData["productName"] = new SelectList(_context.productmodels, nameof(ProductModel.productID), nameof(ProductModel.ProductName));
            return View(stockItem);
        }

        // GET: stockitems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockItem = await _context.stockitems.FindAsync(id);
            if (stockItem == null)
            {
                return NotFound();
            }
            ViewData["locationID"] = new SelectList(_context.stocklocationmodel, "locationID", "locationID", stockItem.locationID);
            ViewData["productID"] = new SelectList(_context.productmodels, "productID", "productID", stockItem.productID);
            return View(stockItem);
        }

        // POST: stockitems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("productID,locationID,productionLotID,stockAmount,recStatus")] StockItem stockItem)
        {
            if (id != stockItem.productID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockItemExists(stockItem.productID))
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
            ViewData["locationID"] = new SelectList(_context.stocklocationmodel, "locationID", "locationID", stockItem.locationID);
            ViewData["productID"] = new SelectList(_context.productmodels, "productID", "productID", stockItem.productID);
            return View(stockItem);
        }

        // GET: stockitems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockItem = await _context.stockitems
                .Include(s => s.stocklocationmodel)
                .Include(s => s.product)
                .FirstOrDefaultAsync(m => m.productID == id);
            if (stockItem == null)
            {
                return NotFound();
            }

            return View(stockItem);
        }

        // POST: stockitems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stockItem = await _context.stockitems.FindAsync(id);
            _context.stockitems.Remove(stockItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockItemExists(int id)
        {
            return _context.stockitems.Any(e => e.productID == id);
        }
    }
}
