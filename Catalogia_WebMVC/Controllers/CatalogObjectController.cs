using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Catalogia_WebMVC.Models;

namespace Catalogia_WebMVC.Controllers
{
    public class CatalogObjectController : Controller
    {
        private CatalogObjectDBContext db = new CatalogObjectDBContext();
        /*
        // GET: CatalogObject
        public ActionResult Index()
        {
            return View(db.CatalogObjects.ToList());
        }
        */
        public ActionResult Index(string inSearch, string inOtherName)
        {
            var co = from cobjects in db.CatalogObjects
                     select cobjects;

            if (!string.IsNullOrEmpty(inSearch))
            { 
                co = from cFilter in db.CatalogObjects
                    where cFilter.ObjectName.Contains(inSearch)
                        select cFilter;
            }

            if (!string.IsNullOrEmpty(inOtherName))
            {
                co = co.Where(x => x.OtherName == inOtherName);
            }

            return View(co);
        }

        // GET: CatalogObject/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatalogObject catalogObject = db.CatalogObjects.Find(id);
            if (catalogObject == null)
            {
                return HttpNotFound();
            }
            return View(catalogObject);
        }

        // GET: CatalogObject/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatalogObject/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ObjectName,OtherName,Price,DateAcquired")] CatalogObject catalogObject)
        {
            if (ModelState.IsValid)
            {
                db.CatalogObjects.Add(catalogObject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(catalogObject);
        }

        // GET: CatalogObject/Edit/5
        public ActionResult Edit(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            CatalogObject catalogObject = db.CatalogObjects.Find(id);
            if (catalogObject == null)
            {
                return HttpNotFound();
            }
            return View(catalogObject);
        }

        // POST: CatalogObject/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ObjectName,OtherName,Price,DateAcquired")] CatalogObject catalogObject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catalogObject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(catalogObject);
        }

        // GET: CatalogObject/Delete/5
        public ActionResult Delete(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            CatalogObject catalogObject = db.CatalogObjects.Find(id);
            if (catalogObject == null)
            {
                return HttpNotFound();
            }
            return View(catalogObject);
        }

        // POST: CatalogObject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CatalogObject catalogObject = db.CatalogObjects.Find(id);
            db.CatalogObjects.Remove(catalogObject);
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
