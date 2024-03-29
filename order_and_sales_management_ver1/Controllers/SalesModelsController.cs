﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using order_and_sales_management_ver1.Data;
using order_and_sales_management_ver1.Models;

namespace order_and_sales_management_ver1.Controllers
{
public class SalesModelsController : Controller
    {

    private readonly ApplicationDbContext _context;

        public SalesModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SalesModels
        public async Task<IActionResult> Index(int salesID)
        {
            List<SalesModel> saleList = new List<SalesModel>();
            int location = int.Parse(HttpContext.User.Claims.Where(c => c.Type == "location").FirstOrDefault().Value.ToString());
            if (salesID != null  && salesID != 0)
            {
                saleList = _context.salesmodels.Where(x => x.salesID == salesID && x.saleDate == DateTime.Today && x.locationID == location).ToList();
                int i = 2;
                foreach (SalesModel sale_item in saleList)
                {
                    sale_item.Products = _context.Products.Where(x => x.productBarcodeID == sale_item.productBarcodeID).FirstOrDefault();
                    sale_item.employeesmodels = _context.employeesmodels.Where(x => x.personelID == sale_item.personelID).FirstOrDefault();
                    sale_item.personelNameSurname = sale_item.employeesmodels.persName + " " + sale_item.employeesmodels.persSurName;
                    sale_item.tutar = (decimal)(sale_item.amount * sale_item.Products.productRetailPrice);
                    sale_item.wholesaleamount = (decimal)(sale_item.amount * sale_item.Products.productWholesalePrice);
                    sale_item.salesLineId = i;
                    i = i + 1;
                }
                SalesModel saleItem = new SalesModel();
                saleItem.salesID = salesID;
                saleItem.salesLineId = 1;
                saleList.Insert(0, saleItem);

            }
            else
            {
                saleList = new List<SalesModel>();
                var sale_item = new SalesModel();
                salescounter salesCounter = _context.salescounter.Find(DateTime.Today, location);
                if (salesCounter == null)
                {
                    salesCounter = new salescounter();
                    salesCounter.counter = 1;
                    salesCounter.locationID = location;
                    salesCounter.salesDate = DateTime.Today;
                    _context.salescounter.Add(salesCounter);

                }
                else
                {
                    salesCounter.counter = salesCounter.counter + 1;
                    _context.salescounter.Update(salesCounter);
                }
                _context.SaveChanges();
                sale_item.salesID = salesCounter.counter;
                sale_item.salesLineId = 1;
                saleList.Add(sale_item);
            }
            return View(saleList);
        }

        public  void UpdateSales(string listOfProducts)
        {


            List<saleItem> newSales = new List<saleItem>();
            SalesModel salesModel = new SalesModel();
            newSales = Newtonsoft.Json.JsonConvert.DeserializeObject <List<saleItem>> (listOfProducts);
            int location = int.Parse(HttpContext.User.Claims.Where(c => c.Type == "location").FirstOrDefault().Value.ToString());
            int salesLineId = 1;
            while ((salesModel = _context.salesmodels.Find(DateTime.Today, newSales[0].salesID,salesLineId,location)) != null)
            {
                _context.salesmodels.Remove(salesModel);
                salesLineId = salesLineId+1;
            }
            _context.SaveChanges();
            salesModel = new SalesModel();
            int i = 1;
            float paidAmount = 0;
            foreach (saleItem item in newSales)
            {
                paidAmount = paidAmount + item.tutar;
            }
            foreach (saleItem item in newSales)
            {
                salesModel.amount = item.amount;
                salesModel.productBarcodeID = item.productBarcodeID;
                salesModel.locationID = location;
                salesModel.personelID = item.personelID;
                salesModel.saleDate = DateTime.Today;
                salesModel.salesID = item.salesID;
                salesModel.dueAmount = item.tutar;
                salesModel.salesLineId = i;
                salesModel.typeOfCollection = 0;
                salesModel.saleTime = DateTime.Now;
                salesModel.paidAmount = paidAmount;
                salesModel.wholesaleamount = item.wholesaleamount;

                _context.salesmodels.Add(salesModel);
                _context.SaveChanges();
                i = i + 1;
            }
        }
        public SalesModel getProductByBarcode(string barcodeID, string salesID)
        {
            SalesModel sale_item= new SalesModel();
            sale_item.salesID = -1;
            int personelID= int.Parse(HttpContext.User.Claims.Where(c => c.Type == "personelID").FirstOrDefault().Value.ToString());
            sale_item.employeesmodels = _context.employeesmodels.Where(c => c.personelID == personelID).FirstOrDefault();
            products productsView = _context.Products.Where(x => x.productBarcodeID == barcodeID).FirstOrDefault();
            if (productsView != null)
            {
                sale_item.salesID = int.Parse(salesID);
                sale_item.personelID = sale_item.employeesmodels.personelID;
                sale_item.productBarcodeID = barcodeID;
                sale_item.personelNameSurname = sale_item.employeesmodels.persName+" "+ sale_item.employeesmodels.persSurName;
                sale_item.amount = 1;
                sale_item.tutar = (decimal)(sale_item.amount * productsView.productRetailPrice);
                sale_item.dueAmount = sale_item.amount * productsView.productRetailPrice;
                sale_item.Products= new products();
                sale_item.Products.productName = productsView.productName;
                sale_item.wholesaleamount = (decimal)(sale_item.amount * productsView.productWholesalePrice);
            }
            return sale_item;
        }
        // GET: SalesModels/Details/5
        public async Task<IActionResult> Details(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesModel = await _context.salesmodels
                .FirstOrDefaultAsync(m => m.saleDate == id);
            if (salesModel == null)
            {
                return NotFound();
            }

            return View(salesModel);
        }

        // GET: SalesModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("saleDate,saleTime,salesID,salesLineId,personelID,amount,paidAmount,typeOfCollection,locationID,productBarcodeID")] SalesModel salesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesModel);
        }

        // GET: SalesModels/Edit/5
        public async Task<IActionResult> Edit(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesModel = await _context.salesmodels.FindAsync(id);
            if (salesModel == null)
            {
                return NotFound();
            }
            return View(salesModel);
        }

        // POST: SalesModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DateTime id, [Bind("saleDate,saleTime,salesID,salesLineId,personelID,amount,paidAmount,typeOfCollection,locationID,productBarcodeID")] SalesModel salesModel)
        {
            if (id != salesModel.saleDate)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesModelExists(salesModel.saleDate))
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
            return View(salesModel);
        }

        // GET: SalesModels/Delete/5
        public async Task<IActionResult> Delete(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesModel = await _context.salesmodels
                .FirstOrDefaultAsync(m => m.saleDate == id);
            if (salesModel == null)
            {
                return NotFound();
            }

            return View(salesModel);
        }

        // POST: SalesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(DateTime id)
        {
            var salesModel = await _context.salesmodels.FindAsync(id);
            _context.salesmodels.Remove(salesModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesModelExists(DateTime id)
        {
            return _context.salesmodels.Any(e => e.saleDate == id);
        }
    }
}
