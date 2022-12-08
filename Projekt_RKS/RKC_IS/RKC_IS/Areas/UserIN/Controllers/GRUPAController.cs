using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RKC_IS.DataAccess.Model.AutoMapping;
using Microsoft.AspNet.Identity;

namespace RKC_IS.Areas.UserIN.Controllers
{
    public class GRUPAController : Controller
    {
        private ConnectionMap_RKC_Database db = new ConnectionMap_RKC_Database();

        // GET: UserIN/GRUPA
        public ActionResult Index()
        {
            var gRUPA = db.GRUPA.Include(g => g.SMENA).Include(g => g.SY_STAV);
            return View(gRUPA.ToList());
        }

        // GET: UserIN/GRUPA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GRUPA gRUPA = db.GRUPA.Find(id);
            if (gRUPA == null)
            {
                return HttpNotFound();
            }
            return View(gRUPA);
        }

        // GET: UserIN/GRUPA/Create
        public ActionResult Create()
        {
            ViewBag.ID_SMENA = new SelectList(db.SMENA, "ID", "ZADS_DruhSmena");
            ViewBag.STAV = new SelectList(db.SY_STAV.Where(o => o.TABULKA == "GRUPA").Where(o => o.STAV == 1), "ID", "POPIS");
            ViewBag.TypGrupaList = new SelectList(db.CISELNIK_DATA.Where(o => o.DOMENA == "ZATG").OrderBy(o => o.POPIS), "KOD", "POPIS");
            return View();
        }

        // POST: UserIN/GRUPA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nazev,ID_SMENA,ZATG_TypGrupa,C_USER,C_DATE,M_USER,M_DATE,STAV,STAV_NASLEDUJICI")] GRUPA gRUPA)
        {
            if(gRUPA.ZATG_TypGrupa == "--Vyber--")
            { gRUPA.ZATG_TypGrupa = null; }

            gRUPA.C_USER = User.Identity.GetUserId<int>();
            gRUPA.C_DATE = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.GRUPA.Add(gRUPA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TypGrupaList = new SelectList(db.CISELNIK_DATA, "KOD", "POPIS", gRUPA.ZATG_TypGrupa);
            ViewBag.ID_SMENA = new SelectList(db.SMENA, "ID", "ZADS_DruhSmena", gRUPA.ID_SMENA);
            ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "POPIS", gRUPA.STAV);
            return View(gRUPA);
        }

        // GET: UserIN/GRUPA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GRUPA gRUPA = db.GRUPA.Find(id);
            if (gRUPA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_SMENA = new SelectList(db.SMENA, "ID", "ZAOR_Organizace", gRUPA.ID_SMENA);
            ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "TABULKA", gRUPA.STAV);
            return View(gRUPA);
        }

        // POST: UserIN/GRUPA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_SMENA,ZATG_TypGrupa,C_USER,C_DATE,M_USER,M_DATE,STAV,STAV_NASLEDUJICI")] GRUPA gRUPA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gRUPA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_SMENA = new SelectList(db.SMENA, "ID", "ZAOR_Organizace", gRUPA.ID_SMENA);
            ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "TABULKA", gRUPA.STAV);
            return View(gRUPA);
        }

        // GET: UserIN/GRUPA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GRUPA gRUPA = db.GRUPA.Find(id);
            if (gRUPA == null)
            {
                return HttpNotFound();
            }
            return View(gRUPA);
        }

        // POST: UserIN/GRUPA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GRUPA gRUPA = db.GRUPA.Find(id);
            db.GRUPA.Remove(gRUPA);
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
