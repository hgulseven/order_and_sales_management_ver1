﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using order_and_sales_management_ver1.Data;
using order_and_sales_management_ver1.Models;

namespace order_and_sales_management_ver1.Controllers
{
    public class packedproductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public packedproductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: packedproducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.packedProducts.ToListAsync());
        }

        // GET: packedproducts/Details/5
        public async Task<IActionResult> Details(int? packedId)
        {
            if (packedId== null)
            {
                return NotFound();
            }

            var packedproduct = await _context.packedProducts
                .FirstOrDefaultAsync(m => m.packedId == packedId);
            if (packedproduct == null)
            {
                return NotFound();
            }

            return View(packedproduct);
        }

        // GET: packedproducts/Create
        public IActionResult Create(int ?packedId)
        {
            
            packedproduct packedProduct = new packedproduct();
            if (packedId != null && packedId != 0)
            {
                packedProduct.packedProductDetails = new List<packedproductdetail>();
                packedProduct =  _context.packedProducts.Include(s=>s.packedProductDetails)
                                                .FirstOrDefault(m => m.packedId == packedId);
                if (packedProduct != null)
                {
                    foreach (packedproductdetail packedProductDetail in packedProduct.packedProductDetails)
                    {
                        packedProductDetail.baseProduct = _context.baseProducts.FirstOrDefault(s => s.baseId == packedProductDetail.baseId);
                    }
                    packedProduct.operation = "Update";
                } else
                {
                    packedProduct = new packedproduct();
                    packedProduct.packedProductDetails = new List<packedproductdetail>();
                    packedProduct.operation = "Add";
                }
            }
            else
            {
                packedProduct = new packedproduct();
                packedProduct.packedProductDetails = new List<packedproductdetail>();
                packedProduct.operation = "Add";
            }
            return View(packedProduct);
        }

        // POST: packedproducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("packedId,packedProductName,barcodeID,productRetailPrice,productWholesalePrice")] packedproduct packedproduct)
        {
            int initialProductID = 317;

            if (ModelState.IsValid)
            {
                packedproduct.packedProductDetails = new List<packedproductdetail>();
                var baseIds= HttpContext.Request.Form["item.baseProduct.baseId"].ToArray();
                var amounts = HttpContext.Request.Form["packedproductdetails.amount"].ToArray();
                var operation = HttpContext.Request.Form["operation"].ToString();
                packedproduct.productRetailPrice = decimal.Parse(HttpContext.Request.Form["productRetailPrice"].ToString().Replace('.', ','));
                packedproduct.productWholesalePrice = decimal.Parse(HttpContext.Request.Form["productWholesalePrice"].ToString().Replace('.', ','));
                if (packedproduct.barcodeID== null || packedproduct.barcodeID.Length != 13)
                {
                    barcodeController barcode = new barcodeController(_context);
                    packedproduct.barcodeID= barcode.getFirstAvailableBarcode(ref initialProductID);
                }
                for (int i=0; i<baseIds.Length;i++ )
                {
                    packedproductdetail item = new packedproductdetail();
                    item.baseId = int.Parse(baseIds[i]);
                    item.amount = decimal.Parse(amounts[i].Replace('.', ','));
                    item.contentLineNo = i + 1;
                    item.packedId = packedproduct.packedId;
                    packedproduct.packedProductDetails.Add(item);
                }
                if (operation == "Add")
                {
                    _context.Add(packedproduct);
                    _context.SaveChanges();
                    ProductModel product = new ProductModel();
                    product.productBarcodeID = packedproduct.barcodeID;
                    product.ProductName = packedproduct.packedProductName;
                    product.productRetailPrice = packedproduct.productRetailPrice;
                    product.productWholesalePrice = packedproduct.productWholesalePrice;
                    product.recStatus = 1;
                    _context.Add(product);
                    _context.SaveChanges();
                    CrossTable crossTable = new CrossTable();
                    crossTable.pname = packedproduct.packedProductName;
                    crossTable.baseID = 0;
                    crossTable.packedID = packedproduct.packedId;
                    crossTable.productID = product.productID;
                    _context.Add(crossTable);
                    _context.SaveChanges();
                } else
                {
                    _context.Update(packedproduct);
                    _context.SaveChanges();
                }
                return RedirectToAction("Create",new { packedId = packedproduct.packedId + 1 });
            }
            return View(packedproduct);
        }

        // GET: packedproducts/Delete/5
        public async Task<IActionResult> Delete(int? packedId)
        {
            if (packedId == null)
            {
                return NotFound();
            }

            var packedproduct = await _context.packedProducts
                .FirstOrDefaultAsync(m => m.packedId == packedId);
            if (packedproduct == null)
            {
                return NotFound();
            }

            return View(packedproduct);
        }

        // POST: packedproducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int packedId)
        {
            var packedproduct = await _context.packedProducts.FindAsync(packedId);
            _context.packedProducts.Remove(packedproduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool packedproductExists(int id)
        {
            return _context.packedProducts.Any(e => e.packedId == id);
        }

        public List<baseproduct> getProducts(string productName)
        {
        
            List<baseproduct> baseProduct = new List<baseproduct>();

            if (!String.IsNullOrEmpty(productName))
            {
                baseProduct = _context.baseProducts.Where(x => x.name.Contains(productName)).ToList();
            }
            else
            {
                baseProduct = new List<baseproduct>();
            }
            return baseProduct;
        }
    }
}
