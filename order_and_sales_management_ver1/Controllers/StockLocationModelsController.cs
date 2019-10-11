using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Order_And_Sales_Management_ver1.Models;
using Order_And_Sales_Management_ver1.Data;

namespace Order_And_Sales_Management_ver1.Controllers
{
    public class stocklocationmodelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public stocklocationmodelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: stocklocationmodels
        public async Task<IActionResult> Index()
        {
            return View(await _context.stocklocationmodel.ToListAsync());
        }

        // GET: stocklocationmodels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stocklocationmodel = await _context.stocklocationmodel
                .FirstOrDefaultAsync(m => m.locationID == id);
            if (stocklocationmodel == null)
            {
                return NotFound();
            }

            return View(stocklocationmodel);
        }

        // GET: stocklocationmodels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: stocklocationmodels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("locationID,locationName")] stocklocationmodel stocklocationmodel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stocklocationmodel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stocklocationmodel);
        }

        // GET: stocklocationmodels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stocklocationmodel = await _context.stocklocationmodel.FindAsync(id);
            if (stocklocationmodel == null)
            {
                return NotFound();
            }
            return View(stocklocationmodel);
        }

        // POST: stocklocationmodels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("locationID,locationName")] stocklocationmodel stocklocationmodel)
        {
            if (id != stocklocationmodel.locationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stocklocationmodel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!stocklocationmodelExists(stocklocationmodel.locationID))
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
            return View(stocklocationmodel);
        }

        // GET: stocklocationmodels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stocklocationmodel = await _context.stocklocationmodel
                .FirstOrDefaultAsync(m => m.locationID == id);
            if (stocklocationmodel == null)
            {
                return NotFound();
            }

            return View(stocklocationmodel);
        }

        // POST: stocklocationmodels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stocklocationmodel = await _context.stocklocationmodel.FindAsync(id);
            _context.stocklocationmodel.Remove(stocklocationmodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool stocklocationmodelExists(int id)
        {
            return _context.stocklocationmodel.Any(e => e.locationID == id);
        }
    }
}
