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

        public string getData(string BarcodeID)
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
                        labelModel.productLotNo = "İmalat tarihi parti nosudur.";
                        labelModel.productShelfLife = "6 ay içinde tüketilmesi tavsiye olunur";
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
                        labelModel.recordExists = "no";
                }
                else
                {
                    labelModel.recordExists = "no";
                }
            return View(labelModel);
        }

        // POST: LabelModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("productID,productName,productAmount,productContents,productLawStr, productStoringCond,productLotNo,productShelfLife,productBarcodID,recordExists,companyInfo")] LabelModel labelModel)
        {
            if (ModelState.IsValid)
            {
                if (labelModel.recordExists == "yes")
                {
                    try
                    {
                        _context.Update(labelModel);
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
        public async Task<IActionResult> Edit(int id, [Bind("productID,productName,productAmount,productContents,productLawStr, productStoringCond,productLotNo,productShelfLife,productBarcodID,recordExists")] LabelModel labelModel)
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

        // POST: LabelModels/Delete/5
        [HttpPost, ActionName("Print")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PrintConfirmed(int id, [Bind("productID,numberOfCopies")] LabelModel labelModel)
        {
            int numberOfCopies = labelModel.numberOfCopies;
            var printModel = await _context.labelmodels.FindAsync(labelModel.productID);
            printModel.numberOfCopies= labelModel.numberOfCopies;
            SocketClient socketClient = new SocketClient();
            socketClient.StartClient(printModel);
            return RedirectToAction(nameof(Index));
        }

        public class SocketClient
        {
            public class LabelData
            {
                public  string productName { get; set; }
                public string weight { get; set; }
                public List<string> aciklama { get; set; }
                public string barcode { get; set; }
                public int numberOfCopies { get; set; }
                public int typeOfLabel { get; set; }

                public string setLabelData(LabelModel label)
                {
                    LabelData labelData = new LabelData();
                    labelData.aciklama = new List<string>();

                    labelData.productName = label.productName;
                    labelData.weight = label.productAmount;
                    labelData.aciklama = new List<string>();
                    labelData.aciklama.Add(label.productContents);
                    labelData.aciklama.Add(label.productLawStr);
                    labelData.aciklama.Add(label.productStoringCond);
                    labelData.aciklama.Add(label.productLotNo);
                    labelData.aciklama.Add("IMALAT TARİHİ: " + DateTime.Now.ToString("dd-MM-yyyy"));
                    labelData.aciklama.Add(label.productShelfLife);
                    labelData.aciklama.Add(label.companyInfo);
                    if ((label.companyInfo != null) && label.companyInfo.Length > 0)
                        labelData.typeOfLabel = 1;
                    else
                        labelData.typeOfLabel = 0;
                    labelData.barcode = label.productBarcodID;
                    labelData.numberOfCopies = label.numberOfCopies;
                    String jsonOutput = JsonConvert.SerializeObject(labelData,Formatting.Indented);
                    return (jsonOutput);
                }

            }

            public void StartClient(LabelModel label)
            {
                string Print_Server_IP_Address = "192.168.1.50";

                byte[] bytes = new byte[1024];

                try
                {
                    // Connect to a Remote server  
                    // Get Host IP Address that is used to establish a connection  
                    // In this case, we get one IP address of localhost that is IP : 127.0.0.1  
                    // If a host has multiple addresses, you will get a list of addresses  
                    IPAddress ipAddress = IPAddress.Parse(Print_Server_IP_Address);
                    IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

                    // Create a TCP/IP  socket.    
                    Socket sender = new System.Net.Sockets.Socket(ipAddress.AddressFamily,
                        SocketType.Stream, ProtocolType.Tcp);

                    // Connect the socket to the remote endpoint. Catch any errors.    
                    try
                    {
                        // Connect to Remote EndPoint  
                        sender.Connect(remoteEP);

                        Console.WriteLine("Socket connected to {0}",
                            sender.RemoteEndPoint.ToString());
                        LabelData labelData = new LabelData();

                        string labelStr = labelData.setLabelData(label);
                        // Encode the data string into a byte array.    
                        byte[] msg = Encoding.Unicode.GetBytes(labelStr + "<EOF>");

                        // Send the data through the socket.    
                        int bytesSent = sender.Send(msg);

                        // Receive the response from the remote device.    
                        int bytesRec = sender.Receive(bytes);
                        Console.WriteLine("Echoed test = {0}",
                            Encoding.Unicode.GetString(bytes, 0, bytesRec));

                        // Release the socket.    
                        sender.Shutdown(SocketShutdown.Both);
                        sender.Close();

                    }
                    catch (ArgumentNullException ane)
                    {
                        Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                    }
                    catch (SocketException se)
                    {
                        Console.WriteLine("SocketException : {0}", se.ToString());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Unexpected exception : {0}", e.ToString());
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }


    }
}
