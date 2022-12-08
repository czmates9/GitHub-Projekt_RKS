using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RKC_IS.DataAccess.Model.AutoMapping;
using PagedList;

namespace RKC_IS.Areas.UserIN.Controllers
{
    public class ZAKAZKAController : Controller
    {
        private ConnectionMap_RKC_Database db = new ConnectionMap_RKC_Database();

        // GET: UserIN/ZAKAZKA
        public ActionResult Index(string sortOrder, string currentFilter, string searchStringSTAV, int? page)
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

        // GET: UserIN/ZAKAZKA/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZAKAZKA zAKAZKA = db.ZAKAZKA.Find(id);
            if (zAKAZKA == null)
            {
                return HttpNotFound();
            }
            return View(zAKAZKA);
        }

        // GET: UserIN/ZAKAZKA/Create
        public ActionResult Create()
        {
            ViewBag.ID_FORMA = new SelectList(db.FORMA, "ID", "ZAFO_Forma");
            ViewBag.ID_STROJ = new SelectList(db.STROJ, "ID", "ZAOR_Organizace");
            ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "TABULKA");
            return View();
        }

        // POST: UserIN/ZAKAZKA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_STROJ,ID_FORMA,CisloZakazka,Oznaceni,NazevProces,PlanovaneMnozstviNa,VyrobenoZahlaseno,ZbyvajiciMnozstvi,Hodnota,KonecnyT,DatumNasazeni,Pos,Nasobnost,CyklusCas,DobaPriprava,DobaVyroba,DobaPripravaVyroba,Priorita,PoznamkaNaVP,DelkaVymeny,CyklusCasReal,DatumUkonceni,ZahlaseneMnozstvi,ZaskladneneMnozstvi,C_USER,C_DATE,M_USER,M_DATE,STAV,STAV_NASLEDUJICI")] ZAKAZKA zAKAZKA)
        {
            if (ModelState.IsValid)
            {
                db.ZAKAZKA.Add(zAKAZKA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_FORMA = new SelectList(db.FORMA, "ID", "ZAFO_Forma", zAKAZKA.ID_FORMA);
            ViewBag.ID_STROJ = new SelectList(db.STROJ, "ID", "ZAOR_Organizace", zAKAZKA.ID_STROJ);
            ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "TABULKA", zAKAZKA.STAV);
            return View(zAKAZKA);
        }

        // GET: UserIN/ZAKAZKA/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZAKAZKA zAKAZKA = db.ZAKAZKA.Find(id);
            if (zAKAZKA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_FORMA = new SelectList(db.FORMA, "ID", "ZAFO_Forma", zAKAZKA.ID_FORMA);
            ViewBag.ID_STROJ = new SelectList(db.STROJ, "ID", "ZAOR_Organizace", zAKAZKA.ID_STROJ);
            ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "TABULKA", zAKAZKA.STAV);
            return View(zAKAZKA);
        }

        // POST: UserIN/ZAKAZKA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_STROJ,ID_FORMA,CisloZakazka,Oznaceni,NazevProces,PlanovaneMnozstviNa,VyrobenoZahlaseno,ZbyvajiciMnozstvi,Hodnota,KonecnyT,DatumNasazeni,Pos,Nasobnost,CyklusCas,DobaPriprava,DobaVyroba,DobaPripravaVyroba,Priorita,PoznamkaNaVP,DelkaVymeny,CyklusCasReal,DatumUkonceni,ZahlaseneMnozstvi,ZaskladneneMnozstvi,C_USER,C_DATE,M_USER,M_DATE,STAV,STAV_NASLEDUJICI")] ZAKAZKA zAKAZKA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zAKAZKA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_FORMA = new SelectList(db.FORMA, "ID", "ZAFO_Forma", zAKAZKA.ID_FORMA);
            ViewBag.ID_STROJ = new SelectList(db.STROJ, "ID", "ZAOR_Organizace", zAKAZKA.ID_STROJ);
            ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "TABULKA", zAKAZKA.STAV);
            return View(zAKAZKA);
        }

        // GET: UserIN/ZAKAZKA/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZAKAZKA zAKAZKA = db.ZAKAZKA.Find(id);
            if (zAKAZKA == null)
            {
                return HttpNotFound();
            }
            return View(zAKAZKA);
        }

        // POST: UserIN/ZAKAZKA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ZAKAZKA zAKAZKA = db.ZAKAZKA.Find(id);
            db.ZAKAZKA.Remove(zAKAZKA);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
