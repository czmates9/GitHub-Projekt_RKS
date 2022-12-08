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
    public class FORMAController : Controller
    {
        private ConnectionMap_RKC_Database db = new ConnectionMap_RKC_Database();

        // GET: UserIN/FORMA
        public ActionResult Index()
        {
            var fORMA = db.FORMA.Include(f => f.SY_STAV);
            return View(fORMA.ToList());
        }

        // GET: UserIN/FORMA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FORMA fORMA = db.FORMA.Find(id);
            if (fORMA == null)
            {
                return HttpNotFound();
            }
            return View(fORMA);
        }

        // GET: UserIN/FORMA/Create
        public ActionResult Create()
        {
            ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "TABULKA");
            return View();
        }

        // POST: UserIN/FORMA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ZAFO_Forma,ZAVY_Vyrobce,PocetKavit,CyklusCas,RokVyroby,Umisteni,Hmotnost,DatumZadani,STAV,STAV_NASLEDUJICI,C_USER,C_DATE,M_USER,M_DATE,PocetVP")] FORMA fORMA)
        {
            if (ModelState.IsValid)
            {
                db.FORMA.Add(fORMA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "TABULKA", fORMA.STAV);
            return View(fORMA);
        }

        // GET: UserIN/FORMA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FORMA fORMA = db.FORMA.Find(id);
            if (fORMA == null)
            {
                return HttpNotFound();
            }
            ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "TABULKA", fORMA.STAV);
            return View(fORMA);
        }

        // POST: UserIN/FORMA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ZAFO_Forma,ZAVY_Vyrobce,PocetKavit,CyklusCas,RokVyroby,Umisteni,Hmotnost,DatumZadani,STAV,STAV_NASLEDUJICI,C_USER,C_DATE,M_USER,M_DATE,PocetVP")] FORMA fORMA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fORMA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "TABULKA", fORMA.STAV);
            return View(fORMA);
        }

        // GET: UserIN/FORMA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FORMA fORMA = db.FORMA.Find(id);
            if (fORMA == null)
            {
                return HttpNotFound();
            }
            return View(fORMA);
        }

        // POST: UserIN/FORMA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FORMA fORMA = db.FORMA.Find(id);
            db.FORMA.Remove(fORMA);
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
