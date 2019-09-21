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
    public class EmployeesModelssController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesModelssController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeesModelss
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EmployeesModels.Include(e => e.empLocation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EmployeesModelss/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var EmployeesModels = await _context.EmployeesModels
                .Include(e => e.empLocation)
                .FirstOrDefaultAsync(m => m.personelID == id);
            if (EmployeesModels == null)
            {
                return NotFound();
            }

            return View(EmployeesModels);
        }

        // GET: EmployeesModelss/Create
        public IActionResult Create()
        {
            ViewData["locationID"] = new SelectList(_context.StockLocationModel, nameof(StockLocationModel.locationID), nameof(StockLocationModel.locationName));
            return View();
        }

        // POST: EmployeesModelss/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("personelID,persName,persSurName,password,locationID,userName,connectionId,userRole,userActive,accessFailedCount,recStatus")] EmployeesModels EmployeesModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(EmployeesModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["locationID"] = new SelectList(_context.StockLocationModel, nameof(StockLocationModel.locationID), nameof(StockLocationModel.locationName));
            return View(EmployeesModels);
        }

        // GET: EmployeesModelss/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var EmployeesModels = await _context.EmployeesModels.FindAsync(id);
            if (EmployeesModels == null)
            {
                return NotFound();
            }
            ViewData["locationID"] = new SelectList(_context.StockLocationModel, nameof(StockLocationModel.locationID), nameof(StockLocationModel.locationName));
            return View(EmployeesModels);
        }

        // POST: EmployeesModelss/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("personelID,persName,persSurName,password,locationID,userName,connectionId,userRole,userActive,accessFailedCount,recStatus")] EmployeesModels EmployeesModels)
        {
            if (id != EmployeesModels.personelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(EmployeesModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeesModelsExists(EmployeesModels.personelID))
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
            ViewData["locationID"] = new SelectList(_context.StockLocationModel, nameof(StockLocationModel.locationID), nameof(StockLocationModel.locationName));
            return View(EmployeesModels);
        }

        // GET: EmployeesModelss/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var EmployeesModels = await _context.EmployeesModels
                .Include(e => e.empLocation)
                .FirstOrDefaultAsync(m => m.personelID == id);
            if (EmployeesModels == null)
            {
                return NotFound();
            }

            return View(EmployeesModels);
        }

        // POST: EmployeesModelss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var EmployeesModels = await _context.EmployeesModels.FindAsync(id);
            _context.EmployeesModels.Remove(EmployeesModels);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeesModelsExists(int id)
        {
            return _context.EmployeesModels.Any(e => e.personelID == id);
        }
    }
}
