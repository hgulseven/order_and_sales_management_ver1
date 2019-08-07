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
    public class EmployeesModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeesModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EmployeesModel.Include(e => e.empLocation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EmployeesModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeesModel = await _context.EmployeesModel
                .Include(e => e.empLocation)
                .FirstOrDefaultAsync(m => m.personelID == id);
            if (employeesModel == null)
            {
                return NotFound();
            }

            return View(employeesModel);
        }

        // GET: EmployeesModels/Create
        public IActionResult Create()
        {
            ViewData["locationID"] = new SelectList(_context.StockLocationModel, nameof(StockLocationModel.locationID), nameof(StockLocationModel.locationName));
            return View();
        }

        // POST: EmployeesModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("personelID,persName,persSurName,password,locationID,userName,connectionId,userRole,userActive,accessFailedCount,recStatus")] EmployeesModel employeesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["locationID"] = new SelectList(_context.StockLocationModel, nameof(StockLocationModel.locationID), nameof(StockLocationModel.locationName));
            return View(employeesModel);
        }

        // GET: EmployeesModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeesModel = await _context.EmployeesModel.FindAsync(id);
            if (employeesModel == null)
            {
                return NotFound();
            }
            ViewData["locationID"] = new SelectList(_context.StockLocationModel, nameof(StockLocationModel.locationID), nameof(StockLocationModel.locationName));
            return View(employeesModel);
        }

        // POST: EmployeesModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("personelID,persName,persSurName,password,locationID,userName,connectionId,userRole,userActive,accessFailedCount,recStatus")] EmployeesModel employeesModel)
        {
            if (id != employeesModel.personelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeesModelExists(employeesModel.personelID))
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
            return View(employeesModel);
        }

        // GET: EmployeesModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeesModel = await _context.EmployeesModel
                .Include(e => e.empLocation)
                .FirstOrDefaultAsync(m => m.personelID == id);
            if (employeesModel == null)
            {
                return NotFound();
            }

            return View(employeesModel);
        }

        // POST: EmployeesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeesModel = await _context.EmployeesModel.FindAsync(id);
            _context.EmployeesModel.Remove(employeesModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeesModelExists(int id)
        {
            return _context.EmployeesModel.Any(e => e.personelID == id);
        }
    }
}
