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
    public class InventoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Inventory
        public ActionResult Index()
        {
            return View(db.productData.ToList());
        }
        public ActionResult Home()
        {
            return View("Home");
        }
         // GET: Inventory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryModels inventoryModels = db.productData.Find(id);
            if (inventoryModels == null)
            {
                return HttpNotFound();
            }
            return View(inventoryModels);
        }       
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,productType,productCategory,productVariety,productQuantity,addDate")] InventoryModels inventoryModels)
        {
            if (ModelState.IsValid)
            {
                db.productData.Add(inventoryModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventoryModels);
        }

        // GET: Inventory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryModels inventoryModels = db.productData.Find(id);
            if (inventoryModels == null)
            {
                return HttpNotFound();
            }
            return View(inventoryModels);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,productType,productCategory,productVariety,productQuantity,addDate")] InventoryModels inventoryModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventoryModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventoryModels);
        }

        // GET: Inventory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryModels inventoryModels = db.productData.Find(id);
            if (inventoryModels == null)
            {
                return HttpNotFound();
            }
            return View(inventoryModels);
        }

        // POST: Inventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InventoryModels inventoryModels = db.productData.Find(id);
            db.productData.Remove(inventoryModels);
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
        [HttpPost]

        public List<SelectListItem> getCategoryDropDown()
        {
            List<SelectListItem> catList = new List<SelectListItem>();
            var category = db.categoryData.ToList();            
            foreach (categoryModels cat in category)
            {     
                    catList.Add(new SelectListItem() { Text = cat.categoryType, Value = cat.Id.ToString() });
            }
            return catList;
        }
        public List<SelectListItem> getTypeDropDown()
        {
            List<SelectListItem> typeList = new List<SelectListItem>();
            var productType = db.productTypeData.ToList();
            foreach (productTypeModels cat in productType)
            {
                typeList.Add(new SelectListItem() { Text = cat.setProductTypes, Value = cat.Id.ToString() });
            }
            return typeList;
        }
        public List<SelectListItem> getQualityDropDown()
        {
            List<SelectListItem> intList = new List<SelectListItem>();
            for(int i = 0; i < 10; i++)
            {
                int qualityNumber = i + 1;
                intList.Add(new SelectListItem() { Value = qualityNumber.ToString(), Text = qualityNumber.ToString()});
            }
            return intList;
        }
    }
}
