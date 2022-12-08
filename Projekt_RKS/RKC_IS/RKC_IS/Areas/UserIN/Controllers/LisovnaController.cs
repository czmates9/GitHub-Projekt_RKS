using Microsoft.AspNet.Identity;
using RKC_IS.DataAccess.Model.AutoMapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using PagedList;

namespace RKC_IS.Areas.UserIN.Controllers
{
    public class LisovnaController : Controller
    {
        private ConnectionMap_RKC_Database db = new ConnectionMap_RKC_Database();
        // GET: UserIN/Lisovna
        public ActionResult Index()
        {
           
            //Pocet stroju, ktere jsou na lisovne a maji zadanou pozici X
            int pocetStroju = db.STROJ.ToList().Where(s => s.ZAOR_Organizace == "LIS").Where(s => s.X != null).Count();
            ViewBag.pocetStroju = pocetStroju;
           


            IList<STROJ> seznamStroju = db.STROJ.Where(s => s.ZAOR_Organizace == "LIS" && s.X != null && s.Y != null && s.Y != null && s.DX != null && s.DY != null).ToList();
            //ViewBag.seznamStroju = seznamStroju;
            STROJ localStroj = new STROJ();
            ViewBag.barva = StavZarizeni(localStroj.ID);

            //var myDaemon = new MiniDaemon(thisObject, callback[, rate[, length]]);


            //return View(seznamStroju);
            return View(seznamStroju);
        }



        //zkouska---------------------------------------------------------
        //public JsonResult Index()
        //{

        //    //Pocet stroju, ktere jsou na lisovne a maji zadanou pozici X
        //    int pocetStroju = db.STROJ.ToList().Where(s => s.ZAOR_Organizace == "LIS").Where(s => s.X != null).Count();
        //    ViewBag.pocetStroju = pocetStroju;



        //    IList<STROJ> seznamStroju = db.STROJ.Where(s => s.ZAOR_Organizace == "LIS" && s.X != null && s.Y != null && s.Y != null && s.DX != null && s.DY != null).ToList();
        //    //ViewBag.seznamStroju = seznamStroju;
        //    STROJ localStroj = new STROJ();
        //    ViewBag.barva = StavZarizeni(localStroj.ID);

        //    //var myDaemon = new MiniDaemon(thisObject, callback[, rate[, length]]);


        //    //return View(seznamStroju);
        //    return Json(seznamStroju, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult WelcomeNote()
        {
            bool isAdmin = false;
            string output = isAdmin ? "Welcome" : "Matouš";

            return Json(output, JsonRequestBehavior.AllowGet);
        }

        protected override JsonResult Json(object data,
           string contentType, Encoding contentEncoding,
           JsonRequestBehavior behavior)
        {
            return new JsonResult()
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                MaxJsonLength = Int32.MaxValue
            };
        }

        //------------------------------------------------------------------------





        //---------------------------------- VYROBA_ZAZNAM START------------------------------------------------------------------------------------------


        // GET: UserIN/VYROBA_ZAZNAM/Create
        public ActionResult NasazeniZakazkaNaStroj(int? id)
        {
            ViewBag.STAV = new SelectList(db.SY_STAV.Where(o => o.TABULKA == "VYROBA_ZAZNAM").Where(o => o.STAV == 2), "ID", "POPIS");
            ViewBag.ID_USER = new SelectList(db.USER, "ID", "ZAOR_organizace");





            ZAKAZKA prZak = new ZAKAZKA();

            if(id !=null)
            {

                ViewBag.ID_ZAKAZKA = new SelectList(db.ZAKAZKA.Include(z => z.SY_STAV).Include(z => z.STROJ)
                               .Where(o => o.SY_STAV.TABULKA == "ZAKAZKA")
                               .Where(o => o.SY_STAV.STAV == 2)
                               .OrderBy(o => o.CisloZakazka), "ID", "CisloZakazka"
                               , id) ;

            }
            else
            {
                ViewBag.ID_ZAKAZKA = new SelectList(db.ZAKAZKA.Include(z => z.SY_STAV).Include(z => z.STROJ)
                               .Where(o => o.SY_STAV.TABULKA == "ZAKAZKA")
                               .Where(o => o.SY_STAV.STAV == 2)
                               .OrderBy(o => o.CisloZakazka), "ID", "CisloZakazka");
            }
            




            //var stands = db.ZAKAZKA.Include(z => z.SY_STAV).Include(z => z.STROJ)
            //   .Where(o => o.SY_STAV.TABULKA == "ZAKAZKA")
            //   .Where(o => o.SY_STAV.STAV == 2)
            //   .OrderBy(o => o.CisloZakazka).ToList();
            //IEnumerable<SelectListItem> selectList = from s in stands
            //                                         select new SelectListItem
            //                                         {
            //                                             Value = s.ID.ToString(),
            //                                             Text = s.CisloZakazka.ToString() + s.STROJ.Nazev.ToString() + s.STROJ.Cislo.ToString()
            //                                         };
            //ViewBag.StandID = new SelectList(selectList, "Value", "Text");



            //var ddlclientnames = (from ddl in db.ZAKAZKA.Include(z => z.SY_STAV).Include(z => z.STROJ)
            //   .Where(o => o.SY_STAV.TABULKA == "ZAKAZKA")
            //   .Where(o => o.SY_STAV.STAV == 2)
            //   .OrderBy(o => o.CisloZakazka)
            //                      select new { id = ..., FullName = ZakazkaCislo + Lastname }.ToList();

        //    ViewBag.listZakazek_00 = new SelectList((from s in db.ZAKAZKA.Include(z => z.SY_STAV).Include(z => z.STROJ)
        //       .Where(o => o.SY_STAV.TABULKA == "ZAKAZKA")
        //       .Where(o => o.SY_STAV.STAV == 2)
        //       .OrderBy(o => o.CisloZakazka).ToList()
        //                                         select new
        //                                         {
        //                                             ID = s.ID,
        //                                             Popisek = s.CisloZakazka + " " + s.STROJ.Nazev + " " + s.STROJ.Cislo
        //                                         }),
        //"ID",
        //"Popisek",
        //null);





            return View();
        }

