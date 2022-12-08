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

namespace RKC_IS.Areas.UserIN.Controllers
{
    [Authorize(Roles = "admin, logistika")]
    public class STROJController : Controller
    {
        private ConnectionMap_RKC_Database db = new ConnectionMap_RKC_Database();

        // GET: UserIN/STROJ
        public ActionResult Index()
        {
            var sTROJ = db.STROJ.Include(s => s.SY_STAV);
            return View(sTROJ.ToList());
        }

        // GET: UserIN/STROJ/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STROJ sTROJ = db.STROJ.Find(id);
            if (sTROJ == null)
            {
                return HttpNotFound();
            }
            return View(sTROJ);
        }

        // GET: UserIN/STROJ/Create
        public ActionResult Create()
        {
            //ViewBag.ZAOR_Organizace = new SelectList(db.CISELNIK_DATA.Where(o => o.DOMENA == "ZAOR").OrderBy(o => o.POPIS), "KOD", "POPIS");

            //ViewBag.STAV = new SelectList(db.SY_STAV.Where(o => o.TABULKA == "STROJ").OrderBy(o => o.ID), "ID", "POPIS");
            //ViewBag.STAV = new SelectList(db.SY_STAV.Where(o => o.TABULKA == "STROJ").OrderBy(o => o.ID), "ID", "POPIS");
            ViewBag.STAV = new SelectList(db.SY_STAV.Where(o => o.TABULKA == "STROJ").Where(o => o.STAV == 1), "ID", "POPIS");
            //ViewBag.ZAOR_Organizace = new SelectList(db.CISELNIK_DATA.Where(o => o.DOMENA == "ZAOR").OrderBy(o => o.POPIS), "KOD", "POPIS");
            ViewBag.OrganizaceList = new SelectList(db.CISELNIK_DATA.Where(o => o.DOMENA == "ZAOR").OrderBy(o => o.POPIS), "KOD", "POPIS");
            ViewBag.NaklStredList = new SelectList(db.CISELNIK_DATA.Where(o => o.DOMENA == "ZANS").OrderBy(o => o.POPIS), "KOD", "POPIS");
            ViewBag.TypList = new SelectList(db.CISELNIK_DATA.Where(o => o.DOMENA == "ZATS").OrderBy(o => o.POPIS), "KOD", "POPIS");
            ViewBag.VyrobceList = new SelectList(db.CISELNIK_DATA.Where(o => o.DOMENA == "ZAVY").OrderBy(o => o.POPIS), "KOD", "POPIS");


            return View();
        }

        // POST: UserIN/STROJ/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ZAOR_Organizace,ZANS_NaklStr,ZATS_Typ,ZAVY_Vyrobce,Nazev,Cislo,InventarniCislo,VyrobniCislo,DatumVyroby,DobaChodu,X,Y,DX,DY,STAV,STAV_NASLEDUJICI,C_USER,C_DATE,M_DATE,M_USER")] STROJ sTROJ)
        {
            //SY_STAV sTav = db.SY_STAV.Find(db.SY_STAV.Where(o => o.TABULKA == "STROJ").Where(o => o.STAV == 1));
            sTROJ.C_USER = User.Identity.GetUserId<int>();
            sTROJ.C_DATE = DateTime.Now;
            //sTROJ.STAV = sTav.ID;

            if (ModelState.IsValid)
            {
                
                //sTROJ.STAV = db.SY_STAV.Where(o => o.TABULKA == "STROJ").Where(o => o.STAV == 1);
                //sTROJ.C_USER= userid;
                db.STROJ.Add(sTROJ);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.STAV = new SelectList(db.SY_STAV.Where(o => o.TABULKA == "STROJ").Where(o => o.STAV == 1), "ID", "POPIS");
            //ViewBag.ZAOR_Organizace = new SelectList(db.CISELNIK_DATA, "KOD", "POPIS", sTROJ.ZAOR_Organizace);
            ViewBag.OrganizaceList = new SelectList(db.CISELNIK_DATA, "KOD", "POPIS", sTROJ.ZAOR_Organizace);
            ViewBag.NaklStredList = new SelectList(db.CISELNIK_DATA, "KOD", "POPIS", sTROJ.ZANS_NaklStr);
            ViewBag.TypList = new SelectList(db.CISELNIK_DATA, "KOD", "POPIS", sTROJ.ZATS_Typ);
            ViewBag.VyrobceList = new SelectList(db.CISELNIK_DATA, "KOD", "POPIS", sTROJ.ZAVY_Vyrobce);
            ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "POPIS", sTROJ.STAV);
            return View(sTROJ);
        }

