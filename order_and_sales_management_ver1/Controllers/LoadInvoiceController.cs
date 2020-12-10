using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Http;
using order_and_sales_management_ver1.Models;
using order_and_sales_management_ver1.Data;

namespace order_and_sales_management_ver1.Controllers
{

    public class LoadInvoiceController : Controller
    {
        private readonly ApplicationDbContext _context;
        private string error = "";

        public LoadInvoiceController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Index(IFormFile formFile)
        {
            Invoice invoice = new Invoice();
            if (HttpContext.Request.Form.Files.Count != 0)
            {
                XMLKeyValuePairs xmlKeyValuePairs = new XMLKeyValuePairs();
                StreamReader xmlFile = null;

                var path = System.Environment.GetEnvironmentVariable("HOMEPATH") + "\\Invoices\\";
                if (HttpContext.Request.Form.Files[0] != null)
                {
                    var file = HttpContext.Request.Form.Files[0];
                    try
                    {
                        string fileName = path + file.FileName;
                        using (var stream = new FileStream(fileName, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        xmlFile = new StreamReader(fileName);

                        xmlKeyValuePairs.parseXML(xmlFile);

                        invoice.fillToStructure(xmlKeyValuePairs);
                        xmlFile.Close();
                        for (int i = 0; i < invoice.invoiceLines.Count; i++)
                        {
                            string sellersKey = invoice.suplier + "-" + invoice.invoiceLines.ElementAt(i).sellersIDForItem;
                            baseproduct prdct = _context.baseProducts.FirstOrDefault(x => x.sellersID == sellersKey);
                            if (prdct != null)
                            {
                                invoice.invoiceLines.ElementAt(i).urunKodu = prdct.barcodeID;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (xmlFile != null)
                            xmlFile.Close();
                        ModelState.AddModelError("fileSave", "Yüklenmek istenen dosya yazılmadı.");
                    }
                }
                else
                {
                    ModelState.AddModelError("fileSave", "Dosya seçilmemiş.");
                }
            } else
            {
                var sellersIDForItems = HttpContext.Request.Form["item.sellersIDForItem"].ToArray();
                var urunKodları = HttpContext.Request.Form["item.urunKodu"].ToArray();
                var itemPrices = HttpContext.Request.Form["item.itemPrice"].ToArray();
                var invoicedQuantities = HttpContext.Request.Form["item.invoicedQuantity"].ToArray();
                var itemNames= HttpContext.Request.Form["item.itemName"].ToArray();
                var itemDescs = HttpContext.Request.Form["item.itemDesc"].ToArray();
                for (int i=0; i < sellersIDForItems.Length;i++)
                {
                    Invoice.InvoiceLine line = new Invoice.InvoiceLine();
                    line.invoicedQuantity = decimal.Parse(invoicedQuantities[i]);
                    line.urunKodu = urunKodları[i];
                    line.sellersIDForItem = sellersIDForItems[i];
                    line.itemName = itemNames[i];
                    line.itemDesc = itemDescs[i];
                    line.lineID = i+1;
                    invoice.invoiceLines.Add(line);
                }
                invoice.suplier = HttpContext.Request.Form["suplier"];
                invoice.partyId = HttpContext.Request.Form["partyID"];
                invoice.allowanceMultiplier = decimal.Parse(HttpContext.Request.Form["allowanceMultiplier"]);
                invoice.allowanceAmount = decimal.Parse(HttpContext.Request.Form["allowanceAmount"]);
                for (int i = 0; i < urunKodları.Length; i++)
                {
                    if (urunKodları[i] != "")
                    {
                        baseproduct prdct = _context.baseProducts.FirstOrDefault(x => x.barcodeID == urunKodları[i]);
                        if (prdct != null)
                        {
                            prdct.sellersID = invoice.suplier + "-" + sellersIDForItems[i];
                            prdct.wholeSalePrice= decimal.Parse(itemPrices[i]);
                            _context.baseProducts.Update(prdct);
                            _context.SaveChanges();
                        }
                        else
                        {
                            ModelState.AddModelError("usererr", (i+1).ToString() + ". Satırdaki ürun Kodu girişi yapılmamış ya da kod hatalı. Lütfen ürün kodu girişlerini yapınız.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("usererr", (i+1).ToString() + ". Satırdaki ürun Kodu girişi yapılmamış ya da kod hatalı. Lütfen ürün kodu girişlerini yapınız.");
                    }
                }
                invoice = new Invoice();
            }
            return View(invoice);
        }
        
       public IActionResult Index()
        {
            Invoice invoice = new Invoice();
            return View(invoice);
        }

        public List<baseproduct> getProducts(string productName)
        {
            List<baseproduct> products = new List<baseproduct>();
            if (!String.IsNullOrEmpty(productName))
            {
                products = _context.baseProducts.Where(x => x.name.Contains(productName)).ToList();
            }
            else
            {
                products = new List<baseproduct>();

            }
            return products;
        }
    }
}
