using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RKC_IS.Areas.UserIN.Controllers
{
    public class KonecnaMontazController : Controller
    {
        // GET: UserIN/KonecnaMontaz
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserIN/KonecnaMontaz/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserIN/KonecnaMontaz/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserIN/KonecnaMontaz/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserIN/KonecnaMontaz/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserIN/KonecnaMontaz/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserIN/KonecnaMontaz/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserIN/KonecnaMontaz/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
