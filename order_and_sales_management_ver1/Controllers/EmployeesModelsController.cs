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
    public class EmployeesModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public  EmployeesModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: employeesmodels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.employeesmodels.Include(e => e.empLocation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: employeesmodels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeesmodels = await _context.employeesmodels
                .Include(e => e.empLocation)
                .FirstOrDefaultAsync(m => m.personelID == id);
            if (employeesmodels == null)
            {
                return NotFound();
            }

            return View(employeesmodels);
        }

        // GET: employeesmodels/Create
        public IActionResult Create()
        {
            ViewData["locationID"] = new SelectList(_context.stocklocationmodel, nameof(stocklocationmodel.locationID), nameof(stocklocationmodel.locationName));
            return View();
        }

        // POST: employeesmodels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("personelID,persName,persSurName,password,locationID,userName,connectionId,userRole,userActive,accessFailedCount,recStatus")] EmployeesModels employeesmodels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeesmodels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["locationID"] = new SelectList(_context.stocklocationmodel, nameof(stocklocationmodel.locationID), nameof(stocklocationmodel.locationName));
            return View(employeesmodels);
        }

        // GET: employeesmodels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeesmodels = await _context.employeesmodels.FindAsync(id);
            if (employeesmodels == null)
            {
                return NotFound();
            }
            ViewData["locationID"] = new SelectList(_context.stocklocationmodel, nameof(stocklocationmodel.locationID), nameof(stocklocationmodel.locationName));
            return View(employeesmodels);
        }

        // POST: employeesmodels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("personelID,persName,persSurName,password,locationID,userName,connectionId,userRole,userActive,accessFailedCount,recStatus")] EmployeesModels employeesmodels)
        {
            if (id != employeesmodels.personelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeesmodels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!employeesmodelsExists(employeesmodels.personelID))
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
            ViewData["locationID"] = new SelectList(_context.stocklocationmodel, nameof(stocklocationmodel.locationID), nameof(stocklocationmodel.locationName));
            return View(employeesmodels);
        }

        // GET: employeesmodels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeesmodels = await _context.employeesmodels
                .Include(e => e.empLocation)
                .FirstOrDefaultAsync(m => m.personelID == id);
            if (employeesmodels == null)
            {
                return NotFound();
            }

            return View(employeesmodels);
        }

        // POST: employeesmodels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeesmodels = await _context.employeesmodels.FindAsync(id);
            _context.employeesmodels.Remove(employeesmodels);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool employeesmodelsExists(int id)
        {
            return _context.employeesmodels.Any(e => e.personelID == id);
        }
    }
}
