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
    public class ClientController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Client
        public ActionResult Index()
        {
            return View(db.clientData.ToList());
        }

        // GET: Client/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientModels clientModels = db.clientData.Find(id);
            if (clientModels == null)
            {
                return HttpNotFound();
            }
            return View(clientModels);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,clientFName,clientLName,businessName,clientPhoneNumber,clientEmail,clientAddress,clientZipcode,moneySpent,clientComments")] ClientModels clientModels)
        {
            if (ModelState.IsValid)
            {
                db.clientData.Add(clientModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientModels);
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientModels clientModels = db.clientData.Find(id);
            if (clientModels == null)
            {
                return HttpNotFound();
            }
            return View(clientModels);
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,clientFName,clientLName,businessName,clientPhoneNumber,clientEmail,clientAddress,clientZipcode,moneySpent,clientComments")] ClientModels clientModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientModels);
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientModels clientModels = db.clientData.Find(id);
            if (clientModels == null)
            {
                return HttpNotFound();
            }
            return View(clientModels);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientModels clientModels = db.clientData.Find(id);
            db.clientData.Remove(clientModels);
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
