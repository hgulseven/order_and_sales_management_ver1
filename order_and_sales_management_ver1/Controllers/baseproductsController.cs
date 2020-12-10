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
            int initialProductID = 317;
            baseproduct baseProduct= new baseproduct();
            barcodeController barcode = new barcodeController(_context);
            baseProduct.barcodeID= barcode.getFirstAvailableBarcode(ref initialProductID);
            return View(baseProduct);
        }

        // POST: baseproducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("baseId,retailPrice,wholeSalePrice,barcodeID, name,sellersID,detailsId")] baseproduct baseproduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baseproduct);
                _context.SaveChanges();
                ProductModel product = new ProductModel();
                product.ProductName = baseproduct.name;
                product.productRetailPrice = baseproduct.retailPrice;
                product.productWholesalePrice = baseproduct.wholeSalePrice;
                product.productBarcodeID = baseproduct.barcodeID;
                product.recStatus = 1;
                _context.Add(product);
                _context.SaveChanges();
                CrossTable crossTable = new CrossTable();
                crossTable.baseID = baseproduct.baseId;
                crossTable.productID = product.productID;
                crossTable.pname = baseproduct.name;
                crossTable.packedID = 0;
                _context.Add(crossTable);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(baseproduct);
        }

        // GET: baseproducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            int initialProductID = 317;

            if (id == null)
            {
                return NotFound();
            }

            var baseproduct = await _context.baseProducts.FindAsync(id);
            if (baseproduct == null)
            {
                return NotFound();
            }
            if (baseproduct.barcodeID == null || baseproduct.barcodeID.Length != 13)
            {
                barcodeController barcode = new barcodeController(_context);
                baseproduct.barcodeID = barcode.getFirstAvailableBarcode(ref initialProductID);
            }

            return View(baseproduct);
        }

        // POST: baseproducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("baseId,retailPrice,barcodeID, wholeSalePrice,name,sellersID,detailsId")] baseproduct baseproduct)
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

        public List<baseproduct>CheckandUpdateBarcodes_baseproducts()
        {
            List<baseproduct> baseproduct = new List<baseproduct>();
            List<baseproduct> bprodWithWrongBarcode = new List<baseproduct>();
            int initialProductID = 306;
            barcodeController barcode=new barcodeController(_context);
            baseproduct=_context.baseProducts.ToList<baseproduct>();
            foreach (baseproduct bprod in baseproduct)
            {
                if ( bprod.barcodeID != null && bprod.barcodeID.Length == 13 )
                {
                    string checkDigit = barcode.calcCheckDigit(bprod.barcodeID.Substring(0, 12));
                    if (checkDigit != bprod.barcodeID.Substring(12, 1))
                    {
                        bprodWithWrongBarcode.Add(bprod);
                    }
                } else
                {
                        bprod.barcodeID = barcode.getFirstAvailableBarcode(ref initialProductID);

                      _context.baseProducts.Update(bprod);
                      _context.SaveChanges();
                }
            }
            return bprodWithWrongBarcode;
        }

        public List<packedproduct> CheckandUpdateBarcodes_packedproducts()
        {
            List<packedproduct> packedproduct = new List<packedproduct>();
            List<packedproduct> packedProductWithWrongBarcode = new List<packedproduct>();
            int initialProductID = 139;
            barcodeController barcode = new barcodeController(_context);
            packedproduct = _context.packedProducts.ToList<packedproduct>();
            foreach (packedproduct pprod in packedproduct)
            {
                if (pprod.packedProductBarcodeID!= null && pprod.packedProductBarcodeID.Length == 13)
                {
                    string checkDigit = barcode.calcCheckDigit(pprod.packedProductBarcodeID.Substring(0, 12));
                    if (checkDigit != pprod.packedProductBarcodeID.Substring(12, 1))
                    {
                        packedProductWithWrongBarcode.Add(pprod);
                    }
                }
                else
                {
                        pprod.packedProductBarcodeID= barcode.getFirstAvailableBarcode(ref initialProductID);
                        _context.packedProducts.Update(pprod);
                        _context.SaveChanges();
                }
            }
            return packedProductWithWrongBarcode;
        }
    }
}
