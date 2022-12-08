using RKC_IS.DataAccess.Model.AutoMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace RKC_IS.Areas.UserIN.Controllers
{[Authorize]
    public class HomeController : Controller
    {

        private ConnectionMap_RKC_Database db = new ConnectionMap_RKC_Database();

        // GET: UserIN/Home
        public ActionResult Index()
        {
            return View();
        }


        [Authorize(Roles ="admin,mistr")]
        public ActionResult PlanSmena(string umisteni)
        {
            int pocetStroju = 0;
            int pocetOperatoru = 0;

            //ladění metody START

           string umisteni_0 = "LIS";
            //ladění metody END


            //Vytvoření výběru uživatel na základě role ---> role=="operator" & "ZAOR_Organizace"  ---> naplní se list User operátorů z lisovny
            //potřeba to najoinovat na roli ---> vyhledat jak na to
            ViewBag.ListUzivatel = new SelectList(db.USER.Where(o => o.ZAOR_organizace == "LIS").OrderBy(o => o.ID), "ID", "Jmeno");
            
            
            ViewBag.ListStroj = new SelectList(db.STROJ.Where(o => o.ZAOR_Organizace == umisteni_0).OrderBy(o => o.ID), "KOD", "POPIS");
            ViewBag.listSmen = new SelectList(db.SMENA, "ID", "ZADS_DruhSmena");

            return View();
        }

        public int pocetOperatoru(string kod)
        {
            return 0;
        }

        public int pocetStroju(string kod)
        {
            return 0;
        }
    }
}