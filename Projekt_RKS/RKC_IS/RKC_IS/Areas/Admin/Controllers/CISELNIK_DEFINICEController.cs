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
    public class CISELNIK_DEFINICEController : Controller
    {
        private ConnectionMap_RKC_Database db = new ConnectionMap_RKC_Database();

        // GET: Admin/CISELNIK_DEFINICE
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "domena_desc" : "";
            ViewBag.DateSortParm = sortOrder == "nazev_ciselniku" ? "nazev_ciselniku_desc" : "nazev_ciselniku";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var ciselnik_definice = from s in db.CISELNIK_DEFINICE
                                    select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                ciselnik_definice = ciselnik_definice.Where(s => s.DOMENA.Contains(searchString)
                                       || s.POPIS.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "domena_desc":
                    ciselnik_definice = ciselnik_definice.OrderByDescending(s => s.DOMENA);
                    break;
                case "nazev_ciselniku":
                    ciselnik_definice = ciselnik_definice.OrderBy(s => s.NAZEV_CISELNIKU);
                    break;
                case "nazev_ciselniku_desc":
                    ciselnik_definice = ciselnik_definice.OrderByDescending(s => s.NAZEV_CISELNIKU);
                    break;
                default:
                    ciselnik_definice = ciselnik_definice.OrderBy(s => s.DOMENA);
                    break;
            }

            int pageSize = 15;
            int pageNumber = (page ?? 1);

            if (Request.IsAjaxRequest())
            {
                return PartialView(ciselnik_definice.ToPagedList(pageNumber, pageSize));
            }

            return View(ciselnik_definice.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/CISELNIK_DEFINICE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CISELNIK_DEFINICE cISELNIK_DEFINICE = db.CISELNIK_DEFINICE.Find(id);
            if (cISELNIK_DEFINICE == null)
            {
                return HttpNotFound();
            }
            return View(cISELNIK_DEFINICE);
        }

        // GET: Admin/CISELNIK_DEFINICE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CISELNIK_DEFINICE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DOMENA,NAZEV_CISELNIKU,POPIS,DOMENA_M,MASKA,KOD_VYZNAM,KOD_M_VYZNAM,TXT1,TXT2,L0_VYZNAM,L1_VYZNAM,L2_VYZNAM,L3_VYZNAM,L4_VYZNAM,L5_VYZNAM,L6_VYZNAM,L7_VYZNAM,L8_VYZNAM,L9_VYZNAM")] CISELNIK_DEFINICE cISELNIK_DEFINICE)
        {
            if (ModelState.IsValid)
            {
                db.CISELNIK_DEFINICE.Add(cISELNIK_DEFINICE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cISELNIK_DEFINICE);
        }

        // GET: Admin/CISELNIK_DEFINICE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CISELNIK_DEFINICE cISELNIK_DEFINICE = db.CISELNIK_DEFINICE.Find(id);
            if (cISELNIK_DEFINICE == null)
            {
                return HttpNotFound();
            }
            return View(cISELNIK_DEFINICE);
        }

        // POST: Admin/CISELNIK_DEFINICE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DOMENA,NAZEV_CISELNIKU,POPIS,DOMENA_M,MASKA,KOD_VYZNAM,KOD_M_VYZNAM,TXT1,TXT2,L0_VYZNAM,L1_VYZNAM,L2_VYZNAM,L3_VYZNAM,L4_VYZNAM,L5_VYZNAM,L6_VYZNAM,L7_VYZNAM,L8_VYZNAM,L9_VYZNAM")] CISELNIK_DEFINICE cISELNIK_DEFINICE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cISELNIK_DEFINICE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cISELNIK_DEFINICE);
        }

        // GET: Admin/CISELNIK_DEFINICE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CISELNIK_DEFINICE cISELNIK_DEFINICE = db.CISELNIK_DEFINICE.Find(id);
            if (cISELNIK_DEFINICE == null)
            {
                return HttpNotFound();
            }
            return View(cISELNIK_DEFINICE);
        }

        // POST: Admin/CISELNIK_DEFINICE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CISELNIK_DEFINICE cISELNIK_DEFINICE = db.CISELNIK_DEFINICE.Find(id);
            db.CISELNIK_DEFINICE.Remove(cISELNIK_DEFINICE);
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
