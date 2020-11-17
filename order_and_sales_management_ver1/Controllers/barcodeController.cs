using order_and_sales_management_ver1.Data;
using order_and_sales_management_ver1.Models;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;


namespace order_and_sales_management_ver1.Controllers
{
    public class barcodeController : Controller
    {
        private static readonly string gulsevenPrefix = "8693819";
        private string barcode { get; set; }

        private readonly ApplicationDbContext _context;

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
         public string getFirstAvailableBarcode()
        {
            string barcodeString="";
            Boolean available = false;
            int productCode = 1;
            while (available==false)
            {
                productCode.ToString("D5");
                barcodeString = gulsevenPrefix + productCode.ToString("D5");
                barcodeString = barcodeString + calcCheckDigit(barcodeString);
                ProductModel pModel = _context.productmodels.FirstOrDefault(x => x.productBarcodeID == barcodeString);
                if (pModel != null)
                    productCode = productCode + 1;
                else
                    available = true;
            }
            return barcodeString;
        }
    }
}
