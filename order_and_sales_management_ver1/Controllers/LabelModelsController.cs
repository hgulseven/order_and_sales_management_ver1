using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using order_and_sales_management_ver1.Data;
using order_and_sales_management_ver1.Models;
using Newtonsoft;
using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace order_and_sales_management_ver1.Controllers
{
    public class LabelModelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private string error="";

        public LabelModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LabelModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.labelmodels.ToListAsync());
        }

        // GET: LabelModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labelModel = await _context.labelmodels
                .FirstOrDefaultAsync(m => m.productID == id);
            if (labelModel == null)
            {
                return NotFound();
            }

            return View(labelModel);
        }

        public string getProductData(string BarcodeID)
        {
            LabelModel labelModel;
            string jsonStr="";

            if (BarcodeID != null)
            {
                labelModel = _context.labelmodels.FirstOrDefault<LabelModel>(x => x.productBarcodID == BarcodeID);
                if (labelModel == null)
                {
                    ProductModel product = _context.productmodels.FirstOrDefault<ProductModel>(x => x.productBarcodeID == BarcodeID);
                    if (product != null)
                    {
                        labelModel = new LabelModel();
                        labelModel.productBarcodID = BarcodeID;
                        labelModel.productID = product.productID;
                        labelModel.productName = product.ProductName;
                        labelModel.productContents = "İÇİNDEKİLER: ŞEKER,MISIR NİŞASTASI, A.FISTIĞIASİTLİĞİ DÜZENLEYİCİ SİTRİK ASİT(E-330)";
                        labelModel.productLawStr = "BU ÜRÜN TÜRK GIDA KODEKSİ YÖNETMELİĞİ LOKUM TEBLİĞİNE  UYGUN OLARAK ÜRETİLMİŞTİR.";
                        labelModel.productStoringCond = "16 - 20°C ARASINDA KOKUSUZ BİR YERDE MUHAFAZA EDİNİZ.IŞIK ,HAVA VE NEMDEN KORUYUNUZ.";
                        labelModel.productLotNo = "İMALATA TARİHİ PARTİ NUMARASIDIR.";
                        labelModel.productShelfLife = "";
                        labelModel.mensei = "MENŞEİ TÜRKİYE";
                        labelModel.recordExists = "no";
                    } else
                    {
                        return ("{}");
                    }
                }
                else
                {
                    labelModel.recordExists = "yes";
                }
                jsonStr = JsonConvert.SerializeObject(labelModel);
            }
            return (jsonStr);
        }

        // GET: LabelModels/Create
        public IActionResult Create(int id)
        {
            LabelModel labelModel = new LabelModel();
                if (id != 0)
                {
                    labelModel = _context.labelmodels.FirstOrDefault<LabelModel>(x => x.productID == id);
                    if (labelModel != null)
                        labelModel.recordExists = "yes";
                    else
                    {
                        ModelState.AddModelError("helper","LÜTFEN ETİKET TANIMLANACAK ÜRÜNÜN BARKOD NUMARASINI GİRİNİZ. PAKETLİ ÜRÜN LİSTESİNDEN BARKODU KOPYALAYABİLİRSİNİZ");
                        labelModel = new LabelModel();
                        labelModel.recordExists = "no";
                        barcodeController barcode = new barcodeController(_context);
                    }
                }
                else
                {
                ModelState.AddModelError("helper", "LÜTFEN ETİKET TANIMLANACAK ÜRÜNÜN BARKOD NUMARASINI GİRİNİZ. PAKETLİ ÜRÜN LİSTESİNDEN BARKODU KOPYALAYABİLİRSİNİZ");
                labelModel.recordExists = "no";
                    barcodeController barcode = new barcodeController(_context);
            }
            return View(labelModel);
        }

        // POST: LabelModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("productID,productName,productAmount,productContents,productLawStr, productStoringCond,productLotNo,productShelfLife,productBarcodID,recordExists,companyInfo,mensei,alerji")] LabelModel labelModel)
        {
            if (ModelState.IsValid)
            {
                if (labelModel.recordExists == "yes")
                {
                    try
                    {
                        _context.Update(labelModel);
                        await _context.SaveChangesAsync();
                        ProductModel product = new ProductModel();
                        product = _context.productmodels.FirstOrDefault<ProductModel>(x => x.productID == labelModel.productID);
                        _context.Update(product);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!LabelModelExists(labelModel.productID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                else
                {
                    _context.Add(labelModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(labelModel);
        }

        // GET: LabelModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labelModel = await _context.labelmodels.FindAsync(id);
            if (labelModel == null)
            {
                return NotFound();
            }
            return View(labelModel);
        }

        // POST: LabelModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("productID,productName,productAmount,productContents,productLawStr, productStoringCond,productLotNo,productShelfLife,productBarcodID,recordExists,mensei, alerji")] LabelModel labelModel)
        {
            if (id != labelModel.productID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(labelModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabelModelExists(labelModel.productID))
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
            return View(labelModel);
        }

        // GET: LabelModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labelModel = await _context.labelmodels
                .FirstOrDefaultAsync(m => m.productID == id);
            if (labelModel == null)
            {
                return NotFound();
            }

            return View(labelModel);
        }

        // POST: LabelModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var labelModel = await _context.labelmodels.FindAsync(id);
            _context.labelmodels.Remove(labelModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabelModelExists(int id)
        {
            return _context.labelmodels.Any(e => e.productID == id);
        }
        public async Task<IActionResult> Print(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labelModel = await _context.labelmodels
                .FirstOrDefaultAsync(m => m.productID == id);
            if (labelModel == null)
            {
                return NotFound();
            }

            return View(labelModel);
        }

        public class LabelData
        {
            public string typeOfPrintMedia { get; set; }
            public List<string> headerLines { get; set; }
            public List<string> detailLines { get; set; }
            public List<string> footerLines { get; set; }
            public string barcode { get; set; }
            public int numberOfCopies { get; set; }
            public int typeOfLabel { get; set; }
        }


        // POST: LabelModels/Delete/5
        [HttpPost, ActionName("Print")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PrintConfirmed(int id, [Bind("productID,numberOfCopies")] LabelModel labelModel)
        {
            int numberOfCopies = labelModel.numberOfCopies;
            var printModel = await _context.labelmodels.FindAsync(labelModel.productID);
            printModel.numberOfCopies= labelModel.numberOfCopies;
            LabelData labelData = new LabelData();
            labelData.numberOfCopies = numberOfCopies;
            labelData.headerLines = new List<string>();
            labelData.detailLines = new List<string>();
            labelData.footerLines = new List<string>();
            labelData.barcode = printModel.productBarcodID;
            labelData.typeOfPrintMedia = "Label";
            labelData.typeOfLabel = printModel.typeOfLabel;
            labelData.headerLines.Add(printModel.productName);
            labelData.headerLines.Add(printModel.productAmount);
            labelData.detailLines.Add(printModel.productContents);
            labelData.detailLines.Add(printModel.productLawStr);
            labelData.detailLines.Add(printModel.productStoringCond);
            labelData.detailLines.Add(printModel.alerji);
            labelData.detailLines.Add(printModel.productLotNo);
            labelData.detailLines.Add(printModel.mensei);
            labelData.detailLines.Add("İMALAT TARİHİ : " + DateTime.Now.ToString("dd-MM-yyyy"));
            labelData.detailLines.Add(printModel.productShelfLife);

            labelData.footerLines.Add(printModel.companyInfo);
            SocketClient socketClient = new SocketClient();
            string jsonStr = JsonConvert.SerializeObject(labelData);
            socketClient.StartClient(jsonStr);
            return RedirectToAction(nameof(Index));
        }
    }
    
   

    public class ReceiptData 
    { }

   
}
