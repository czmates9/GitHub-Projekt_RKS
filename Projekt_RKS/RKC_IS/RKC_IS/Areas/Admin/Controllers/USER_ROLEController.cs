using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RKC_IS.DataAccess.Model.AutoMapping;

namespace RKC_IS.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class USER_ROLEController : Controller
    {
        private ConnectionMap_RKC_Database db = new ConnectionMap_RKC_Database();

        // GET: Admin/USER_ROLE
        public ActionResult Index()
        {
            var uSER_ROLE = db.USER_ROLE.Include(u => u.ROLE).Include(u => u.USER);
            return View(uSER_ROLE.ToList());
        }

        // GET: Admin/USER_ROLE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USER_ROLE uSER_ROLE = db.USER_ROLE.Find(id);
            if (uSER_ROLE == null)
            {
                return HttpNotFound();
            }
            return View(uSER_ROLE);
        }

        // GET: Admin/USER_ROLE/Create
        public ActionResult Create()
        {
            //ViewBag.ID_ROLE = new SelectList(db.ROLE, "ID", "ZKRATKA");
            ViewBag.RoleList = new SelectList(db.ROLE, "ID", "ZKRATKA");
            ViewBag.UserList = new SelectList(db.USER, "ID", "UserName");
            return View();
        }

        // POST: Admin/USER_ROLE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_USER,ID_ROLE,L_PLATI")] USER_ROLE uSER_ROLE)
        {
            if (ModelState.IsValid)
            {
                db.USER_ROLE.Add(uSER_ROLE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.ID_ROLE = new SelectList(db.ROLE, "ID", "ZKRATKA", uSER_ROLE.ID_ROLE);
            ViewBag.RoleList = new SelectList(db.ROLE, "ID", "ZKRATKA", uSER_ROLE.ID_ROLE);
            ViewBag.UserList = new SelectList(db.USER, "ID", "UserName", uSER_ROLE.ID_USER);
            return View(uSER_ROLE);
        }

        // GET: Admin/USER_ROLE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USER_ROLE uSER_ROLE = db.USER_ROLE.Find(id);
            if (uSER_ROLE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ROLE = new SelectList(db.ROLE, "ID", "ZKRATKA", uSER_ROLE.ID_ROLE);
            ViewBag.ID_ROLE = new SelectList(db.ROLE, "ID", "ZKRATKA", uSER_ROLE.ID_ROLE);
            ViewBag.ID_USER = new SelectList(db.USER, "ID", "ZAOR_organizace", uSER_ROLE.ID_USER);
            return View(uSER_ROLE);
        }

        // POST: Admin/USER_ROLE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_USER,ID_ROLE,L_PLATI")] USER_ROLE uSER_ROLE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSER_ROLE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ROLE = new SelectList(db.ROLE, "ID", "ZKRATKA", uSER_ROLE.ID_ROLE);
            ViewBag.ID_ROLE = new SelectList(db.ROLE, "ID", "ZKRATKA", uSER_ROLE.ID_ROLE);
            ViewBag.ID_USER = new SelectList(db.USER, "ID", "ZAOR_organizace", uSER_ROLE.ID_USER);
            return View(uSER_ROLE);
        }

        // GET: Admin/USER_ROLE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USER_ROLE uSER_ROLE = db.USER_ROLE.Find(id);
            if (uSER_ROLE == null)
            {
                return HttpNotFound();
            }
            return View(uSER_ROLE);
        }

        // POST: Admin/USER_ROLE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USER_ROLE uSER_ROLE = db.USER_ROLE.Find(id);
            db.USER_ROLE.Remove(uSER_ROLE);
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
