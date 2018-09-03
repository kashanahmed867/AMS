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

        public void CreateVendor(FormCollection form)
        {
            Vendor vendor = JsonConvert.DeserializeObject<Vendor>(form["VendorObj"]);
            string userId = "";
            userId = Session["tempData"].ToString();
            vendor.Id = userId;
            vendor.ApplicationUser = db.Users.Where(m => m.Id == userId).SingleOrDefault();
            vendor.Vendor_Remaining = 0;
            vendor.Vendor_Date = DateTime.Now;
            vendor.Vendor_Status = true;
            db.Vendors.Add(vendor);
            db.SaveChanges();

            Session["tempData"] = null;
        }

        public void UpdateVendor(FormCollection form)
        {
            Vendor vendor = JsonConvert.DeserializeObject<Vendor>(form["VendorObj"]);
            int id = vendor.Vendor_Id;
            var vendor_db = db.Vendors.Find(id);
            vendor_db.Vendor_Name = vendor.Vendor_Name;
            vendor_db.Vendor_MobileNo = vendor.Vendor_MobileNo;
            vendor_db.Vendor_Address = vendor.Vendor_Address;
            vendor_db.Vendor_NTN = vendor.Vendor_NTN;
            vendor_db.Vendor_Company = vendor.Vendor_Company;
            db.Entry(vendor_db).State = EntityState.Modified;
            db.SaveChanges();
        }

        public JsonResult GetVendor()
        {
            var vendors_list = db.Vendors.ToList();
            return Json(vendors_list, JsonRequestBehavior.AllowGet);
        }

        public void DeleteVendor(int id)
        {
            var vendor = db.Vendors.Find(id);
            db.Vendors.Remove(vendor);
            db.SaveChanges();
        }
    }
}
