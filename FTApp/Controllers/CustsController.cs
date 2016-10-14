using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FTApp.Models;

namespace FTApp.Controllers
{
    public class CustsController : Controller
    {
        private FTAppEntities db = new FTAppEntities();

        // GET: Custs
        public ActionResult Index()
        {
            return View(db.Custs.ToList());
        }

        // GET: Custs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cust cust = db.Custs.Find(id);
            if (cust == null)
            {
                return HttpNotFound();
            }
            return View(cust);
        }

        // GET: Custs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Custs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,FirstName,LastName,Age,BirthMonth,FavoriteColor,NumberOfSiblings")] Cust cust)
        {
            if (ModelState.IsValid)
            {
                db.Custs.Add(cust);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cust);
        }

        // GET: Custs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cust cust = db.Custs.Find(id);
            if (cust == null)
            {
                return HttpNotFound();
            }
            return View(cust);
        }

        // POST: Custs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,FirstName,LastName,Age,BirthMonth,FavoriteColor,NumberOfSiblings")] Cust cust)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cust).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cust);
        }

        // GET: Custs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cust cust = db.Custs.Find(id);
            if (cust == null)
            {
                return HttpNotFound();
            }
            return View(cust);
        }

        // POST: Custs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cust cust = db.Custs.Find(id);
            db.Custs.Remove(cust);
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
