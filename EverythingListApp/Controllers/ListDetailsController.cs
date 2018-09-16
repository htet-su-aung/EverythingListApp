using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EverythingListApp.Models;

namespace EverythingListApp.Controllers
{
    public class ListDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ListDetails
        public ActionResult Index()
        {
            return View(db.ListDetails.ToList());
        }

        // GET: ListDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListDetail listDetail = db.ListDetails.Find(id);
            if (listDetail == null)
            {
                return HttpNotFound();
            }
            return View(listDetail);
        }

        // GET: ListDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,ListID,ItemQty")] ListDetail listDetail)
        {
            if (ModelState.IsValid)
            {
                db.ListDetails.Add(listDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listDetail);
        }

        // GET: ListDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListDetail listDetail = db.ListDetails.Find(id);
            if (listDetail == null)
            {
                return HttpNotFound();
            }
            return View(listDetail);
        }

        // POST: ListDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,ListID,ItemQty")] ListDetail listDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listDetail);
        }

        // GET: ListDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListDetail listDetail = db.ListDetails.Find(id);
            if (listDetail == null)
            {
                return HttpNotFound();
            }
            return View(listDetail);
        }

        // POST: ListDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListDetail listDetail = db.ListDetails.Find(id);
            db.ListDetails.Remove(listDetail);
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
