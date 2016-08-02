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
    public class OrderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Order
        public ActionResult Index()
        {
            return View(db.orderData.ToList());
        }

        // GET: Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderModels orderModels = db.orderData.Find(id);
            if (orderModels == null)
            {
                return HttpNotFound();
            }
            return View(orderModels);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,orderCreateDate,orderClient,orderType,orderCategory,orderVariety,orderQuantity,orderDollars,orderDueDate,orderComment,orderStatus")] OrderModels orderModels)
        {
            if (ModelState.IsValid)
            {
                db.orderData.Add(orderModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderModels);
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderModels orderModels = db.orderData.Find(id);
            if (orderModels == null)
            {
                return HttpNotFound();
            }
            return View(orderModels);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,orderClient,orderType,orderCategory,orderVariety,orderQuantity,orderDollars,orderDate,orderComment,orderStatus")] OrderModels orderModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderModels);
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderModels orderModels = db.orderData.Find(id);
            if (orderModels == null)
            {
                return HttpNotFound();
            }
            return View(orderModels);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderModels orderModels = db.orderData.Find(id);
            db.orderData.Remove(orderModels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public List<SelectListItem> getProductTypeDropDown()
        {
            List<SelectListItem> typeList = new List<SelectListItem>();
            var types = db.productTypeData.ToList();
            foreach (var type in types)
            {
                typeList.Add(new SelectListItem() { Text = type.setProductTypes, Value = type.Id.ToString() });
            }
            return typeList;
        }
        public List<SelectListItem> getProductCategoryDropDown()
        {
            List<SelectListItem> catList = new List<SelectListItem>();
            var cats = db.categoryData.ToList();
            foreach (var cat in cats)
            {
                catList.Add(new SelectListItem() { Text = cat.categoryType, Value = cat.Id.ToString() });
            }
            return catList;
        }
        public List<SelectListItem> getVarietyDropDown()
        {
            List<SelectListItem> varietyList = new List<SelectListItem>();
            var varieties = db.productData.ToList();
            foreach (var variety in varieties)
            {
                varietyList.Add(new SelectListItem() { Text = variety.productVariety, Value = variety.Id.ToString() });
            }
            return varietyList;
        }
        public List<SelectListItem> getClientDropDown()
        {
            List<SelectListItem> clientList = new List<SelectListItem>();
            var clients = db.clientData.ToList();
            foreach (var client in clients)
            {
                clientList.Add(new SelectListItem() { Text = client.clientLName + ", " + client.clientFName + " Business:  " + client.businessName, Value = client.Id.ToString() });
            }
            return clientList;
        }
        public string getStatus(int statusNumber)
        {
            if (statusNumber.Equals(0))
            {
                return "Complete";
            }
            else if (statusNumber.Equals(1))
            {
                return "Pending";
            }
            return null;
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
