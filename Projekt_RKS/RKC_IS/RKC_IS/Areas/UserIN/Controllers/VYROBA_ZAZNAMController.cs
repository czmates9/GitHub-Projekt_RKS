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
    public class VYROBA_ZAZNAMController : Controller
    {
        private ConnectionMap_RKC_Database db = new ConnectionMap_RKC_Database();

        // GET: UserIN/VYROBA_ZAZNAM
        public ActionResult Index()
        {
            var vYROBA_ZAZNAM = db.VYROBA_ZAZNAM.Include(v => v.SY_STAV).Include(v => v.USER).Include(v => v.ZAKAZKA).Include(v => v.VYROBA_ZAZNAM2);
            return View(vYROBA_ZAZNAM.ToList());
        }

        // GET: UserIN/VYROBA_ZAZNAM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VYROBA_ZAZNAM vYROBA_ZAZNAM = db.VYROBA_ZAZNAM.Find(id);
            if (vYROBA_ZAZNAM == null)
            {
                return HttpNotFound();
            }
            return View(vYROBA_ZAZNAM);
        }

        // GET: UserIN/VYROBA_ZAZNAM/Create
        public ActionResult Create()
        {
            ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "TABULKA");
            ViewBag.ID_USER = new SelectList(db.USER, "ID", "ZAOR_organizace");
            ViewBag.ID_ZAKAZKA = new SelectList(db.ZAKAZKA, "ID", "Oznaceni");
            ViewBag.ID_M = new SelectList(db.VYROBA_ZAZNAM, "ID", "Poznamka");
            return View();
        }

        // POST: UserIN/VYROBA_ZAZNAM/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_M,ID_ZAKAZKA,ID_USER,CasPrace,OK,NOK,Poznamka,TimeStart,TimeEnd,C_USER,C_DATE,M_USER,M_DATE,STAV,STAV_NASLEDUJICI")] VYROBA_ZAZNAM vYROBA_ZAZNAM)
        {
            if (ModelState.IsValid)
            {
                db.VYROBA_ZAZNAM.Add(vYROBA_ZAZNAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "TABULKA", vYROBA_ZAZNAM.STAV);
            ViewBag.ID_USER = new SelectList(db.USER, "ID", "ZAOR_organizace", vYROBA_ZAZNAM.ID_USER);
            ViewBag.ID_ZAKAZKA = new SelectList(db.ZAKAZKA, "ID", "Oznaceni", vYROBA_ZAZNAM.ID_ZAKAZKA);
            ViewBag.ID_M = new SelectList(db.VYROBA_ZAZNAM, "ID", "Poznamka", vYROBA_ZAZNAM.ID_M);
            return View(vYROBA_ZAZNAM);
        }

        // GET: UserIN/VYROBA_ZAZNAM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VYROBA_ZAZNAM vYROBA_ZAZNAM = db.VYROBA_ZAZNAM.Find(id);
            if (vYROBA_ZAZNAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "TABULKA", vYROBA_ZAZNAM.STAV);
            ViewBag.ID_USER = new SelectList(db.USER, "ID", "ZAOR_organizace", vYROBA_ZAZNAM.ID_USER);
            ViewBag.ID_ZAKAZKA = new SelectList(db.ZAKAZKA, "ID", "Oznaceni", vYROBA_ZAZNAM.ID_ZAKAZKA);
            ViewBag.ID_M = new SelectList(db.VYROBA_ZAZNAM, "ID", "Poznamka", vYROBA_ZAZNAM.ID_M);
            return View(vYROBA_ZAZNAM);
        }

        // POST: UserIN/VYROBA_ZAZNAM/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_M,ID_ZAKAZKA,ID_USER,CasPrace,OK,NOK,Poznamka,TimeStart,TimeEnd,C_USER,C_DATE,M_USER,M_DATE,STAV,STAV_NASLEDUJICI")] VYROBA_ZAZNAM vYROBA_ZAZNAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vYROBA_ZAZNAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "TABULKA", vYROBA_ZAZNAM.STAV);
            ViewBag.ID_USER = new SelectList(db.USER, "ID", "ZAOR_organizace", vYROBA_ZAZNAM.ID_USER);
            ViewBag.ID_ZAKAZKA = new SelectList(db.ZAKAZKA, "ID", "Oznaceni", vYROBA_ZAZNAM.ID_ZAKAZKA);
            ViewBag.ID_M = new SelectList(db.VYROBA_ZAZNAM, "ID", "Poznamka", vYROBA_ZAZNAM.ID_M);
            return View(vYROBA_ZAZNAM);
        }

        // GET: UserIN/VYROBA_ZAZNAM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VYROBA_ZAZNAM vYROBA_ZAZNAM = db.VYROBA_ZAZNAM.Find(id);
            if (vYROBA_ZAZNAM == null)
            {
                return HttpNotFound();
            }
            return View(vYROBA_ZAZNAM);
        }

        // POST: UserIN/VYROBA_ZAZNAM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VYROBA_ZAZNAM vYROBA_ZAZNAM = db.VYROBA_ZAZNAM.Find(id);
            db.VYROBA_ZAZNAM.Remove(vYROBA_ZAZNAM);
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
