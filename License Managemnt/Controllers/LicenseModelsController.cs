using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using License_Managemnt.Data;
using License_Managemnt.Models;

namespace License_Managemnt.Controllers
{
    public class LicenseModelsController : Controller
    {
        private License_ManagemntContext db = new License_ManagemntContext();

        // GET: LicenseModels
        public ActionResult Index()
        {
            return View(db.LicenseModels.ToList());
        }

        // GET: LicenseModels/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicenseModel licenseModel = db.LicenseModels.Find(id);
            if (licenseModel == null)
            {
                return HttpNotFound();
            }
            return View(licenseModel);
        }

        // GET: LicenseModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LicenseModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email,phone,LicenseKey")] LicenseModel licenseModel)
        {
            if (ModelState.IsValid)
            {
                db.LicenseModels.Add(licenseModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(licenseModel);
        }

        // GET: LicenseModels/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicenseModel licenseModel = db.LicenseModels.Find(id);
            if (licenseModel == null)
            {
                return HttpNotFound();
            }
            return View(licenseModel);
        }

        // POST: LicenseModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,phone,LicenseKey")] LicenseModel licenseModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licenseModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(licenseModel);
        }

        // GET: LicenseModels/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicenseModel licenseModel = db.LicenseModels.Find(id);
            if (licenseModel == null)
            {
                return HttpNotFound();
            }
            return View(licenseModel);
        }

        // POST: LicenseModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LicenseModel licenseModel = db.LicenseModels.Find(id);
            db.LicenseModels.Remove(licenseModel);
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
