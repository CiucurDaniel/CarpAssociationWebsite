using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarpAssociationWebsite.DataAccessLayer;
using CarpAssociationWebsite.Models;

namespace CarpAssociationWebsite.Controllers
{
    public class EconomyAccountInterestController : Controller
    {
        private CarpAssociationWebsiteContext db = new CarpAssociationWebsiteContext();

        // GET: EconomyAccountInterest
        public ActionResult Index()
        {
            return View(db.EconomyAccountInterests.ToList());
        }

        // GET: EconomyAccountInterest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EconomyAccountInterest economyAccountInterest = db.EconomyAccountInterests.Find(id);
            if (economyAccountInterest == null)
            {
                return HttpNotFound();
            }
            return View(economyAccountInterest);
        }

        // GET: EconomyAccountInterest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EconomyAccountInterest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Percentage,Date")] EconomyAccountInterest economyAccountInterest)
        {
            if (ModelState.IsValid)
            {
                db.EconomyAccountInterests.Add(economyAccountInterest);
                db.SaveChanges();
                return RedirectToAction("InterestRateDashboardIndex", "InterestRatesDashboard");
            }

            return View(economyAccountInterest);
        }

        // GET: EconomyAccountInterest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EconomyAccountInterest economyAccountInterest = db.EconomyAccountInterests.Find(id);
            if (economyAccountInterest == null)
            {
                return HttpNotFound();
            }
            return View(economyAccountInterest);
        }

        // POST: EconomyAccountInterest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Percentage,Date")] EconomyAccountInterest economyAccountInterest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(economyAccountInterest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(economyAccountInterest);
        }

        // GET: EconomyAccountInterest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EconomyAccountInterest economyAccountInterest = db.EconomyAccountInterests.Find(id);
            if (economyAccountInterest == null)
            {
                return HttpNotFound();
            }
            return View(economyAccountInterest);
        }

        // POST: EconomyAccountInterest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EconomyAccountInterest economyAccountInterest = db.EconomyAccountInterests.Find(id);
            db.EconomyAccountInterests.Remove(economyAccountInterest);
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
