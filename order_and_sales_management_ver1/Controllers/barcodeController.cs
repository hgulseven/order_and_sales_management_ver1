using order_and_sales_management_ver1.Data;
using order_and_sales_management_ver1.Models;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace order_and_sales_management_ver1.Controllers
{
    public class barcodeController : Controller
    {
        private static readonly string gulsevenPrefix = "8693819";
        private string barcode { get; set; }

        private readonly ApplicationDbContext _context;

        private readonly List<int>  barcodesUsed;

        public barcodeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public string calcCheckDigit(string barcode)
        {
            int digitsTotal=0;

            for (int i = 0; i < barcode.Length; i++)
            {
                if (i % 2 == 0)
                    digitsTotal = digitsTotal + int.Parse(barcode.Substring(i, 1));
                else
                    digitsTotal = digitsTotal + int.Parse(barcode.Substring(i, 1))*3;
            }
            int cDigit = (10 - (digitsTotal % 10)) % 10;
            return (cDigit.ToString("D1"));
        }
        public IActionResult fillAvailableBarcodesTable()
        {
            int productCode = 1;

            while (productCode <20000)
            {
                availableBarcodes avail = new availableBarcodes();
                avail.barcodeID = getFirstAvailableFromProductBarcode(ref productCode);
                _context.Add(avail);
                _context.SaveChanges();
                productCode = productCode + 1;
            }
            
            return View();
        }
         public string getFirstAvailableFromProductBarcode(ref int initialProductID)
        {
            string barcodeString="";
            Boolean available = false;
            int productCode = initialProductID;
            while (available==false)
            {
                productCode.ToString("D5");
                barcodeString = gulsevenPrefix + productCode.ToString("D5");
                barcodeString = barcodeString + calcCheckDigit(barcodeString);

                products pModel = _context.Products.FirstOrDefault(x => x.productBarcodeID == barcodeString);
                if (pModel != null)
                    productCode = productCode + 1;
                else
                    available = true;
            }
            initialProductID = productCode;
            return barcodeString;
        }

        public string getFirstAvailableBarcode()
        {
            string barcodeString = "";
            availableBarcodes avail = new availableBarcodes();
            avail = _context.AvailableBarcodes.FirstOrDefault();
            barcodeString = avail.barcodeID;
            _context.AvailableBarcodes.Remove(avail);
            _context.SaveChanges();
            return barcodeString;
        }

    }
}
