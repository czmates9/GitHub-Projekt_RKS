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
    public class SY_STAVController : Controller
    {
        private ConnectionMap_RKC_Database db = new ConnectionMap_RKC_Database();

        // GET: Admin/SY_STAV
        public async Task<ActionResult> Index()
        {
            return View(await db.SY_STAV.ToListAsync());
        }

        // GET: Admin/SY_STAV/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SY_STAV sY_STAV = await db.SY_STAV.FindAsync(id);
            if (sY_STAV == null)
            {
                return HttpNotFound();
            }
            return View(sY_STAV);
        }

        // GET: Admin/SY_STAV/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SY_STAV/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,TABULKA,STAV,POPIS,L_PLATI,BARVA")] SY_STAV sY_STAV)
        {
            if (ModelState.IsValid)
            {
                db.SY_STAV.Add(sY_STAV);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sY_STAV);
        }

        // GET: Admin/SY_STAV/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SY_STAV sY_STAV = await db.SY_STAV.FindAsync(id);
            if (sY_STAV == null)
            {
                return HttpNotFound();
            }
            return View(sY_STAV);
        }

        // POST: Admin/SY_STAV/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,TABULKA,STAV,POPIS,L_PLATI,BARVA")] SY_STAV sY_STAV)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sY_STAV).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sY_STAV);
        }

        // GET: Admin/SY_STAV/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SY_STAV sY_STAV = await db.SY_STAV.FindAsync(id);
            if (sY_STAV == null)
            {
                return HttpNotFound();
            }
            return View(sY_STAV);
        }

        // POST: Admin/SY_STAV/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SY_STAV sY_STAV = await db.SY_STAV.FindAsync(id);
            db.SY_STAV.Remove(sY_STAV);
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
