using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RKC_IS.DataAccess.Model.AutoMapping;

namespace RKC_IS.Areas.Admin.Controllers
{
    public class SY_PRECHODController : Controller
    {
        private ConnectionMap_RKC_Database db = new ConnectionMap_RKC_Database();

        // GET: Admin/SY_PRECHOD
        public async Task<ActionResult> Index()
        {
            return View(await db.SY_PRECHOD.ToListAsync());
        }

        // GET: Admin/SY_PRECHOD/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SY_PRECHOD sY_PRECHOD = await db.SY_PRECHOD.FindAsync(id);
            if (sY_PRECHOD == null)
            {
                return HttpNotFound();
            }
            return View(sY_PRECHOD);
        }

        // GET: Admin/SY_PRECHOD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SY_PRECHOD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,TABULKA,ZE_STAVU,DO_STAVU,POPIS,L_PLATI")] SY_PRECHOD sY_PRECHOD)
        {
            if (ModelState.IsValid)
            {
                db.SY_PRECHOD.Add(sY_PRECHOD);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sY_PRECHOD);
        }

        // GET: Admin/SY_PRECHOD/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SY_PRECHOD sY_PRECHOD = await db.SY_PRECHOD.FindAsync(id);
            if (sY_PRECHOD == null)
            {
                return HttpNotFound();
            }
            return View(sY_PRECHOD);
        }

        // POST: Admin/SY_PRECHOD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,TABULKA,ZE_STAVU,DO_STAVU,POPIS,L_PLATI")] SY_PRECHOD sY_PRECHOD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sY_PRECHOD).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sY_PRECHOD);
        }

        // GET: Admin/SY_PRECHOD/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SY_PRECHOD sY_PRECHOD = await db.SY_PRECHOD.FindAsync(id);
            if (sY_PRECHOD == null)
            {
                return HttpNotFound();
            }
            return View(sY_PRECHOD);
        }

        // POST: Admin/SY_PRECHOD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SY_PRECHOD sY_PRECHOD = await db.SY_PRECHOD.FindAsync(id);
            db.SY_PRECHOD.Remove(sY_PRECHOD);
            await db.SaveChangesAsync();
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
