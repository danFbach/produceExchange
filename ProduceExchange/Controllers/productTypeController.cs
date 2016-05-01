using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProduceExchange.Models;

namespace ProduceExchange.Controllers
{
    public class productTypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: productType
        public ActionResult Index()
        {
            return View(db.productTypeData.ToList());
        }

        // GET: productType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productTypeModels productTypeModels = db.productTypeData.Find(id);
            if (productTypeModels == null)
            {
                return HttpNotFound();
            }
            return View(productTypeModels);
        }

        // GET: productType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: productType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,setProductTypes,typeDescription")] productTypeModels productTypeModels)
        {
            if (ModelState.IsValid)
            {
                db.productTypeData.Add(productTypeModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productTypeModels);
        }

        // GET: productType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productTypeModels productTypeModels = db.productTypeData.Find(id);
            if (productTypeModels == null)
            {
                return HttpNotFound();
            }
            return View(productTypeModels);
        }

        // POST: productType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,setProductTypes,typeDescription")] productTypeModels productTypeModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productTypeModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productTypeModels);
        }

        // GET: productType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productTypeModels productTypeModels = db.productTypeData.Find(id);
            if (productTypeModels == null)
            {
                return HttpNotFound();
            }
            return View(productTypeModels);
        }

        // POST: productType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            productTypeModels productTypeModels = db.productTypeData.Find(id);
            db.productTypeData.Remove(productTypeModels);
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
