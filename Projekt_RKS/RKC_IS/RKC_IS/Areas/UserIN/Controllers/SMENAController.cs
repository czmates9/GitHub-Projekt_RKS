using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RKC_IS.DataAccess.Model.AutoMapping;

namespace RKC_IS.Areas.UserIN.Controllers
{
    public class SMENAController : Controller
    {
        private ConnectionMap_RKC_Database db = new ConnectionMap_RKC_Database();

        // GET: UserIN/SMENA
        public ActionResult Index()
        {
            return View(db.SMENA.ToList());
        }

        // GET: UserIN/SMENA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMENA sMENA = db.SMENA.Find(id);
            if (sMENA == null)
            {
                return HttpNotFound();
            }
            return View(sMENA);
        }

        // GET: UserIN/SMENA/Create
        public ActionResult Create()
        {
            ViewBag.OrganizaceList = new SelectList(db.CISELNIK_DATA.Where(o => o.DOMENA == "ZAOR").OrderBy(o => o.POPIS), "KOD", "POPIS");
            ViewBag.DruhSmenaList = new SelectList(db.CISELNIK_DATA.Where(o => o.DOMENA == "ZADS").OrderBy(o => o.POPIS), "KOD", "POPIS");
            return View();
        }

        // POST: UserIN/SMENA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ZAOR_Organizace,ZADS_DruhSmena,Cas")] SMENA sMENA)
        {
            if (ModelState.IsValid)
            {
                db.SMENA.Add(sMENA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrganizaceList = new SelectList(db.CISELNIK_DATA, "KOD", "POPIS", sMENA.ZAOR_Organizace);
            ViewBag.DruhSmenaList = new SelectList(db.CISELNIK_DATA, "KOD", "POPIS", sMENA.ZADS_DruhSmena);

            return View(sMENA);
        }

        // GET: UserIN/SMENA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMENA sMENA = db.SMENA.Find(id);
            if (sMENA == null)
            {
                return HttpNotFound();
            }
            return View(sMENA);
        }

        // POST: UserIN/SMENA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ZAOR_Organizace,ZADS_DruhSmena,Cas")] SMENA sMENA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sMENA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sMENA);
        }

        // GET: UserIN/SMENA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMENA sMENA = db.SMENA.Find(id);
            if (sMENA == null)
            {
                return HttpNotFound();
            }
            return View(sMENA);
        }

        // POST: UserIN/SMENA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SMENA sMENA = db.SMENA.Find(id);
            db.SMENA.Remove(sMENA);
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
