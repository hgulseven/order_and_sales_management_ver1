using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySql.Data.MySqlClient;
using order_and_sales_management_ver1.Models;
using order_and_sales_management_ver1.Data;

namespace order_and_sales_management_ver1.Controllers
{
    public class KasaMutabakatController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KasaMutabakatController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult MutabakatEntry()
        {
            MySqlConnection cnn;
            var applicationDBContext = _context.kasamutabakat;
            KasaMutabakat kasaMutabakat=new KasaMutabakat();
            if (User.Identity.IsAuthenticated)
            {
                var location = int.Parse(HttpContext.User.Claims.Where(c => c.Type == "location").FirstOrDefault().Value.ToString());
                kasaMutabakat = applicationDBContext.Where<KasaMutabakat>(x => x.mutabakatDate == DateTime.Today)
                                                                                                                                       .Select(s => s)
                                                                                                                                       .Where(y => y.typeOfMutabakat == "Gün Başı Mutabakat")
                                                                                                                                       .Select(x=>x)
                                                                                                                                       .Where(z=>z.locationID==location)
                                                                                                                                        .FirstOrDefault();
                if (kasaMutabakat is null)
                {
                    kasaMutabakat = new KasaMutabakat();
                    kasaMutabakat.employee = new EmployeesModels();
                    kasaMutabakat.mutabakatTimeStamp = DateTime.Now;
                    ViewData["GunBasiDone"] = 0;
                } else
                {
                    ViewData["GunBasiDone"] = 1;
                }
                kasaMutabakat.mutabakatDate= DateTime.Today;
                kasaMutabakat.locationID = location;
                try
                {
                    cnn = new MySqlConnection(Program.Connection_String);
                    cnn.Open();
                    MySqlCommand mySqlCommand = cnn.CreateCommand();
                    mySqlCommand.CommandText = "select locationID, typeOfCollection, sum(paidAmount) as paidAmount from paidamountview where saleTime >= @startTime and saleTime < @endTime  and locationID = @locationID group by locationID,typeOfCollection";
                    mySqlCommand.Parameters.AddWithValue("@startTime", DateTime.Today);
                    mySqlCommand.Parameters.AddWithValue("@endTime", DateTime.Now);
                    mySqlCommand.Parameters.AddWithValue("@locationID", location);
                    MySqlDataReader reader = mySqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        var typeOfCollection = int.Parse(reader["typeOfCollection"].ToString());
                        switch (typeOfCollection)
                        {
                            case 1:
                                kasaMutabakat.sistemNakitToplam = float.Parse(reader["paidAmount"].ToString());
                                break;
                            case 2:
                                kasaMutabakat.sistemKrediKartıToplam = float.Parse(reader["paidAmount"].ToString());
                                break;
                            case 3:
                                kasaMutabakat.sistemDigerToplam = float.Parse(reader["paidAmount"].ToString());
                                break;
                        }
                    }
                    reader.Close();
                    mySqlCommand.Dispose();
                    cnn.Close();
                }
                catch
                {
                    ModelState.AddModelError("veriTabanı", "Veri Tabanına erişilemiyor ya da veri tabanı hatası.");
                }
                ViewData["personelID"] = new SelectList(_context.employeesmodels, nameof(EmployeesModels.personelID), nameof(EmployeesModels.persName));
                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Gün Başı Mutabakat", Value = "Gün Başı Mutabakat", Selected = true });
                items.Add(new SelectListItem { Text = "Ara Mutabakat", Value = "Ara Mutabakat", Selected = false });
                items.Add(new SelectListItem { Text = "Gün Sonu Mutabakat", Value = "Gün Sonu Mutabakat", Selected = false });
                ViewData["typeOfMutabakat"] = items;
            }
            else
            {
                ModelState.AddModelError("error", "Sisteme giriş yapmalısınız. Lütfen sisteme giriş sayfasına gidiniz.");
            }
            return View(kasaMutabakat);
        }
        [HttpPost]
        public ActionResult MutabakatSave([Bind("mutabakatDate","mutabakatTimeStamp","personelID","locationID","typeOfMutabakat","change10KRS","change25KRS","change50KRS","change1TL","change5TL","change10TL","change20TL","change50TL","change100TL","change200TL","nakit10KRS","nakit25KRS","nakit50KRS","nakit1TL","nakit5TL", "nakit10TL","nakit20TL","nakit50TL","nakit100TL","nakit200TL","diger10KRS","diger25KRS","diger50KRS","diger1TL","diger5TL","diger10TL","diger20TL","diger50TL","diger100TL","diger200TL","krediKartıToplam","sistemNakitToplam","sistemKrediKartıToplam","sistemDigerToplam")] KasaMutabakat kasaMutabakat)
        {
            var applicationDBContext = _context.kasamutabakat;
            if (kasaMutabakat.typeOfMutabakat!= "Gün Başı Mutabakat")
            {
                kasaMutabakat.mutabakatTimeStamp = DateTime.Now;
                applicationDBContext.Add(kasaMutabakat);
            } else
            {
                if (_context.kasamutabakat.Any<KasaMutabakat>(p => p.mutabakatTimeStamp== kasaMutabakat.mutabakatTimeStamp &&
                                                                                                                 p.locationID == kasaMutabakat.locationID &&
                                                                                                                 p.typeOfMutabakat == kasaMutabakat.typeOfMutabakat))
                    applicationDBContext.Update(kasaMutabakat);
                else
                    applicationDBContext.Add(kasaMutabakat);
            }
            _context.SaveChanges();
            return RedirectToAction("MutabakatEntry");
        }

    }
}
