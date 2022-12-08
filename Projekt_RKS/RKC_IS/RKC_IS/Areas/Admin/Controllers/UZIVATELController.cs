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

namespace RKC_IS.Areas.Admin.Controllers
{
    public class UZIVATELController : Controller
    {
        private ConnectionMap_RKC_Database db = new ConnectionMap_RKC_Database();

        // GET: Admin/UZIVATEL
        //public ActionResult Index()
        //{
        //    var uSER = db.USER.Include(u => u.SY_STAV);
        //    return View(uSER.ToList());
        //}


        //------přidáno-----------------
        public ActionResult Index(string sortOrder, string currentFilter, string searchStringJmeno, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "jmeno_desc" : "";
            ViewBag.DateSortParm = sortOrder == "prijmeni" ? "prijmeni_desc" : "prijmeni";

            if (searchStringJmeno != null)
            {
                page = 1;
            }
            else
            {
                searchStringJmeno = currentFilter;
            }

            ViewBag.CurrentFilter = searchStringJmeno;

            var uzivatel_data = from s in db.USER.Include(u => u.SY_STAV)
                                select s;
            if (!String.IsNullOrEmpty(searchStringJmeno))
            {
                uzivatel_data = uzivatel_data.Where(s => s.Jmeno.Contains(searchStringJmeno)
                                       || s.Prijmeni.Contains(searchStringJmeno));
            }
            switch (sortOrder)
            {
                case "jmeno_desc":
                    uzivatel_data = uzivatel_data.OrderByDescending(s => s.Jmeno);
                    break;
                case "prijmeni":
                    uzivatel_data = uzivatel_data.OrderBy(s => s.Prijmeni);
                    break;
                case "prijmeni_desc":
                    uzivatel_data = uzivatel_data.OrderByDescending(s => s.Prijmeni);
                    break;
                default:
                    uzivatel_data = uzivatel_data.OrderBy(s => s.Jmeno);
                    break;
            }
            int pageSize = 20;
            int pageNumber = (page ?? 1);

            if (Request.IsAjaxRequest())
            {
                return PartialView(uzivatel_data.ToPagedList(pageNumber, pageSize));
            }

            return View(uzivatel_data.ToPagedList(pageNumber, pageSize));
        }

        public string CiselnikPopis(string _kod)
        {
            string promennna = "";

            IList<CISELNIK_DATA> kodQuery = db.CISELNIK_DATA.Where(t => t.KOD == _kod).ToList();
            foreach (CISELNIK_DATA item in kodQuery)
            {
                promennna = item.POPIS;
            }

            return promennna;
        }

        // GET: Admin/UZIVATEL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USER uSER = db.USER.Find(id);
            if (uSER == null)
            {
                return HttpNotFound();
            }
            return View(uSER);
        }

        // GET: Admin/UZIVATEL/Create
        public ActionResult Create()
        {
            ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "TABULKA");
            return View();
        }

        // POST: Admin/UZIVATEL/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ZAOR_organizace,Jmeno,Prijmeni,OsobniCislo,PhoneNumber,Obec,Ulice,CisloDomu,PSC,DatumNastup,PlatovaTrida,Smena,CasPrihlaseni,C_USER,M_USER,C_DATE,M_DATE,UserName,PasswordHash,Email,STAV,STAV_NASLEDUJICI,EmailConfirmed,SecurityStamp,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,IsConfirmed,PasswordQuestion,PasswordAnswer,ActivationToken")] USER uSER)
        {
            if (ModelState.IsValid)
            {
                db.USER.Add(uSER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "TABULKA", uSER.STAV);
            return View(uSER);
        }

        // GET: Admin/UZIVATEL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USER uSER = db.USER.Find(id);
            if (uSER == null)
            {
                return HttpNotFound();
            }
            ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "TABULKA", uSER.STAV);
            return View(uSER);
        }

        // POST: Admin/UZIVATEL/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ZAOR_organizace,Jmeno,Prijmeni,OsobniCislo,PhoneNumber,Obec,Ulice,CisloDomu,PSC,DatumNastup,PlatovaTrida,Smena,CasPrihlaseni,C_USER,M_USER,C_DATE,M_DATE,UserName,PasswordHash,Email,STAV,STAV_NASLEDUJICI,EmailConfirmed,SecurityStamp,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,IsConfirmed,PasswordQuestion,PasswordAnswer,ActivationToken")] USER uSER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "TABULKA", uSER.STAV);
            return View(uSER);
        }

        // GET: Admin/UZIVATEL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USER uSER = db.USER.Find(id);
            if (uSER == null)
            {
                return HttpNotFound();
            }
            return View(uSER);
        }

        // POST: Admin/UZIVATEL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USER uSER = db.USER.Find(id);
            db.USER.Remove(uSER);
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