        // POST: UserIN/VYROBA_ZAZNAM/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NasazeniZakazkaNaStroj([Bind(Include = "ID,ID_M,ID_ZAKAZKA,ID_USER,CasPrace,OK,NOK,Poznamka,TimeStart,TimeEnd,C_USER,C_DATE,M_USER,M_DATE,STAV,STAV_NASLEDUJICI")] VYROBA_ZAZNAM vYROBA_ZAZNAM)
        {
            int? id_stroj = 0;
            vYROBA_ZAZNAM.ID_USER = User.Identity.GetUserId<int>();
            vYROBA_ZAZNAM.C_USER = User.Identity.GetUserId<int>();
            vYROBA_ZAZNAM.C_DATE = DateTime.Now;
            //vYROBA_ZAZNAM.TimeEnd = DateTime.Now; //použítí jen pro ladění
            //sTROJ.STAV = sTav.ID;

            

            if (ModelState.IsValid)
            {
                db.VYROBA_ZAZNAM.Add(vYROBA_ZAZNAM);
                db.SaveChanges();



                //vyhledat přidruženou, zakázku překlopit stav
                var infoZakazka = vYROBA_ZAZNAM.ID_ZAKAZKA;


                //var zakazka_data_02 = db.ZAKAZKA.Single(p => p.ID == infoZakazka);

                //vyhledat stav pro zakazku seřízeno seřizovačem
                //zakazka_data_02.STAV == neco

                var vyberStavu =
                  from stavTri in db.SY_STAV
                  where stavTri.TABULKA == "ZAKAZKA" && stavTri.STAV == 3
                  select stavTri;


                // Query the database for the row to be updated.
                var query =
                    from Zakazka in db.ZAKAZKA
                    where Zakazka.ID == infoZakazka
                    select Zakazka;

                // Execute the query, and change the column values
                // you want to change.
                foreach (ZAKAZKA Zakazka in query)
                {
                    foreach (SY_STAV stavTri in vyberStavu)
                    {
                        Zakazka.STAV = stavTri.ID; //najít stav pro zakazka seřízeno
                        if(Zakazka.ID_STROJ  != null)
                        {

                            id_stroj = Zakazka.ID_STROJ;
                        }
                    }
                    // Insert any additional changes to column values.
                }

                // Submit the changes to the database.
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    // Provide for exceptions.
                }

                return RedirectToAction("DetailLis", "Lisovna", new { id = id_stroj });

            }

            ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "TABULKA", vYROBA_ZAZNAM.STAV);
            ViewBag.ID_USER = new SelectList(db.USER, "ID", "ZAOR_organizace", vYROBA_ZAZNAM.ID_USER);
            ViewBag.ID_ZAKAZKA = new SelectList(db.ZAKAZKA, "ID", "Oznaceni", vYROBA_ZAZNAM.ID_ZAKAZKA);
            return View(vYROBA_ZAZNAM);
        }





        //--------------------------------------Záznam do výrobáku START--------------------------------------------------------------------------------------------
      
            public ActionResult ZaznamDoVyrobnihoVykazuBezStroje()
        {
            return View();
        }


        public ActionResult ZaznamDoVyrobnihoVykazu(int? id)
        {

            // deklarace a inicializace pro počty
            int ZapisCelkemOK = 0;
            int ZbyvaOK = 0;
            int ZapisCelkemNOK = 0;
            int idHlavniVyrobak = 0;

            TempData["ZapisCelkemOK"] = 0;
            TempData["ZapisCelkemNOK"] = 0;

            ViewBag.STAV = new SelectList(db.SY_STAV.Where(o => o.TABULKA == "VYROBA_ZAZNAM").Where(o => o.STAV == 3), "ID", "POPIS");
            ViewBag.ID_USER = new SelectList(db.USER, "ID", "ZAOR_organizace");
            //ViewBag.ID_ZAKAZKA = new SelectList(db.ZAKAZKA.Include(z=>z.SY_STAV)
            //    .Where(o => o.SY_STAV.TABULKA == "ZAKAZKA")
            //    .Where(o => o.SY_STAV.STAV == 2)
            //    .OrderBy(o => o.CisloZakazka), "ID", "CisloZakazka");
            TempData["CheckZakazkaUkonceno"] = false;



            ViewBag.OdpisZakazkyTrue = false;

            ZAKAZKA prZak = new ZAKAZKA();

            if (id != null)
            {
                var ZakazkaCisloQuery =
               from zakazkaCisloQuery in db.ZAKAZKA
               where zakazkaCisloQuery.ID == id
               select zakazkaCisloQuery;
                foreach (ZAKAZKA zakazkaCisloQuery in ZakazkaCisloQuery)
                {

                    var VyrobniListQuery =
              from _VyrobniListQuery in db.VYROBA_ZAZNAM
              where _VyrobniListQuery.ID_ZAKAZKA == id
              select _VyrobniListQuery;
                    foreach (VYROBA_ZAZNAM _VyrobniListQuery in VyrobniListQuery)
                    {
                        ViewBag.zakazkaCisloZobrazení = "Číslo zakázky: " + zakazkaCisloQuery.CisloZakazka + " Na stroji: " + zakazkaCisloQuery.STROJ.Nazev + " " + zakazkaCisloQuery.STROJ.Cislo;//pocet kusu na vyrobnim prikazu
                        TempData["IdZakazky"] = zakazkaCisloQuery.ID;
                        ViewBag.PocetKusuZobrazeni = zakazkaCisloQuery.PlanovaneMnozstviNa;//pocet kusu na vyrobnim prikazu
                        ZbyvaOK = (int)zakazkaCisloQuery.PlanovaneMnozstviNa;
                                idHlavniVyrobak = _VyrobniListQuery.ID;



                        if (_VyrobniListQuery.ID != null && _VyrobniListQuery.ID != 0)
                        {

                            var PodVyrobniListQuery =
                  from _PodVyrobniListQuery in db.VYROBA_ZAZNAM
                  where _PodVyrobniListQuery.ID_M == idHlavniVyrobak
                  select _PodVyrobniListQuery;
                            foreach (VYROBA_ZAZNAM _PodVyrobniListQuery in PodVyrobniListQuery)
                            {
                                ZapisCelkemOK += (int)_PodVyrobniListQuery.OK;
                                ZapisCelkemNOK += (int)_PodVyrobniListQuery.NOK;

                            }

                        }

                    }

                }

                ZbyvaOK = ZbyvaOK - ZapisCelkemOK;

                TempData["ZapisCelkemOK"] = ZapisCelkemOK;
                TempData["ZapisCelkemNOK"] = ZapisCelkemNOK;


                ViewBag.ZapsanychOK = ZapisCelkemOK;
                ViewBag.ZapsanychNOK = ZapisCelkemNOK;

                ViewBag.ZobrazeniZbyvaOK = ZbyvaOK;


                //  var pocetKusu =
                //from pocetKusu_00 in db.ZAKAZKA
                //where pocetKusu_00.ID == id
                //select pocetKusu_00;
                //  foreach (ZAKAZKA pocetKusu_00 in pocetKusu)
                //  {
                //      ViewBag.PocetKusuZobrazeni = pocetKusu_00.PlanovaneMnozstviNa;//pocet kusu na vyrobnim prikazu
                //  }

                ViewBag.ID_ZAKAZKA = new SelectList(db.ZAKAZKA.Include(z => z.SY_STAV).Include(z => z.STROJ)
                               .Where(o => o.SY_STAV.TABULKA == "ZAKAZKA")
                               .Where(o => o.SY_STAV.STAV == 3)
                               .OrderBy(o => o.CisloZakazka), "ID", "CisloZakazka"
                               , id);

            }
            else
            {
                ViewBag.PocetOK = new SelectList(db.ZAKAZKA.Include(z => z.SY_STAV)
.OrderBy(o => o.CisloZakazka), "ID", "CisloZakazka");

                ViewBag.PocetOK_02 = db.ZAKAZKA.Include(z => z.SY_STAV).First();

                ViewBag.ID_ZAKAZKA = new SelectList(db.ZAKAZKA.Include(z => z.SY_STAV).Include(z => z.STROJ)
                               .Where(o => o.SY_STAV.TABULKA == "ZAKAZKA")
                               .Where(o => o.SY_STAV.STAV == 3)
                               .OrderBy(o => o.CisloZakazka), "ID", "CisloZakazka");
            }



            return View();
        }

        [HttpPost]
        public ActionResult ZaznamDoVyrobnihoVykazu([Bind(Include = "ID,ID_M,ID_ZAKAZKA,ID_USER,CasPrace,OK,NOK,Poznamka,TimeStart,TimeEnd,C_USER,C_DATE,M_USER,M_DATE,STAV,STAV_NASLEDUJICI, IsSelected")] VYROBA_ZAZNAM vYROBA_ZAZNAM)
        {
            bool CheckZakazkaUkonceno = false;
            vYROBA_ZAZNAM.ID_USER = User.Identity.GetUserId<int>();
            vYROBA_ZAZNAM.C_USER = User.Identity.GetUserId<int>();
            vYROBA_ZAZNAM.C_DATE = DateTime.Now;
            int CelkemOK = (int)TempData["ZapisCelkemOK"];
            int CelkemNOK = (int)TempData["ZapisCelkemNOK"];
            int idStroj = 0;

            bool? Ceknul = vYROBA_ZAZNAM.IsSelected;

            if (Ceknul != null)
            {
                if (Ceknul == true)
                {
                    CheckZakazkaUkonceno = true;
                }

            }

            int idZakazka_03 = (int)TempData["IdZakazky"];
           


            //pokračovat v logice


            if (ModelState.IsValid)
            {


                var ZakazkaQuery =
                from _ZakazkaQuery in db.ZAKAZKA
                where _ZakazkaQuery.ID == idZakazka_03
                select _ZakazkaQuery;
                foreach (ZAKAZKA _ZakazkaQuery in ZakazkaQuery)
                {
                    idStroj = _ZakazkaQuery.STROJ.ID;

                    var VyrobakIdQuery =
                  from vyrobakIdQuery in db.VYROBA_ZAZNAM
                  where vyrobakIdQuery.ID_ZAKAZKA == idZakazka_03
                  select vyrobakIdQuery;
                    foreach (VYROBA_ZAZNAM vyrobakIdQuery in VyrobakIdQuery)
                    {
                        //našel jsem ID hlavního výrobního výkazu a dělám instanci na zápisy pod ním, tím že dám hlavní výrobák ID do ID_M podvýrobákům
                        vYROBA_ZAZNAM.ID_M = vyrobakIdQuery.ID;

                        if(vYROBA_ZAZNAM.OK !=null)
                        {
                            if(vyrobakIdQuery.OK !=null)
                            {
                                vyrobakIdQuery.OK = vyrobakIdQuery.OK + CelkemOK + vYROBA_ZAZNAM.OK;
                            }
                            vyrobakIdQuery.OK = 0 + CelkemOK + vYROBA_ZAZNAM.OK;

                        }
                        else
                        {
                            if (vyrobakIdQuery.OK != null)
                            {
                                vyrobakIdQuery.OK = vyrobakIdQuery.OK + CelkemOK;
                            }
                            vyrobakIdQuery.OK = 0 + CelkemOK;

                        }
                        if (vYROBA_ZAZNAM.NOK != null)
                        {

                            if (vyrobakIdQuery.NOK != null)
                            {
                                vyrobakIdQuery.NOK = vyrobakIdQuery.NOK + CelkemNOK + vYROBA_ZAZNAM.NOK;
                            }
                            vyrobakIdQuery.NOK = 0 + CelkemNOK + vYROBA_ZAZNAM.NOK;

                            
                        }
                        else
                        {
                            if (vyrobakIdQuery.NOK != null)
                            {
                                vyrobakIdQuery.NOK = vyrobakIdQuery.NOK + CelkemNOK;
                            }
                            vyrobakIdQuery.NOK = 0 + CelkemNOK;

                        }

                        if (CheckZakazkaUkonceno)
                        {

                            //----------------------------------------------------------------------------
                            var StavIdQuery =
                                         from _StavIdQuery in db.SY_STAV
                                         where _StavIdQuery.TABULKA == "VYROBA_ZAZNAM" && _StavIdQuery.STAV == 4
                                         select _StavIdQuery;
                            foreach (SY_STAV _StavIdQuery in StavIdQuery)
                            {


                                vyrobakIdQuery.STAV = _StavIdQuery.ID;

                            }
                            //-----------------------------------------------------------------------------
                            var StavIdQuery_00 =
                                        from _StavIdQuery_00 in db.SY_STAV
                                        where _StavIdQuery_00.TABULKA == "ZAKAZKA" && _StavIdQuery_00.STAV == 4
                                        select _StavIdQuery_00;
                            foreach (SY_STAV _StavIdQuery_00 in StavIdQuery_00)
                            {

                                //Zde můžu dělat změny na záznamu zakázky
                                _ZakazkaQuery.STAV = _StavIdQuery_00.ID;

                            }

                        }
                    }
                }









                db.VYROBA_ZAZNAM.Add(vYROBA_ZAZNAM);
                db.SaveChanges();

                // Submit the changes to the database.
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    // Provide for exceptions.
                }

                return RedirectToAction("DetailLis","Lisovna",new { id= idStroj });

            }

            ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "TABULKA", vYROBA_ZAZNAM.STAV);
            ViewBag.ID_USER = new SelectList(db.USER, "ID", "ZAOR_organizace", vYROBA_ZAZNAM.ID_USER);
            ViewBag.ID_ZAKAZKA = new SelectList(db.ZAKAZKA, "ID", "Oznaceni", vYROBA_ZAZNAM.ID_ZAKAZKA);
            return View(vYROBA_ZAZNAM);
        }

        public ActionResult ArchivUkonceneZakazky(int id_stroj)
        {

            return View();
        }


        //--------------------------------------Záznam do výrobáku START--------------------------------------------------------------------------------------------

        public ActionResult VypisVyrobaku(string sortOrder, string currentFilter, string searchStringDomena, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "domena_desc" : "";
            ViewBag.DateSortParm = sortOrder == "kod" ? "kod_desc" : "kod";

            if (searchStringDomena != null)
            {
                page = 1;
            }
            else
            {
                searchStringDomena = currentFilter;
            }

            ViewBag.CurrentFilter = searchStringDomena;
                        

            var vyroba_zaznam_data = from s in db.VYROBA_ZAZNAM
                                     .Include(s => s.SY_STAV)
                                     .Include(s => s.ZAKAZKA)
                                     .Include(s => s.USER)
                                     .Include(z => z.ZAKAZKA.STROJ)
                                     .Include(z => z.ZAKAZKA.FORMA)
                                     .Include(z => z.ZAKAZKA.SY_STAV)
                                     where s.ID_M == null && s.ID_ZAKAZKA != null
                                     select s;
            if (!String.IsNullOrEmpty(searchStringDomena))
            {
                //    vyroba_zaznam_data = vyroba_zaznam_data.Where(s => s.ZAKAZKA.CisloZakazka.Contains(searchStringDomena)
                //                           || s.POPIS.Contains(searchStringDomena));
            }
            switch (sortOrder)
            {
                case "domena_desc":
                    vyroba_zaznam_data = vyroba_zaznam_data.OrderByDescending(s => s.ZAKAZKA.CisloZakazka);
                    break;
                case "kod":
                    vyroba_zaznam_data = vyroba_zaznam_data.OrderBy(s => s.SY_STAV.STAV);
                    break;
                case "kod_desc":
                    vyroba_zaznam_data = vyroba_zaznam_data.OrderByDescending(s => s.SY_STAV.STAV);
                    break;
                default:
                    vyroba_zaznam_data = vyroba_zaznam_data.OrderBy(s => s.ZAKAZKA.CisloZakazka);
                    break;
            }
            int pageSize = 20;
            int pageNumber = (page ?? 1);

            if (Request.IsAjaxRequest())
            {
                return PartialView(vyroba_zaznam_data.ToPagedList(pageNumber, pageSize));
            }

            return View(vyroba_zaznam_data.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult SeznamVyrobaku(string sortOrder, string currentFilter, string searchStringDomena, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "domena_desc" : "";
            ViewBag.DateSortParm = sortOrder == "kod" ? "kod_desc" : "kod";

            if (searchStringDomena != null)
            {
                page = 1;
            }
            else
            {
                searchStringDomena = currentFilter;
            }

            ViewBag.CurrentFilter = searchStringDomena;

            var vyroba_zaznam_data = from s in db.VYROBA_ZAZNAM.Include(s=> s.SY_STAV).Include(s => s.ZAKAZKA).Include(s => s.USER)
                                     where s.ID_M ==null && s.ID_ZAKAZKA != null && s.SY_STAV.STAV==4
                                     select s;
            if (!String.IsNullOrEmpty(searchStringDomena))
            {
            //    vyroba_zaznam_data = vyroba_zaznam_data.Where(s => s.ZAKAZKA.CisloZakazka.Contains(searchStringDomena)
            //                           || s.POPIS.Contains(searchStringDomena));
            }
            switch (sortOrder)
            {
                case "domena_desc":
                    vyroba_zaznam_data = vyroba_zaznam_data.OrderByDescending(s => s.ZAKAZKA.CisloZakazka);
                    break;
                case "kod":
                    vyroba_zaznam_data = vyroba_zaznam_data.OrderBy(s => s.SY_STAV.STAV);
                    break;
                case "kod_desc":
                    vyroba_zaznam_data = vyroba_zaznam_data.OrderByDescending(s => s.SY_STAV.STAV);
                    break;
                default:
                    vyroba_zaznam_data = vyroba_zaznam_data.OrderBy(s => s.ZAKAZKA.CisloZakazka);
                    break;
            }
            int pageSize = 20;
            int pageNumber = (page ?? 1);

            if (Request.IsAjaxRequest())
            {
                return PartialView(vyroba_zaznam_data.ToPagedList(pageNumber, pageSize));
            }

            return View(vyroba_zaznam_data.ToPagedList(pageNumber, pageSize));
        }



        //---------------------------------- VYROBA_ZAZNAM END------------------------------------------------------------------------------------------

        // GET: UserIN/Lisovna/Details/5
        public ActionResult DetailLis(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //STROJ sTROJ = db.STROJ.Find(id);
            STROJ sTROJ = db.STROJ.Find(id);
            if (sTROJ == null)
            {
                return HttpNotFound();
            }

            int id_zakazka = 0;

            ViewBag.SeznamZakazek = SeznamZakazek(id,2);
            ViewBag.SeznamZakazekNaStroji = SeznamZakazek(id, 3);
            ViewBag.SeznamZakazekOdrobenych = SeznamZakazek(id, 4);
            
            ViewBag.VypisSeznamHlavnichVyrobaku = SeznamHlavnichVyrobaku(id, 4, 4);
            //ViewBag.VypisSeznamHlavnichVyrobaku = SeznamZakazek(id, 4);

            return View(sTROJ);
        }




        // GET: UserIN/Lisovna/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserIN/Lisovna/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserIN/Lisovna/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserIN/Lisovna/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserIN/Lisovna/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserIN/Lisovna/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        //-----------------------------------------------------Stroje START----------------------------------------------------------------------------------------------------

        public ActionResult PrehledStroju()
        {
            var sTROJ = db.STROJ;

            STROJ localStroj;

            //ViewBag.OrganizaceList = new SelectList(db.CISELNIK_DATA, "KOD", "POPIS", localStroj.ZAOR_Organizace);
            //ViewBag.NaklStredList = new SelectList(db.CISELNIK_DATA, "KOD", "POPIS", localStroj.ZANS_NaklStr);
            //ViewBag.TypList = new SelectList(db.CISELNIK_DATA, "KOD", "POPIS", localStroj.ZATS_Typ);
            //ViewBag.VyrobceList = new SelectList(db.CISELNIK_DATA, "KOD", "POPIS", localStroj.ZAVY_Vyrobce);

            //ViewBag.Organizace = db.CISELNIK_DATA.Where(o => o.DOMENA == "ZAOR");
            //ViewBag.NaklStredList = new SelectList(db.CISELNIK_DATA.Where(o => o.DOMENA == "ZANS").OrderBy(o => o.POPIS), "KOD", "POPIS");
            //ViewBag.TypList = new SelectList(db.CISELNIK_DATA.Where(o => o.DOMENA == "ZATS").OrderBy(o => o.POPIS), "KOD", "POPIS");
            //ViewBag.VyrobceList = new SelectList(db.CISELNIK_DATA.Where(o => o.DOMENA == "ZAVY").OrderBy(o => o.POPIS), "KOD", "POPIS");
            return View(sTROJ.ToList());
        }

        public ActionResult DetailStroj(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STROJ sTROJ = db.STROJ.Find(id);
            if (sTROJ == null)
            {
                return HttpNotFound();
            }
            return View(sTROJ);

        }

        // GET: UserIN/STROJ/Create
        public ActionResult CreateStroj()
        {
            //ViewBag.ZAOR_Organizace = new SelectList(db.CISELNIK_DATA.Where(o => o.DOMENA == "ZAOR").OrderBy(o => o.POPIS), "KOD", "POPIS");

            //ViewBag.STAV = new SelectList(db.SY_STAV.Where(o => o.TABULKA == "STROJ").OrderBy(o => o.ID), "ID", "POPIS");
            //ViewBag.STAV = new SelectList(db.SY_STAV.Where(o => o.TABULKA == "STROJ").OrderBy(o => o.ID), "ID", "POPIS");
            ViewBag.STAV = new SelectList(db.SY_STAV.Where(o => o.TABULKA == "STROJ").Where(o => o.STAV == 1), "ID", "POPIS");
            //ViewBag.ZAOR_Organizace = new SelectList(db.CISELNIK_DATA.Where(o => o.DOMENA == "ZAOR").OrderBy(o => o.POPIS), "KOD", "POPIS");
            ViewBag.OrganizaceList = new SelectList(db.CISELNIK_DATA.Where(o => o.DOMENA == "ZAOR").OrderBy(o => o.POPIS), "KOD", "POPIS");
            ViewBag.NaklStredList = new SelectList(db.CISELNIK_DATA.Where(o => o.DOMENA == "ZANS").OrderBy(o => o.POPIS), "KOD", "POPIS");
            ViewBag.TypList = new SelectList(db.CISELNIK_DATA.Where(o => o.DOMENA == "ZATS").OrderBy(o => o.POPIS), "KOD", "POPIS");
            ViewBag.VyrobceList = new SelectList(db.CISELNIK_DATA.Where(o => o.DOMENA == "ZAVY").OrderBy(o => o.POPIS), "KOD", "POPIS");


            return View();
        }

        // POST: UserIN/STROJ/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStroj([Bind(Include = "ID,ZAOR_Organizace,ZANS_NaklStr,ZATS_Typ,ZAVY_Vyrobce,Nazev,Cislo,InventarniCislo,VyrobniCislo,DatumVyroby,DobaChodu,X,Y,DX,DY,STAV,STAV_NASLEDUJICI,C_USER,C_DATE,M_DATE,M_USER")] STROJ sTROJ)
        {
            //SY_STAV sTav = db.SY_STAV.Find(db.SY_STAV.Where(o => o.TABULKA == "STROJ").Where(o => o.STAV == 1));
            sTROJ.C_USER = User.Identity.GetUserId<int>();
            sTROJ.C_DATE = DateTime.Now;
            //sTROJ.STAV = sTav.ID;

            if (ModelState.IsValid)
            {

                //sTROJ.STAV = db.SY_STAV.Where(o => o.TABULKA == "STROJ").Where(o => o.STAV == 1);
                //sTROJ.C_USER= userid;
                db.STROJ.Add(sTROJ);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.STAV = new SelectList(db.SY_STAV.Where(o => o.TABULKA == "STROJ").Where(o => o.STAV == 1), "ID", "POPIS");
            //ViewBag.ZAOR_Organizace = new SelectList(db.CISELNIK_DATA, "KOD", "POPIS", sTROJ.ZAOR_Organizace);
            ViewBag.OrganizaceList = new SelectList(db.CISELNIK_DATA, "KOD", "POPIS", sTROJ.ZAOR_Organizace);
            ViewBag.NaklStredList = new SelectList(db.CISELNIK_DATA, "KOD", "POPIS", sTROJ.ZANS_NaklStr);
            ViewBag.TypList = new SelectList(db.CISELNIK_DATA, "KOD", "POPIS", sTROJ.ZATS_Typ);
            ViewBag.VyrobceList = new SelectList(db.CISELNIK_DATA, "KOD", "POPIS", sTROJ.ZAVY_Vyrobce);
            ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "POPIS", sTROJ.STAV);
            return View(sTROJ);
        }

        // GET: UserIN/STROJ/Edit/5
        public ActionResult EditStroj(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STROJ sTROJ = db.STROJ.Find(id);
            if (sTROJ == null)
            {
                return HttpNotFound();
            }


            ViewBag.C_USER = db.STROJ.Find(id).C_DATE;
            ViewBag.M_USER = db.STROJ.Find(id).M_DATE;

            ViewBag.OrganizaceList = new SelectList(db.CISELNIK_DATA.Where(o => o.DOMENA == "ZAOR").OrderBy(o => o.POPIS), "KOD", "POPIS");
            ViewBag.NaklStredList = new SelectList(db.CISELNIK_DATA.Where(o => o.DOMENA == "ZANS").OrderBy(o => o.POPIS), "KOD", "POPIS");
            ViewBag.TypList = new SelectList(db.CISELNIK_DATA.Where(o => o.DOMENA == "ZATS").OrderBy(o => o.POPIS), "KOD", "POPIS");
            ViewBag.VyrobceList = new SelectList(db.CISELNIK_DATA.Where(o => o.DOMENA == "ZAVY").OrderBy(o => o.POPIS), "KOD", "POPIS");
            ViewBag.STAV = new SelectList(db.SY_STAV.Where(o => o.TABULKA == "STROJ"), "ID", "POPIS");
            return View(sTROJ);
        }

        // POST: UserIN/STROJ/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditStroj([Bind(Include = "ID,ZAOR_Organizace,ZANS_NaklStr,ZATS_Typ,ZAVY_Vyrobce,Nazev,Cislo,InventarniCislo,VyrobniCislo,DatumVyroby,DobaChodu,X,Y,DX,DY,STAV,STAV_NASLEDUJICI,C_DATE,C_USER,M_DATE,M_USER")] STROJ sTROJ)
        {
            //sTROJ.C_DATE = C_DATE;

            //Convert.ToDateTime(sTROJ.DatumVyroby).ToString("dd/MM/yyyy HH:mm:ss");
            //Convert.ToDateTime(sTROJ.C_DATE).ToString("dd/MM/yyyy HH:mm:ss");


            //// Sample 01:
            //Convert.ToDateTime(sTROJ.DatumVyroby).ToString("MM/dd/yyyy HH:mm:ss");

            //// Sample 02:
            //DateTime.Parse(sTROJ.DatumVyroby).ToString("MM/dd/yyyy HH:mm:ss"); //nejede

            //// Sample 03:
            //string.Format("{0:MM/dd/yyyy HH:mm:ss}", DateTime.Parse(sTROJ.DatumVyroby)); //nejede

            if (ModelState.IsValid)
            {
                sTROJ.M_USER = User.Identity.GetUserId<int>();
                sTROJ.M_DATE = DateTime.Now;

                db.Entry(sTROJ).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.C_USER = sTROJ.C_DATE;
            ViewBag.M_USER = sTROJ.M_DATE;
            ViewBag.OrganizaceList = new SelectList(db.CISELNIK_DATA, "KOD", "POPIS", sTROJ.ZAOR_Organizace);
            ViewBag.NaklStredList = new SelectList(db.CISELNIK_DATA, "KOD", "POPIS", sTROJ.ZANS_NaklStr);
            ViewBag.TypList = new SelectList(db.CISELNIK_DATA, "KOD", "POPIS", sTROJ.ZATS_Typ);
            ViewBag.VyrobceList = new SelectList(db.CISELNIK_DATA, "KOD", "POPIS", sTROJ.ZAVY_Vyrobce);
            ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "TABULKA", sTROJ.STAV);
            return View(sTROJ);
        }

        public ActionResult SeznamForem()
        {
            var fORMA = db.FORMA.Include(f => f.SY_STAV);
            return View(fORMA.ToList());
        }


        // GET: UserIN/STROJ/Delete/5
        public ActionResult DeleteStroj(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STROJ sTROJ = db.STROJ.Find(id);
            if (sTROJ == null)
            {
                return HttpNotFound();
            }
            return View(sTROJ);
        }

        // POST: UserIN/STROJ/Delete/5
        [HttpPost, ActionName("DeleteStroj")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedStroj(int id)
        {
            STROJ sTROJ = db.STROJ.Find(id);
            db.STROJ.Remove(sTROJ);
            db.SaveChanges();
            return RedirectToAction("PrehledStroju");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }




        //-----------------------------------------------------Stroje END-----------------------------------------------------------------------------------------------------







        public string StavZarizeni(int IDStroj)
        {
            string barva = "";
            DateTime startDate = DateTime.Now.AddMinutes(-1);
            DateTime endDate = DateTime.Now;
            var chod = db.ESP_LOG.Where(t => t.Time > startDate && t.Time < endDate && t.ID_STROJ == IDStroj && t.Hodnota1 > 0 && t.ID_op ==1).Count();
            var chod2 = db.ESP_LOG.Where(t => t.Time > startDate && t.Time < endDate && t.ID_STROJ == IDStroj && t.Hodnota1 == 0 && t.ID_op == 1).Count();
            if (chod > 0) { barva = "green"; }
            if (chod == 0 && chod2 !=0) { barva = "red"; }
            if (chod == 0 && chod2 == 0) { barva = "grey"; }

            return barva;
        }
        public string CiselnikPopis(string KODstroje)
        {
            string typStroj = "";

            IList<CISELNIK_DATA> KODstroje00 = db.CISELNIK_DATA.Where(t => t.KOD == KODstroje).ToList();
            foreach (CISELNIK_DATA item in KODstroje00)
            {
                typStroj = item.POPIS;
            }

            return typStroj;
        }

        public int StrojRokVyroby(DateTime DatumStroj)
        {
            DateTime rok = DatumStroj;
            int rokVyroby = DatumStroj.Year;
            return rokVyroby;
        }

        public float ChodProcent_oddeleni(DateTime start, DateTime end) //zjištění chodu pro celou výrobu podle zadaných časových údajů
        {
            float vysledek = 0;
            float a = (db.ESP_LOG
                .Where(y => y.Time >= start && y.Time <= end)
                .Where(y => y.Time >= start && y.Time <= end && y.ID_op == 1 && y.Hodnota1 > 0)
                .GroupBy(x => new { x.Time.Value.Hour, x.Time.Value.Day, x.Time.Value.Minute })
                .Select(g => new {
                    Amount = g.Sum(x => x.Hodnota1)
                })).Count();
            float b = (db.ESP_LOG
                .Where(y => y.Time >= start && y.Time <= end && y.Hodnota1 == 0)
                .GroupBy(x => new { x.Time.Value.Hour, x.Time.Value.Day, x.Time.Value.Minute })
                 .Select(g => new
                 {
                     Amount = g.Sum(x => x.Hodnota1)
                 })).Count();
            if (a != 0)
            {
                vysledek = a / b * 100;
            }


            return vysledek;
        }

        public float ChodProcent_stroj(DateTime start, DateTime end, int stroj) //zjištění chodu pro celou výrobu podle zadaných časových údajů
        {
            float vysledek = 0;

            float a = (db.ESP_LOG
                .Where(y => y.Time >= start && y.Time <= end && y.ID_STROJ == stroj)
                .Where(y => y.Time >= start && y.Time <= end && y.ID_STROJ == stroj && y.ID_op == 1 && y.Hodnota1 > 0)
                .GroupBy(x => new { x.Time.Value.Hour, x.Time.Value.Day, x.Time.Value.Minute })
                .Select(g => new
                {
                    Amount = g.Sum(x => x.Hodnota1)
                })).Count();
            float b = (db.ESP_LOG
                .Where(y => y.Time >= start && y.Time <= end && y.Hodnota1 == 0 && y.ID_STROJ == stroj && y.ID_op == 1)
                .GroupBy(x => new { x.Time.Value.Hour, x.Time.Value.Day, x.Time.Value.Minute })
                 .Select(g => new
                 {
                     Amount = g.Sum(x => x.Hodnota1)
                 })).Count();

            if (a != 0)
            {
                vysledek = a / b * 100;
            }


            return vysledek;
        }

        public int PocetTaktu_oddeleni(DateTime start, DateTime end) //zjištění chodu pro celou výrobu podle zadaných časových údajů
        {
            //int b = (db.ESP_LOG
            //    .Where(y => y.Time >= start && y.Time <= end && y.ID_op == 1)
            //    //.GroupBy(x => new { x.Time.Value.Hour, x.Time.Value.Day, x.Time.Value.Minute })
            //    .Select(y => Convert.ToInt32(y.Hodnota1))).Sum();

            var b = (db.ESP_LOG
                .Where(y => y.Time >= start && y.Time <= end && y.ID_op == 1)
                //.GroupBy(x => new { x.Time.Value.Hour, x.Time.Value.Day, x.Time.Value.Minute })
                .Select(y => y.Hodnota1)).Sum();

            return Convert.ToInt32(b);
        }



        public int PocetTaktu_stroj(DateTime start, DateTime end, int stroj) //zjištění chodu pro celou výrobu podle zadaných časových údajů
        {
            var b = (db.ESP_LOG
                .Where(y => y.Time >= start && y.Time <= end && y.ID_op == 1 && y.ID_STROJ == stroj)
                //.GroupBy(x => new { x.Time.Value.Hour, x.Time.Value.Day, x.Time.Value.Minute })
                .Select(y => y.Hodnota1)).Sum();

            return Convert.ToInt32(b);

        }

        public string JmenoPrijmeni(int id_C_USER)
        {
            string jmeno = "";
            var JmenoPrijmeniQuery =
              from _JmenoPrijmeniQuery in db.USER
              where _JmenoPrijmeniQuery.ID == id_C_USER
              select _JmenoPrijmeniQuery;
            foreach (USER _JmenoPrijmeniQuery in JmenoPrijmeniQuery)
            {
                jmeno = _JmenoPrijmeniQuery.Jmeno + " " + _JmenoPrijmeniQuery.Prijmeni;
            }
            return jmeno;
        }


        public ICollection<ZAKAZKA> SeznamZakazek (int ID_stroj, int stav)
        {
            return db.ZAKAZKA.Include(z => z.FORMA).Include(z => z.SY_STAV)
                .Where(z => z.SY_STAV.TABULKA == "ZAKAZKA")
                .Where(z => z.SY_STAV.STAV == stav)
                .Where(z => z.ID_STROJ == ID_stroj).ToList();
        }

        public ActionResult DetailVyrobaku(int id_zakazka)
        {
            int idHlavniVyrobak = 0;
            var VyrobakQuery =
               from _VyrobakQuery in db.VYROBA_ZAZNAM.Include(v=>v.ZAKAZKA)
               .Include(v => v.ZAKAZKA.STROJ)
               where _VyrobakQuery.ID_ZAKAZKA == id_zakazka
               select _VyrobakQuery;

            foreach (VYROBA_ZAZNAM _VyrobakQuery in VyrobakQuery)
            {
                if(_VyrobakQuery!=null)
                {
                    idHlavniVyrobak = _VyrobakQuery.ID;

                    ViewBag.ZobrazeniCelkemOK = _VyrobakQuery.OK;

                    ViewBag.ZobrazeniCelkemNOK = _VyrobakQuery.NOK;
                    ViewBag.ZobrazeniCisloZakazka = _VyrobakQuery.ZAKAZKA.CisloZakazka;
                    ViewBag.ZobrazeniSTROJ = _VyrobakQuery.ZAKAZKA.STROJ.Nazev+" "+ _VyrobakQuery.ZAKAZKA.STROJ.Cislo;
                }
            }


                var VyrobakZaznam = db.VYROBA_ZAZNAM
                .Include(v=>v.USER)
                .Where(v => v.ID_M == idHlavniVyrobak)
                .ToList();

            return View(VyrobakZaznam);
        }

        public ICollection<VYROBA_ZAZNAM> SeznamHlavnichVyrobaku(int ID_stroj, int stav, int stav_zakazka)
        {
            //return db.ZAKAZKA.Include(z => z.FORMA).Include(z => z.SY_STAV)
            //    .Where(z => z.SY_STAV.TABULKA == "ZAKAZKA")
            //    .Where(z => z.SY_STAV.STAV == stav)
            //    .Where(z => z.ID_STROJ == ID_stroj).ToList();

            ICollection<VYROBA_ZAZNAM> kolekceZaznamu =    db.VYROBA_ZAZNAM
                .Include(z => z.ZAKAZKA)
                .Include(z => z.SY_STAV).Include(z => z.USER)
                .Include(z => z.ZAKAZKA.STROJ)
                .Include(z => z.ZAKAZKA.FORMA)
                .Include(z => z.ZAKAZKA.SY_STAV)
                .Where(z => z.SY_STAV.STAV == stav)
                .Where(z => z.ID_M == null)
                .Where(z => z.OK != null)
                .Where(z => z.ZAKAZKA.SY_STAV.STAV == stav_zakazka)
                .Where(z => z.ZAKAZKA.ID_STROJ == ID_stroj).ToList();
            

            return kolekceZaznamu;
        }



        public ActionResult VPZakazkaSeznam(string sortOrder, string currentFilter, string searchStringSTAV, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "stav_desc" : "";
            ViewBag.DateSortParm = sortOrder == "stroj" ? "stroj_desc" : "stroj";

            if (searchStringSTAV != null)
            {
                page = 1;
            }
            else
            {
                searchStringSTAV = currentFilter;
            }

            ViewBag.CurrentFilter = searchStringSTAV;

            var zakazka_data = from s in db.ZAKAZKA.Include(z => z.SY_STAV).Include(z => z.STROJ)
                               where (s.SY_STAV.TABULKA == "ZAKAZKA" && s.SY_STAV.STAV == 4 && s.STROJ.ZAOR_Organizace == "LIS")


                               select s;
            if (!String.IsNullOrEmpty(searchStringSTAV))
            {
                zakazka_data = zakazka_data.Where(s => s.CisloZakazka.Equals(searchStringSTAV)
                                       || s.SY_STAV.STAV.Equals(searchStringSTAV));
            }
            switch (sortOrder)
            {
                case "stav_desc":
                    zakazka_data = zakazka_data.OrderByDescending(s => s.SY_STAV.STAV);
                    break;
                case "stroj":
                    zakazka_data = zakazka_data.OrderBy(s => s.STROJ.Cislo);
                    break;
                case "stroj_desc":
                    zakazka_data = zakazka_data.OrderByDescending(s => s.STROJ.Cislo);
                    break;
                default:
                    zakazka_data = zakazka_data.OrderBy(s => s.SY_STAV.STAV);
                    break;
            }
            int pageSize = 20;
            int pageNumber = (page ?? 1);

            if (Request.IsAjaxRequest())
            {
                return PartialView(zakazka_data.ToPagedList(pageNumber, pageSize));
            }

            return View(zakazka_data.ToPagedList(pageNumber, pageSize));


            //var zAKAZKA = db.ZAKAZKA.Include(z => z.FORMA).Include(z => z.STROJ).Include(z => z.SY_STAV);
            //return View(zAKAZKA.ToList());

        }
        public ActionResult VPZakazkaSeznam_00(int? id_zakazka)
        {
            int id_stroj = 0;
            if (id_zakazka != null && id_zakazka!=0)
            {

                var ZakazkaQuery =
                from _ZakazkaQuery in db.ZAKAZKA.Include(z=>z.STROJ).Include(z => z.SY_STAV)
                where _ZakazkaQuery.ID == id_zakazka
                select _ZakazkaQuery;
                foreach (ZAKAZKA _ZakazkaQuery in ZakazkaQuery)
                {
                    id_stroj = _ZakazkaQuery.STROJ.ID;
                    var VyrobakQuery =
               from _VyrobakQuery in db.VYROBA_ZAZNAM.Include(z => z.ZAKAZKA).Include(z => z.SY_STAV)
               where _VyrobakQuery.ID_ZAKAZKA == id_zakazka
               select _VyrobakQuery;
                    foreach (VYROBA_ZAZNAM _VyrobakQuery in VyrobakQuery)
                    {


                        var StavIdQuery =
                                        from _StavIdQuery in db.SY_STAV
                                        where _StavIdQuery.TABULKA == "ZAKAZKA" && _StavIdQuery.STAV == 5
                                        select _StavIdQuery;
                        foreach (SY_STAV _StavIdQuery in StavIdQuery)
                        {

                            //Zde můžu dělat změny na záznamu zakázky
                            _ZakazkaQuery.STAV = _StavIdQuery.ID;

                        }
                        var StavIdQuery_00 =
                                            from _StavIdQuery_00 in db.SY_STAV
                                            where _StavIdQuery_00.TABULKA == "VYROBA_ZAZNAM" && _StavIdQuery_00.STAV == 5
                                            select _StavIdQuery_00;
                        foreach (SY_STAV _StavIdQuery_00 in StavIdQuery_00)
                        {

                            //Zde můžu dělat změny na záznamu zakázky
                            _VyrobakQuery.STAV = _StavIdQuery_00.ID;

                        }
                    }

                }
                db.SaveChanges();
                return RedirectToAction("DetailLis", "Lisovna", new { id = id_stroj });
            }
            else
            {
                return RedirectToAction("Index", "Lisovna");
            }
           
        }




        public ActionResult ZaznamSAP(int? id_zakazka)
        {
            int id_stroj = 0;
            if (id_zakazka != null && id_zakazka != 0)
            {

                var ZakazkaQuery =
                from _ZakazkaQuery in db.ZAKAZKA.Include(z => z.STROJ).Include(z => z.SY_STAV)
                where _ZakazkaQuery.ID == id_zakazka
                select _ZakazkaQuery;
                foreach (ZAKAZKA _ZakazkaQuery in ZakazkaQuery)
                {
                    id_stroj = _ZakazkaQuery.STROJ.ID;
                    var VyrobakQuery =
               from _VyrobakQuery in db.VYROBA_ZAZNAM.Include(z => z.ZAKAZKA).Include(z => z.SY_STAV)
               where _VyrobakQuery.ID_ZAKAZKA == id_zakazka
               select _VyrobakQuery;
                    foreach (VYROBA_ZAZNAM _VyrobakQuery in VyrobakQuery)
                    {


                        var StavIdQuery =
                                        from _StavIdQuery in db.SY_STAV
                                        where _StavIdQuery.TABULKA == "ZAKAZKA" && _StavIdQuery.STAV == 5
                                        select _StavIdQuery;
                        foreach (SY_STAV _StavIdQuery in StavIdQuery)
                        {

                            //Zde můžu dělat změny na záznamu zakázky
                            _ZakazkaQuery.STAV = _StavIdQuery.ID;

                        }
                        var StavIdQuery_00 =
                                            from _StavIdQuery_00 in db.SY_STAV
                                            where _StavIdQuery_00.TABULKA == "VYROBA_ZAZNAM" && _StavIdQuery_00.STAV == 5
                                            select _StavIdQuery_00;
                        foreach (SY_STAV _StavIdQuery_00 in StavIdQuery_00)
                        {

                            //Zde můžu dělat změny na záznamu zakázky
                            _VyrobakQuery.STAV = _StavIdQuery_00.ID;

                        }
                    }

                }
                db.SaveChanges();
                return RedirectToAction("SeznamVyrobaku", "Lisovna");
            }
            else
            {
                return RedirectToAction("Index", "Lisovna");
            }

        }

    }












}

