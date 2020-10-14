using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using order_and_sales_management_ver1.Data;
using order_and_sales_management_ver1.Models;
using Spire.Barcode;

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
                uretimGiris.products = _context.productmodels.Where(x => x.ProductName.Contains(productName)).ToList();
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
                stockItem.locationID = Program.Const_Production_Location;
                stockItem.recStatus = Program.Const_Record_Active;
                stockItem.stockAmount = uretimGiris.stockAmount;
                BarcodeSettings barcodeSettings = new BarcodeSettings();
                barcodeSettings.Data = "01"+uretimGiris.productionLotID.Replace("-", string.Empty) + (uretimGiris.stockAmount * 1000).ToString();
                barcodeSettings.AutoResize = true;
                barcodeSettings.ShowText = true;
                barcodeSettings.Type = BarCodeType.EAN128;
                BarCodeGenerator barcode = new BarCodeGenerator(barcodeSettings);
                Image lotIDBarcode = barcode.GenerateImage();
                barcodeSettings.Data = "027622100989189";
                barcodeSettings.AutoResize = true;
                barcodeSettings.ShowText = true;
                barcodeSettings.Type = BarCodeType.EAN128;
                barcode = new BarCodeGenerator(barcodeSettings);
                Image productBarcode = barcode.GenerateImage();
                var target = new Bitmap(lotIDBarcode, lotIDBarcode.Width, lotIDBarcode.Height);
                var graphics = Graphics.FromImage(target);
                graphics.CompositingMode = CompositingMode.SourceOver; // this is the default, but just to be clear

                graphics.DrawImage(lotIDBarcode, 0, 0);
                graphics.DrawImage(productBarcode, 200, lotIDBarcode.Height+10);
                target.Save("filename.png", ImageFormat.Png);


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
            int locID = Program.Const_Production_Location;
            return _context.stockitems.Any(e => e.productID == prodID && e.locationID == locID && e.productionLotID == lotID);
        }

    }
}