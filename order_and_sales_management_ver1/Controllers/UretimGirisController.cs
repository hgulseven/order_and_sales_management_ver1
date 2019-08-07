using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using order_and_sales_management_ver1.Data;
using Order_And_Sales_Management_ver1.Models;

namespace order_and_sales_management_ver1.Controllers
{
    public class UretimGirisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UretimGirisController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult Giris(string productName)
        {
            UretimGiris uretimGiris=new UretimGiris();
            if (!String.IsNullOrEmpty(productName))
            {
                uretimGiris.products = _context.ProductModels.Where(x => x.ProductName.Contains(productName)).ToList();
            }
            else
            {
                uretimGiris.products = new List<ProductModel>();

            }
            return View(uretimGiris);
        }
        [HttpPost]
        public ActionResult Giris([Bind("productID,ProductName,productionLotID,stockAmount")] UretimGiris uretimGiris,string action)
        {
            StockItem stockItem;

            if (ModelState.IsValid)
            {
                stockItem = new StockItem();
                stockItem.productID = uretimGiris.productID;
                stockItem.productionLotID = uretimGiris.productionLotID;
                stockItem.locationID = 4;
                stockItem.recStatus = true;
                stockItem.stockAmount = uretimGiris.stockAmount;
                if (action == "update")
                {
                   try
                    {
                        _context.Update(stockItem);
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("NoRecordToUpdate", ex.ToString());
                        uretimGiris.products = new List<ProductModel>();
                        return View(uretimGiris);
                    }
                } else if (action == "newEntry") {
                    _context.Add(stockItem);
                    try
                    {
                        _context.SaveChanges();
                    }
                    catch(Exception e)
                    {
                            ModelState.AddModelError("DuplikeKayit", e.ToString());
                            uretimGiris.products = new List<ProductModel>();
                            return View(uretimGiris);
                    }
                } 
            }
            return RedirectToAction(nameof(Giris),new { productName = "" });
        }

        public bool StockItemExists(int prodID,  string lotID)
        {
            int locID = 4;
            return _context.StockItems.Any(e => e.productID == prodID && e.locationID == locID && e.productionLotID == lotID);
        }

    }
}