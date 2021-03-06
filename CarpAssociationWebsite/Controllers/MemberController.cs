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
    public class MemberController : Controller
    {
        private CarpAssociationWebsiteContext db = new CarpAssociationWebsiteContext();

        // GET: Member
        public ActionResult Index()
        {
            var members = db.Members.Include(m => m.EconomyAccount);
            return View(members.ToList());
        }

        // GET: Member/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Member/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.EconomyAccounts, "EconomyAccountId", "EconomyAccountId");
            return View();
        }

        // POST: Member/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,PersonalIdentificationNumber,PhoneNumber,IsMarried,NetIncome,City,State,Address")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("StatisticsAndInformationDashboardIndex", "StatisticsAndInformationDashboard");
            }

            ViewBag.Id = new SelectList(db.EconomyAccounts, "EconomyAccountId", "EconomyAccountId", member.Id);
            return View(member);
        }

        // GET: Member/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.EconomyAccounts, "EconomyAccountId", "EconomyAccountId", member.Id);
            return View(member);
        }

        // POST: Member/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,PersonalIdentificationNumber,PhoneNumber,IsMarried,NetIncome,City,State,Address")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("StatisticsAndInformationDashboardIndex", "StatisticsAndInformationDashboard");
            }
            ViewBag.Id = new SelectList(db.EconomyAccounts, "EconomyAccountId", "EconomyAccountId", member.Id);
            return View(member);
        }

        // GET: Member/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Member/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
            db.SaveChanges();
            //return RedirectToAction("Index");
            return RedirectToAction("StatisticsAndInformationDashboardIndex", "StatisticsAndInformationDashboard");
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
