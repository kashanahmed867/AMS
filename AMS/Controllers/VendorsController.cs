using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AMS.Models;
using Newtonsoft.Json;

namespace AMS.Controllers
{
    public class VendorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vendors
        public ActionResult Index()
        {
            return View(db.Vendors.ToList());
        }

        // GET: Vendors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // GET: Vendors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Vendor_Id,Id,Vendor_Name,Vendor_MobileNo,Vendor_Address,Vendor_Remaining,Vendor_Status,Vendor_NTN,Vendor_Company,Vendor_Date")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Vendors.Add(vendor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vendor);
        }

        // GET: Vendors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: Vendors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Vendor_Id,Id,Vendor_Name,Vendor_MobileNo,Vendor_Address,Vendor_Remaining,Vendor_Status,Vendor_NTN,Vendor_Company,Vendor_Date")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vendor);
        }

        // GET: Vendors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: Vendors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vendor vendor = db.Vendors.Find(id);
            db.Vendors.Remove(vendor);
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

        public void Insert(FormCollection form)
        {
            Vendor ven = JsonConvert.DeserializeObject<Vendor>(form["VendorObj"]);
            db.Vendors.Add(ven);
            db.SaveChanges();
        }

        public void Update(FormCollection form)
        {
            Vendor ven = JsonConvert.DeserializeObject<Vendor>(form["VendorObj"]);
           

            int id = ven.Vendor_Id;
            var ven_db = db.Vendors.Find(id);
            ven_db.Vendor_Name = ven.Vendor_Name;
            ven_db.Vendor_MobileNo = ven.Vendor_MobileNo;
            ven_db.Vendor_Address = ven.Vendor_Address;
            ven_db.Vendor_Remaining = ven.Vendor_Remaining;
            //ven_db.Vendor_Status = ven.Vendor_Status;
            ven_db.Vendor_NTN = ven.Vendor_NTN;
            ven_db.Vendor_Company = ven.Vendor_Company;
            ven_db.Vendor_Date = ven.Vendor_Date;

            db.Entry(ven_db).State = EntityState.Modified;
            db.SaveChanges();
        }

        public JsonResult GetVendor()
        {
            var ven = db.Vendors.ToList();
            return Json(ven, JsonRequestBehavior.AllowGet);

        }

        public JsonResult LoadData(int id)
        {
            var ven = db.Vendors.Find(id);
            return Json(ven, JsonRequestBehavior.AllowGet);
        }

        public void DeleteData(int id)
        {
            var ven = db.Vendors.Find(id);
            db.Vendors.Remove(ven);
            db.SaveChanges();

        }

    }
}
