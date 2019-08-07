using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Order_And_Sales_Management_ver1.Models;
using order_and_sales_management_ver1.Data;

namespace order_and_sales_management_ver1.Controllers
{
    public class StockLocationModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StockLocationModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StockLocationModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.StockLocationModel.ToListAsync());
        }

        // GET: StockLocationModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockLocationModel = await _context.StockLocationModel
                .FirstOrDefaultAsync(m => m.locationID == id);
            if (stockLocationModel == null)
            {
                return NotFound();
            }

            return View(stockLocationModel);
        }

        // GET: StockLocationModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StockLocationModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("locationID,locationName")] StockLocationModel stockLocationModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stockLocationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stockLocationModel);
        }

        // GET: StockLocationModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockLocationModel = await _context.StockLocationModel.FindAsync(id);
            if (stockLocationModel == null)
            {
                return NotFound();
            }
            return View(stockLocationModel);
        }

        // POST: StockLocationModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("locationID,locationName")] StockLocationModel stockLocationModel)
        {
            if (id != stockLocationModel.locationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockLocationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockLocationModelExists(stockLocationModel.locationID))
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
            return View(stockLocationModel);
        }

        // GET: StockLocationModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockLocationModel = await _context.StockLocationModel
                .FirstOrDefaultAsync(m => m.locationID == id);
            if (stockLocationModel == null)
            {
                return NotFound();
            }

            return View(stockLocationModel);
        }

        // POST: StockLocationModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stockLocationModel = await _context.StockLocationModel.FindAsync(id);
            _context.StockLocationModel.Remove(stockLocationModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockLocationModelExists(int id)
        {
            return _context.StockLocationModel.Any(e => e.locationID == id);
        }
    }
}