        // GET: UserIN/STROJ/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STROJ sTROJ = db.STROJ.Find(id);
            if (sTROJ == null)
            {
                return HttpNotFound();
            }


            ViewBag.C_USER = db.STROJ.Find(id).C_DATE;
            ViewBag.M_USER = db.STROJ.Find(id).M_DATE;


            ViewBag.OrganizaceList = new SelectList(db.CISELNIK_DATA.Where(o => o.DOMENA == "ZAOR").OrderBy(o => o.POPIS), "KOD", "POPIS");
            ViewBag.NaklStredList = new SelectList(db.CISELNIK_DATA.Where(o => o.DOMENA == "ZANS").OrderBy(o => o.POPIS), "KOD", "POPIS");
            ViewBag.TypList = new SelectList(db.CISELNIK_DATA.Where(o => o.DOMENA == "ZATS").OrderBy(o => o.POPIS), "KOD", "POPIS");
            ViewBag.VyrobceList = new SelectList(db.CISELNIK_DATA.Where(o => o.DOMENA == "ZAVY").OrderBy(o => o.POPIS), "KOD", "POPIS");
            ViewBag.STAV = new SelectList(db.SY_STAV.Where(o => o.TABULKA == "STROJ"), "ID", "POPIS");
            return View(sTROJ);
        }

        // POST: UserIN/STROJ/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ZAOR_Organizace,ZANS_NaklStr,ZATS_Typ,ZAVY_Vyrobce,Nazev,Cislo,InventarniCislo,VyrobniCislo,DatumVyroby,DobaChodu,X,Y,DX,DY,STAV,STAV_NASLEDUJICI,C_DATE,C_USER,M_DATE,M_USER")] STROJ sTROJ)
        {
            //sTROJ.C_DATE = C_DATE;
            
            //Convert.ToDateTime(sTROJ.DatumVyroby).ToString("dd/MM/yyyy HH:mm:ss");
            //Convert.ToDateTime(sTROJ.C_DATE).ToString("dd/MM/yyyy HH:mm:ss");


            //// Sample 01:
            //Convert.ToDateTime(sTROJ.DatumVyroby).ToString("MM/dd/yyyy HH:mm:ss");

            //// Sample 02:
            //DateTime.Parse(sTROJ.DatumVyroby).ToString("MM/dd/yyyy HH:mm:ss"); //nejede

            //// Sample 03:
            //string.Format("{0:MM/dd/yyyy HH:mm:ss}", DateTime.Parse(sTROJ.DatumVyroby)); //nejede

            if (ModelState.IsValid)
            {
                sTROJ.M_USER = User.Identity.GetUserId<int>();
                sTROJ.M_DATE = DateTime.Now;

                db.Entry(sTROJ).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.C_USER = sTROJ.C_DATE;
            ViewBag.M_USER = sTROJ.M_DATE;
            ViewBag.OrganizaceList = new SelectList(db.CISELNIK_DATA, "KOD", "POPIS", sTROJ.ZAOR_Organizace);
            ViewBag.NaklStredList = new SelectList(db.CISELNIK_DATA, "KOD", "POPIS", sTROJ.ZANS_NaklStr);
            ViewBag.TypList = new SelectList(db.CISELNIK_DATA, "KOD", "POPIS", sTROJ.ZATS_Typ);
            ViewBag.VyrobceList = new SelectList(db.CISELNIK_DATA, "KOD", "POPIS", sTROJ.ZAVY_Vyrobce);
            ViewBag.STAV = new SelectList(db.SY_STAV, "ID", "TABULKA", sTROJ.STAV);
            return View(sTROJ);
        }

        // GET: UserIN/STROJ/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STROJ sTROJ = db.STROJ.Find(id);
            if (sTROJ == null)
            {
                return HttpNotFound();
            }
            return View(sTROJ);
        }

        // POST: UserIN/STROJ/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            STROJ sTROJ = db.STROJ.Find(id);
            db.STROJ.Remove(sTROJ);
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
