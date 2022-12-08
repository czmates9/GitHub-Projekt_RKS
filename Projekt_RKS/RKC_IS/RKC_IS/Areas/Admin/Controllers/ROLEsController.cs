using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RKC_IS.DataAccess.Model.AutoMapping;

namespace RKC_IS.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class ROLEsController : Controller
    {
        private ConnectionMap_RKC_Database db = new ConnectionMap_RKC_Database();

        // GET: Admin/ROLEs
        public ActionResult Index()
        {
            var rOLE = db.ROLE.Include(r => r.SY_STAV);
            return View(rOLE.ToList());
        }

        // GET: Admin/ROLEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROLE rOLE = db.ROLE.Find(id);
            if (rOLE == null)
            {
                return HttpNotFound();
            }
            return View(rOLE);
        }

        // GET: Admin/ROLEs/Create
        public ActionResult Create()
        {
            //ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "TABULKA");
            //ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "TABULKA");
            ViewBag.STAV = new SelectList(db.SY_STAV.Where(o => o.TABULKA == "ROLE").Where(o => o.STAV == 1), "ID", "POPIS");
            return View();
        }

        // POST: Admin/ROLEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,STAV,ZKRATKA,POPIS_ROLE,STAV_NASLEDUJICI,C_USER,C_DATE,M_USER,M_DATE")] ROLE rOLE)
        {
            rOLE.C_USER = User.Identity.GetUserId<int>();
            rOLE.C_DATE = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.ROLE.Add(rOLE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "TABULKA", rOLE.STAV);
            ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "POPIS", rOLE.STAV);
            return View(rOLE);
        }

        // GET: Admin/ROLEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROLE rOLE = db.ROLE.Find(id);
            if (rOLE == null)
            {
                return HttpNotFound();
            }
            ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "TABULKA", rOLE.STAV);
            ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "TABULKA", rOLE.STAV);
            return View(rOLE);
        }

        // POST: Admin/ROLEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,STAV,ZKRATKA,POPIS_ROLE,STAV_NASLEDUJICI,C_USER,C_DATE,M_USER,M_DATE")] ROLE rOLE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rOLE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "TABULKA", rOLE.STAV);
            ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "TABULKA", rOLE.STAV);
            return View(rOLE);
        }

        // GET: Admin/ROLEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROLE rOLE = db.ROLE.Find(id);
            if (rOLE == null)
            {
                return HttpNotFound();
            }
            return View(rOLE);
        }

        // POST: Admin/ROLEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ROLE rOLE = db.ROLE.Find(id);
            db.ROLE.Remove(rOLE);
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
