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
    public class USER_GRUPAController : Controller
    {
        private ConnectionMap_RKC_Database db = new ConnectionMap_RKC_Database();

        // GET: UserIN/USER_GRUPA
        public ActionResult Index()
        {
            var uSER_GRUPA = db.USER_GRUPA.Include(u => u.GRUPA).Include(u => u.USER);
            return View(uSER_GRUPA.ToList());
        }

        // GET: UserIN/USER_GRUPA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USER_GRUPA uSER_GRUPA = db.USER_GRUPA.Find(id);
            if (uSER_GRUPA == null)
            {
                return HttpNotFound();
            }
            return View(uSER_GRUPA);
        }

        // GET: UserIN/USER_GRUPA/Create
        public ActionResult Create()
        {
            ViewBag.ID_GRUPA = new SelectList(db.GRUPA, "ID", "Nazev");
            ViewBag.ID_USER = new SelectList(db.USER, "ID", "UserName");
            return View();
        }

        // POST: UserIN/USER_GRUPA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_USER,ID_GRUPA")] USER_GRUPA uSER_GRUPA)
        {
            if (ModelState.IsValid)
            {
                db.USER_GRUPA.Add(uSER_GRUPA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_GRUPA = new SelectList(db.GRUPA, "ID", "Nazev", uSER_GRUPA.ID_GRUPA);
            ViewBag.ID_USER = new SelectList(db.USER, "ID", "UserName", uSER_GRUPA.ID_USER);
            return View(uSER_GRUPA);
        }

        // GET: UserIN/USER_GRUPA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USER_GRUPA uSER_GRUPA = db.USER_GRUPA.Find(id);
            if (uSER_GRUPA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_GRUPA = new SelectList(db.GRUPA, "ID", "ZATG_TypGrupa", uSER_GRUPA.ID_GRUPA);
            ViewBag.ID_USER = new SelectList(db.USER, "ID", "ZAOR_organizace", uSER_GRUPA.ID_USER);
            return View(uSER_GRUPA);
        }

        // POST: UserIN/USER_GRUPA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_USER,ID_GRUPA")] USER_GRUPA uSER_GRUPA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSER_GRUPA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_GRUPA = new SelectList(db.GRUPA, "ID", "ZATG_TypGrupa", uSER_GRUPA.ID_GRUPA);
            ViewBag.ID_USER = new SelectList(db.USER, "ID", "ZAOR_organizace", uSER_GRUPA.ID_USER);
            return View(uSER_GRUPA);
        }

        // GET: UserIN/USER_GRUPA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USER_GRUPA uSER_GRUPA = db.USER_GRUPA.Find(id);
            if (uSER_GRUPA == null)
            {
                return HttpNotFound();
            }
            return View(uSER_GRUPA);
        }

        // POST: UserIN/USER_GRUPA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USER_GRUPA uSER_GRUPA = db.USER_GRUPA.Find(id);
            db.USER_GRUPA.Remove(uSER_GRUPA);
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
