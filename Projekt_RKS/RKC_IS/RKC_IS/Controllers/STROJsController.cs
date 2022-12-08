using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RKC_IS.DataAccess.Model;

namespace RKC_IS.Controllers
{
    public class STROJsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: STROJs
        public ActionResult Index()
        {
            return View(db.STROJ.ToList());
        }

        // GET: STROJs/Details/5
        public ActionResult Details(int? id)
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

        // GET: STROJs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: STROJs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ZAOR_Organizace,ZANS_NaklStr,ZATS_Typ,ZAVY_Vyrobce,Nazev,Cislo,InventarniCislo,VyrobniCislo,DatumVyroby,DobaChodu,X,Y,DX,DY,STAV,STAV_NASLEDUJICI,C_USER,C_DATE,M_DATE,M_USER")] STROJ sTROJ)
        {
            if (ModelState.IsValid)
            {
                db.STROJ.Add(sTROJ);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sTROJ);
        }

        // GET: STROJs/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: STROJs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ZAOR_Organizace,ZANS_NaklStr,ZATS_Typ,ZAVY_Vyrobce,Nazev,Cislo,InventarniCislo,VyrobniCislo,DatumVyroby,DobaChodu,X,Y,DX,DY,STAV,STAV_NASLEDUJICI,C_USER,C_DATE,M_DATE,M_USER")] STROJ sTROJ)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTROJ).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sTROJ);
        }

        // GET: STROJs/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: STROJs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            STROJ sTROJ = db.STROJ.Find(id);
            db.STROJ.Remove(sTROJ);
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
