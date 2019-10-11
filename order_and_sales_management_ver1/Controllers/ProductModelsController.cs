using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Order_And_Sales_Management_ver1.Models;
using Order_And_Sales_Management_ver1.Data;


namespace Order_And_Sales_Management_ver1.Controllers
{
    public class productmodelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public productmodelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: productmodels
        public async Task<IActionResult> Index()
        {
            return View(await _context.productmodels.Where(x => x.recStatus == Program.Const_Record_Active).ToListAsync());
        }

        // GET: productmodels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModel = await _context.productmodels
                .FirstOrDefaultAsync(m => m.productID == id && m.recStatus == Program.Const_Record_Active);
            if (productModel == null)
            {
                return NotFound();
            }

            return View(productModel);
        }

        // GET: productmodels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: productmodels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("productID,ProductName,productBarcodeID,productRetailPrice,productWholesalePrice")] ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                productModel.recStatus = Program.Const_Record_Active;
                _context.Add(productModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productModel);
        }

        // GET: productmodels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModel = await _context.productmodels.FindAsync(id);
            if (productModel == null)
            {
                return NotFound();
            }
            return View(productModel);
        }

        // POST: productmodels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("productID,ProductName,productBarcodeID,productRetailPrice,productWholesalePrice")] ProductModel productModel)
        {
            if (id != productModel.productID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    productModel.recStatus = Program.Const_Record_Active;
                    _context.Update(productModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductModelExists(productModel.productID))
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
            return View(productModel);
        }

        // GET: productmodels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModel = await _context.productmodels
                .FirstOrDefaultAsync(m => m.productID == id);
            if (productModel == null)
            {
                return NotFound();
            }

            return View(productModel);
        }

        // POST: productmodels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productModel = await _context.productmodels.FindAsync(id);
            productModel.recStatus = Program.Const_Record_Deleted;
            _context.productmodels.Update(productModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductModelExists(int id)
        {
            return _context.productmodels.Any(e => e.productID == id && e.recStatus== Program.Const_Record_Active);
        }
    }
}
