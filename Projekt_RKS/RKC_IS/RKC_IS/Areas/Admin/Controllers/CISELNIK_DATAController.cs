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
    public class CISELNIK_DATAController : Controller
    {
        private ConnectionMap_RKC_Database db = new ConnectionMap_RKC_Database();

        // GET: Admin/CISELNIK_DATA
        public ActionResult Index(string sortOrder, string currentFilter, string searchStringDomena, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "domena_desc" : "";
            ViewBag.DateSortParm = sortOrder == "kod" ? "kod_desc" : "kod";

            if (searchStringDomena != null)
            {
                page = 1;
            }
            else
            {
                searchStringDomena = currentFilter;
            }

            ViewBag.CurrentFilter = searchStringDomena;

            var ciselnik_data = from s in db.CISELNIK_DATA
                                select s;
            if (!String.IsNullOrEmpty(searchStringDomena))
            {
                ciselnik_data = ciselnik_data.Where(s => s.DOMENA.Contains(searchStringDomena)
                                       || s.POPIS.Contains(searchStringDomena));
            }
            switch (sortOrder)
            {
                case "domena_desc":
                    ciselnik_data = ciselnik_data.OrderByDescending(s => s.DOMENA);
                    break;
                case "kod":
                    ciselnik_data = ciselnik_data.OrderBy(s => s.KOD);
                    break;
                case "kod_desc":
                    ciselnik_data = ciselnik_data.OrderByDescending(s => s.KOD);
                    break;
                default:
                    ciselnik_data = ciselnik_data.OrderBy(s => s.DOMENA);
                    break;
            }
            int pageSize = 20;
            int pageNumber = (page ?? 1);

            if (Request.IsAjaxRequest())
            {
                return PartialView(ciselnik_data.ToPagedList(pageNumber, pageSize));
            }

            return View(ciselnik_data.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/CISELNIK_DATA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CISELNIK_DATA cISELNIK_DATA = db.CISELNIK_DATA.Find(id);
            if (cISELNIK_DATA == null)
            {
                return HttpNotFound();
            }
            return View(cISELNIK_DATA);
        }

        // GET: Admin/CISELNIK_DATA/Create
        public ActionResult Create()
        {
            ViewBag.DOMENA = new SelectList(db.CISELNIK_DEFINICE, "DOMENA", "NAZEV_CISELNIKU");
            ViewBag.DOMENA = new SelectList(db.CISELNIK_DEFINICE, "DOMENA", "NAZEV_CISELNIKU");
            return View();
        }

        // POST: Admin/CISELNIK_DATA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DOMENA,KOD,POPIS,PORADI,KOD_M,TXT1,TXT2,L_0,L_1,L_2,L_3,L_4,L_5,L_6,L_7,L_8,L_9")] CISELNIK_DATA cISELNIK_DATA)
        {
            if (ModelState.IsValid)
            {
                db.CISELNIK_DATA.Add(cISELNIK_DATA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cISELNIK_DATA);
        }

        // GET: Admin/CISELNIK_DATA/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.DOMENA = new SelectList(db.CISELNIK_DEFINICE, "DOMENA", "NAZEV_CISELNIKU");
            ViewBag.DOMENA = new SelectList(db.CISELNIK_DEFINICE, "DOMENA", "NAZEV_CISELNIKU");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CISELNIK_DATA cISELNIK_DATA = db.CISELNIK_DATA.Find(id);
            if (cISELNIK_DATA == null)
            {
                return HttpNotFound();
            }
            return View(cISELNIK_DATA);
        }

        // POST: Admin/CISELNIK_DATA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DOMENA,KOD,POPIS,PORADI,KOD_M,TXT1,TXT2,L_0,L_1,L_2,L_3,L_4,L_5,L_6,L_7,L_8,L_9")] CISELNIK_DATA cISELNIK_DATA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cISELNIK_DATA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cISELNIK_DATA);
        }

        // GET: Admin/CISELNIK_DATA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CISELNIK_DATA cISELNIK_DATA = db.CISELNIK_DATA.Find(id);
            if (cISELNIK_DATA == null)
            {
                return HttpNotFound();
            }
            return View(cISELNIK_DATA);
        }

        // POST: Admin/CISELNIK_DATA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CISELNIK_DATA cISELNIK_DATA = db.CISELNIK_DATA.Find(id);
            db.CISELNIK_DATA.Remove(cISELNIK_DATA);
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
