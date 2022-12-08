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
    public class SY_TABULKAController : Controller
    {
        private ConnectionMap_RKC_Database db = new ConnectionMap_RKC_Database();

        // GET: Admin/SY_TABULKA
        public async Task<ActionResult> Index()
        {
            return View(await db.SY_TABULKA.ToListAsync());
        }

        // GET: Admin/SY_TABULKA/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SY_TABULKA sY_TABULKA = await db.SY_TABULKA.FindAsync(id);
            if (sY_TABULKA == null)
            {
                return HttpNotFound();
            }
            return View(sY_TABULKA);
        }

        // GET: Admin/SY_TABULKA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SY_TABULKA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,TABULKA,POPIS")] SY_TABULKA sY_TABULKA)
        {
            if (ModelState.IsValid)
            {
                db.SY_TABULKA.Add(sY_TABULKA);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sY_TABULKA);
        }

        // GET: Admin/SY_TABULKA/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SY_TABULKA sY_TABULKA = await db.SY_TABULKA.FindAsync(id);
            if (sY_TABULKA == null)
            {
                return HttpNotFound();
            }
            return View(sY_TABULKA);
        }

        // POST: Admin/SY_TABULKA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,TABULKA,POPIS")] SY_TABULKA sY_TABULKA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sY_TABULKA).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sY_TABULKA);
        }

        // GET: Admin/SY_TABULKA/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SY_TABULKA sY_TABULKA = await db.SY_TABULKA.FindAsync(id);
            if (sY_TABULKA == null)
            {
                return HttpNotFound();
            }
            return View(sY_TABULKA);
        }

        // POST: Admin/SY_TABULKA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SY_TABULKA sY_TABULKA = await db.SY_TABULKA.FindAsync(id);
            db.SY_TABULKA.Remove(sY_TABULKA);
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
