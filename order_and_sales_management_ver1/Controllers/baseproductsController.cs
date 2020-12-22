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
            var baseProducts = await _context.baseProducts.ToListAsync();
            for (int i = 0; i < baseProducts.Count; i++)
            {
                baseProducts[i].wholeSalePrice = baseProducts[i].wholeSalePrice * (1 + baseProducts[i].productKDV);
            }
            return View(baseProducts);
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
            return View();
        }

        // POST: baseproducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("baseId,retailPrice,wholeSalePrice,productKDV,barcodeID, name,sellersID,detailsId")] baseproduct baseproduct)
        {
            string error_msg = "";

            if (ModelState.IsValid)
            {
                if (baseproduct.barcodeID.Length == 13)
                {
                    barcodeController barcode = new barcodeController(_context);
                    string checkDigit = barcode.calcCheckDigit(baseproduct.barcodeID.Substring(0, 12));
                    if (checkDigit != baseproduct.barcodeID.Substring(12, 1))
                    {
                        error_msg = "Barkod kontrol karakteri hatalı.";
                    }
                }
                else
                {
                    error_msg = "Barkod Uzunluğu 13 karakter olmalı";
                }
                if (error_msg != "")
                {
                    ModelState.AddModelError("barkod", error_msg);
                }
                else
                {
                    _context.Add(baseproduct);
                    _context.SaveChanges();
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(baseproduct);
        }

        // GET: baseproducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var baseproduct = await _context.baseProducts.FindAsync(id);
            if (baseproduct == null)
            {
                return NotFound();
            }
            return View(baseproduct);
        }

        // POST: baseproducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("baseId,retailPrice,barcodeID, productKDV, wholeSalePrice,name,sellersID,detailsId")] baseproduct baseproduct)
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
        public IActionResult DeleteConfirmed(int id)
        {
            var baseproduct = _context.baseProducts.Find(id);
            _context.baseProducts.Remove(baseproduct);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool baseproductExists(int id)
        {
            return _context.baseProducts.Any(e => e.baseId == id);
        }
        public string getBarcode()
        {
            baseproduct baseProduct = new baseproduct();
            barcodeController barcode = new barcodeController(_context);
            var barcodeID = barcode.getFirstAvailableBarcode();
            return (barcodeID);
        }

        public string changeProductNameToCamelCase(string prdName)
        {
            char[] lowerTurkishChars = new char[] { 'ğ', 'ü', 'ş', 'ı', 'i', 'ö', 'ç' };
            char[] upperTurkishChars = new char[] { 'Ğ', 'Ü', 'Ş', 'I', 'İ', 'Ö', 'Ç' };
            string tmpName;
            string[] strParts;

            /* Eğer kısaltmalar kullanıldıysa her .'dan sonrasına bir boşluk atılarak split fonksiyonun kıslatmaları ayırması sağlanır. */
            if (prdName.Contains('.'))
            {
                tmpName = "";
                while (prdName.Contains('.'))
                {
                    tmpName = tmpName + prdName.Substring(0, prdName.IndexOf(".") + 1) + " ";
                    prdName = prdName.Remove(0, prdName.IndexOf(".") + 1);
                }
                tmpName = tmpName + " " + prdName;
            }
            else
            {
                tmpName = prdName;
            }
            /* İsmi kelimelere ayır ve ilk karakteri büyüğk harf yap*/
            strParts = tmpName.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            prdName = "";
            for (int j = 0; j < strParts.Length; j++)
            {
                    char v = strParts[j][0];
                /* Eğer ilk karakter numeric bir değer ise aynen al. Diğer durumlarda ilk karakteri büyük Harfe çevir */
                    if ((int)v > 57)
                    {
                        if (lowerTurkishChars.Contains(v))
                        {
                            for (int k = 0; k < lowerTurkishChars.Length; k++)
                            {
                                if (v == lowerTurkishChars[k])
                                {
                                    v = upperTurkishChars[k];
                                    break;
                                }
                            }
                        }
                        else
                        {
                            v = (char)((int)v - 32);
                        }
                        strParts[j] = v + strParts[j].Remove(0, 1);
                    /* Eğer iki karakter ise "H." gibi sonrasına bir boşluk ekleme. Diğer durumlarda bir boşluk ekle. Eğer Gr var ise sonuna nokta ekle */
                        if (strParts[j].Length == 2)
                            if (strParts[j] == "Gr" || strParts[j]=="Kg")
                            prdName = prdName + strParts[j] + ". ";
                            else
                                prdName = prdName + strParts[j];
                        else
                            prdName = prdName + strParts[j] + " ";
                    }
                    else
                        prdName = prdName + strParts[j] + " ";
            }
            return (prdName.Trim());
        }

        public string UpdateNamesAsCamelCase()
        {
            string prdName="";

            List<packedproduct> pProducts = _context.packedProducts.ToList();
            for (int i = 0; i < pProducts.Count; i++)
            {
                prdName = pProducts[i].packedProductName.ToLower();
                pProducts[i].packedProductName = changeProductNameToCamelCase(prdName);
                _context.packedProducts.Update(pProducts[i]);
            }
            _context.SaveChanges();

            List<baseproduct> bProducts = _context.baseProducts.ToList();
            for (int i = 0; i < bProducts.Count; i++)
            {
                prdName = bProducts[i].name.ToLower();
                bProducts[i].name= changeProductNameToCamelCase(prdName);
                _context.baseProducts.Update(bProducts[i]);
            }
            _context.SaveChanges();
            return ("OK");
        }
        /*
         * Can be used when necessary 
         * 
                public List<baseproduct>CheckandUpdateBarcodes_baseproducts()
                {
                    List<baseproduct> baseproduct = new List<baseproduct>();
                    List<baseproduct> bprodWithWrongBarcode = new List<baseproduct>();

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
                                bprod.barcodeID = barcode.getFirstAvailableBarcode();

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
                                pprod.packedProductBarcodeID= barcode.getFirstAvailableBarcode();
                                _context.packedProducts.Update(pprod);
                                _context.SaveChanges();
                        }
                    }
                    return packedProductWithWrongBarcode;
                }
            }
        */
    }
}
