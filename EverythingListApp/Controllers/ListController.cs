using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EverythingListApp.Models;
using EverythingListApp.ViewModels;

namespace EverythingListApp.Controllers
{
    public class ListController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: List
        public ActionResult Index()
        {
            var tBLists = db.TBLists.Include(l => l.Category);
            return View(tBLists.ToList());
        }

        // GET: List/Details/5
        public ActionResult Details(int? id)
        {
            List<ListDetail> ListDetails;
            List list = db.TBLists.Where(x => x.ListID == id).FirstOrDefault();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                ListDetails = db.ListDetails
                                .Where(m => m.ListID == id)
                                .Include(mc => mc.Item)
                                .ToList();
            }
            if (list == null)
            {
                return HttpNotFound();
            }
            ListItemVM listItemVM = new ListItemVM(list, ListDetails);
            return View(listItemVM);
        }

        // GET: List/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: List/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ListID,ListName,ListDescription,PplQty,Location,StartDate,EndDate,Duration,CategoryID")] List list)
        {
            if (ModelState.IsValid)
            {
                db.TBLists.Add(list);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", list.CategoryID);
            return View(list);
        }

        // GET: List/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List list = db.TBLists.Find(id);
            if (list == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", list.CategoryID);
            return View(list);
        }

        // POST: List/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ListID,ListName,ListDescription,PplQty,Location,StartDate,EndDate,Duration,CategoryID")] List list)
        {
            if (ModelState.IsValid)
            {
                db.Entry(list).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", list.CategoryID);
            return View(list);
        }

        // GET: List/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List list = db.TBLists.Find(id);
            if (list == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }

        // POST: List/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            List list = db.TBLists.Find(id);
            db.TBLists.Remove(list);
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
