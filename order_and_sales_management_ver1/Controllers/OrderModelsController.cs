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
    public class OrderModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrderModels
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.OrderModel.Include(s => s.orderOwnerEmployeeModel).Include(b => b.orderdetailsmodels).Include(k=>k.orderLocation);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: OrderModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderModel = await _context.OrderModel
                .FirstOrDefaultAsync(m => m.orderID == id);
            if (orderModel == null)
            {
                return NotFound();
            }

            return View(orderModel);
        }

        // GET: OrderModels/Create
        public IActionResult Create()
        {
            OrderModel orderModel = new OrderModel();
            orderModel.orderdetailsmodels = new List<OrderDetailsModel>();
            orderModel.orderDate = DateTime.Now;
            ViewData["personelID"] = new SelectList(_context.employeesmodels, nameof(EmployeesModels.personelID), nameof(EmployeesModels.persName));
            ViewData["locationID"] = new SelectList(_context.stocklocationmodel, nameof(stocklocationmodel.locationID), nameof(stocklocationmodel.locationName));
            return View(orderModel);
        }

        // POST: OrderModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("orderID,orderDate,recStatus,orderOwner_personelID")] OrderModel orderModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderModel);
        }

        // GET: OrderModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderModel = await _context.OrderModel.FindAsync(id);
            if (orderModel == null)
            {
                return NotFound();
            }
            return View(orderModel);
        }

        // POST: OrderModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("orderID,orderDate,recStatus,orderOwner_personelID")] OrderModel orderModel)
        {
            if (id != orderModel.orderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderModelExists(orderModel.orderID))
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
            return View(orderModel);
        }

        // GET: OrderModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderModel = await _context.OrderModel
                .FirstOrDefaultAsync(m => m.orderID == id);
            if (orderModel == null)
            {
                return NotFound();
            }

            return View(orderModel);
        }

        // POST: OrderModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderModel = await _context.OrderModel.FindAsync(id);
            _context.OrderModel.Remove(orderModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderModelExists(int id)
        {
            return _context.OrderModel.Any(e => e.orderID == id);
        }
    }
}
