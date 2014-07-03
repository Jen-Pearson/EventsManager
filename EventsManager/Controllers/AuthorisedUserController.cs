using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventsManager.Models;

namespace EventsManager.Controllers
{
    public class AuthorisedUserController : Controller
    {
        private CalendarEventContext db = new CalendarEventContext();

        public bool IsValidUser(string id)
        {
            var list = ((IObjectContextAdapter)db).ObjectContext.CreateObjectSet<ApprovedUser>();
            var anyItems = list.Any(u => u.ValidEmailAddress == id);
            return anyItems;
        }

        //
        // GET: /AuthorisedUser/

        public ActionResult Index()
        {
            return View(db.ApprovedUsers.ToList());
        }

        //
        // GET: /AuthorisedUser/Details/5

        public ActionResult Details(int id = 0)
        {
            ApprovedUser approveduser = db.ApprovedUsers.Find(id);
            if (approveduser == null)
            {
                return HttpNotFound();
            }
            return View(approveduser);
        }

        //
        // GET: /AuthorisedUser/Create

        public ActionResult Create()
        {
            throw new NotImplementedException();
        }

        //
        // POST: /AuthorisedUser/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApprovedUser approveduser)
        {
            throw new NotImplementedException();
        }

        //
        // GET: /AuthorisedUser/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ApprovedUser approveduser = db.ApprovedUsers.Find(id);
            if (approveduser == null)
            {
                return HttpNotFound();
            }
            return View(approveduser);
        }

        //
        // POST: /AuthorisedUser/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApprovedUser approveduser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(approveduser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(approveduser);
        }

        //
        // GET: /AuthorisedUser/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ApprovedUser approveduser = db.ApprovedUsers.Find(id);
            if (approveduser == null)
            {
                return HttpNotFound();
            }
            return View(approveduser);
        }

        //
        // POST: /AuthorisedUser/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ApprovedUser approveduser = db.ApprovedUsers.Find(id);
            db.ApprovedUsers.Remove(approveduser);
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