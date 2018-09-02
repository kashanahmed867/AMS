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
using System.Web.Security;

namespace AMS.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Customer_Id,Id,Customer_Name,Customer_MobileNo,Customer_Address,Customer_Remaining,Customer_Status,Customer_NTN,Customer_Company,Customer_Date")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Customer_Id,Id,Customer_Name,Customer_MobileNo,Customer_Address,Customer_Remaining,Customer_Status,Customer_NTN,Customer_Company,Customer_Date")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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

        public void CreateCustomer(FormCollection form)
        {
            Customer customer = JsonConvert.DeserializeObject<Customer>(form["CustomerObj"]);
            string userId = "";
            userId = Session["tempData"].ToString();
            customer.Id = userId;
            customer.ApplicationUser = db.Users.Where(m => m.Id == userId).SingleOrDefault();
            customer.Customer_Remaining = 0;
            customer.Customer_Date = DateTime.Now;
            customer.Customer_Status = true;
            db.Customers.Add(customer);
            db.SaveChanges();

            Session["tempData"] = null;
        }

        public void UpdateCustomer(FormCollection form)
        {
            Customer customer = JsonConvert.DeserializeObject<Customer>(form["CustomerObj"]);
            int id = customer.Customer_Id;
            var customer_db = db.Customers.Find(id);
            customer_db.Customer_Name = customer.Customer_Name;
            customer_db.Customer_MobileNo = customer.Customer_MobileNo;
            customer_db.Customer_Address = customer.Customer_Address;
            customer_db.Customer_NTN = customer.Customer_NTN;
            customer_db.Customer_Company = customer.Customer_Company;
            db.Entry(customer_db).State = EntityState.Modified;
            db.SaveChanges();
        }

        public JsonResult GetCustomer()
        {
            var customers_list = db.Customers.ToList();
            return Json(customers_list, JsonRequestBehavior.AllowGet);
        }

        public void DeleteCustomer(int id)
        {
            var customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
        }
    }
}
