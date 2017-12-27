using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRentalApplication.Models;
using VideoRentalApplication.ViewModels;

namespace VideoRentalApplication.Controllers
{
    public class CustomerController : Controller
    {
        private VideoRentalApplicationDBContext db = new VideoRentalApplicationDBContext();

        //
        // GET: /Customer/

        public ActionResult Index()
        {
            //var customers = db.Customers.Include(c => c.MembershipType);customers.ToList()
            return View();
        }

        //
        // GET: /Customer/Details/5

        public ActionResult Details(int custID)
        {
            Customer customer = db.Customers.SingleOrDefault(x => x.custID == custID);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }        

        //
        // GET: /Customer/Create

        public ActionResult Create()
        {
            Customer customer = new Customer();
            //ViewBag.membershipTypeId = new SelectList(db.MembershipTypes, "ID", "Name");
            var membershipType = db.MembershipTypes.ToList();
            var viewmodel = new CreateCustomerViewModel()   // Implementing View Model
            {
                Customer = customer,
                MembershipType = membershipType
            };
            return View(viewmodel);
        }

        //
        // POST: /Customer/Create

        [HttpPost]
        public ActionResult Create(CreateCustomerViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customerViewModel.Customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.membershipTypeId = new SelectList(db.MembershipTypes, "ID", "Name", customerViewModel.Customer.membershipTypeId);
            return View("Create",customerViewModel);
        }

        //
        // GET: /Customer/Edit/5

        public ActionResult Edit(int custID)
        {
            Customer customer = db.Customers.Find(custID);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.membershipTypeId = new SelectList(db.MembershipTypes, "ID", "Name", customer.membershipTypeId);
            return View(customer);
        }

        //
        // POST: /Customer/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.membershipTypeId = new SelectList(db.MembershipTypes, "ID", "Name", customer.membershipTypeId);
            return View(customer);
        }

        //
        // GET: /Customer/Delete/5

        public ActionResult Delete(int custID = 0)
        {
            Customer customer = db.Customers.Find(custID);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //
        // POST: /Customer/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int custID)
        {
            Customer customer = db.Customers.Find(custID);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}