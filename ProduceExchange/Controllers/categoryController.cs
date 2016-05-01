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
    public class categoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: category
        public ActionResult Index()
        {
            return View(db.categoryData.ToList());
        }

        // GET: category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categoryModels categoryModels = db.categoryData.Find(id);
            if (categoryModels == null)
            {
                return HttpNotFound();
            }
            return View(categoryModels);
        }

        // GET: category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,categoryType,categoryDiscription,productType")] categoryModels categoryModels)
        {
            if (ModelState.IsValid)
            {
                db.categoryData.Add(categoryModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoryModels);
        }

        // GET: category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categoryModels categoryModels = db.categoryData.Find(id);
            if (categoryModels == null)
            {
                return HttpNotFound();
            }
            return View(categoryModels);
        }

        // POST: category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,categoryType,categoryDiscription")] categoryModels categoryModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoryModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoryModels);
        }

        // GET: category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categoryModels categoryModels = db.categoryData.Find(id);
            if (categoryModels == null)
            {
                return HttpNotFound();
            }
            return View(categoryModels);
        }

        // POST: category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            categoryModels categoryModels = db.categoryData.Find(id);
            db.categoryData.Remove(categoryModels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public List<SelectListItem> getTypeDropDown()
        {
            List<SelectListItem> typeList = new List<SelectListItem>();
            var types = db.productTypeData.ToList();
            foreach(productTypeModels product in types)
            {
                typeList.Add(new SelectListItem() { Text = product.setProductTypes, Value = product.Id.ToString() });
            }
            return typeList;
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
