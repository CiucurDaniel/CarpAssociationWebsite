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
    public class EconomyAccountController : Controller
    {
        private CarpAssociationWebsiteContext db = new CarpAssociationWebsiteContext();

        // GET: EconomyAccount
        public ActionResult Index()
        {
            var economyAccounts = db.EconomyAccounts.Include(e => e.Member);
            return View(economyAccounts.ToList());
        }

        // GET: EconomyAccount/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EconomyAccount economyAccount = db.EconomyAccounts.Find(id);
            if (economyAccount == null)
            {
                return HttpNotFound();
            }
            return View(economyAccount);
        }

        // GET: EconomyAccount/Create
        public ActionResult Create()
        {
            ViewBag.EconomyAccountId = new SelectList(db.Members, "Id", "FirstName");
            return View();
        }

        // POST: EconomyAccount/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EconomyAccountId,DepositAmount,DateStarted,Duration,InterestRate,ProfitFromInterest,TaxedAmmount")] EconomyAccount economyAccount)
        {
            if (ModelState.IsValid)
            {
                db.EconomyAccounts.Add(economyAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EconomyAccountId = new SelectList(db.Members, "Id", "FirstName", economyAccount.EconomyAccountId);
            return View(economyAccount);
        }

        // GET: EconomyAccount/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EconomyAccount economyAccount = db.EconomyAccounts.Find(id);
            if (economyAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.EconomyAccountId = new SelectList(db.Members, "Id", "FirstName", economyAccount.EconomyAccountId);
            return View(economyAccount);
        }

        // POST: EconomyAccount/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EconomyAccountId,DepositAmount,DateStarted,Duration,InterestRate,ProfitFromInterest,TaxedAmmount")] EconomyAccount economyAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(economyAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EconomyAccountId = new SelectList(db.Members, "Id", "FirstName", economyAccount.EconomyAccountId);
            return View(economyAccount);
        }

        // GET: EconomyAccount/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EconomyAccount economyAccount = db.EconomyAccounts.Find(id);
            if (economyAccount == null)
            {
                return HttpNotFound();
            }
            return View(economyAccount);
        }

        // POST: EconomyAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EconomyAccount economyAccount = db.EconomyAccounts.Find(id);
            db.EconomyAccounts.Remove(economyAccount);
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
