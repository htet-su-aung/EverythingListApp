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
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace EverythingListApp.Controllers
{
    public class ListController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager userManager;

        public ListController()
        {

        }

        public ListController(ApplicationUserManager user_manager)
        {
            UserManager = user_manager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                userManager = value;
            }
        }

        // GET: List
        public ActionResult Index()
        {
            var tBLists = db.TBLists.Include(l => l.Category).Include(u=>u.User);
            return View(tBLists.ToList());
        }

        // GET: List
        public ActionResult MyList()
        {
            string userId = User.Identity.GetUserId();
            var tBLists = db.TBLists.Include(l => l.Category).Where(x=>x.UserID==userId);
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
            //www.stackoverflow.com/questions/37579979/mvc-5-viewmodel-passing-lists-for-the-create
            ListCreateVM listCreateVM = new ListCreateVM();
            List<Item> Items = db.Items.ToList();
            foreach(Item i in Items)
            {
                listCreateVM.ListDetailsQTY.Add(new ListDetailsQTY(i.ItemID, i.ItemName));
            }
            
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            return View(listCreateVM);
        }

        // POST: List/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ListCreateVM listCreateVM)
        {
            if (ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();
                ApplicationUser user = db.Users.Where(u => u.Id == userId).FirstOrDefault();
                List list = new List(listCreateVM.ListName, listCreateVM.ListDescription, listCreateVM.PplQty, listCreateVM.Location, listCreateVM.StartDate, listCreateVM.EndDate, listCreateVM.Duration, listCreateVM.CategoryID);
                list.User = user;
                list.UserID = userId;
                db.TBLists.Add(list);
                var selectedListDetail = listCreateVM.ListDetailsQTY.Where(x => x.IsChecked).Select(x => new ListDetail(x.ItemID, x.ItemQty,list.ListID)).ToList();
                selectedListDetail.ForEach(s => db.ListDetails.Add(s));
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", listCreateVM.CategoryID);
            return View(listCreateVM);
        }

        // GET: List/Edit/5
        public ActionResult Edit(int? id)
        {
            ListCreateVM listCreateVM = new ListCreateVM();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List list = db.TBLists.Find(id);
            if (list == null)
            {
                return HttpNotFound();
            } else
            {
                var selectedlistDetails = db.ListDetails.Where(x => x.ListID == list.ListID).ToList();
                List<Item> Items = db.Items.ToList();
                foreach (Item i in Items)
                {
                    ListDetailsQTY ldQTY = new ListDetailsQTY(i.ItemID, i.ItemName);
                    if(selectedlistDetails.Any(x => x.ItemID == i.ItemID))
                    {
                        ldQTY.ItemQty = db.ListDetails.Where(x=>x.ListID==list.ListID && x.ItemID==i.ItemID).FirstOrDefault().ItemQty;
                        //ldQTY.ItemQty = tmp_Item.ItemQty;
                        ldQTY.IsChecked = true;
                    }
                    listCreateVM.ListDetailsQTY.Add(ldQTY);
                }
            }

            listCreateVM.ListID = list.ListID;
            listCreateVM.ListName = list.ListName;
            listCreateVM.ListDescription = list.ListDescription;
            listCreateVM.PplQty = list.PplQty;
            listCreateVM.Location = list.Location;
            listCreateVM.StartDate = list.StartDate;
            listCreateVM.EndDate = list.EndDate;
            listCreateVM.Duration = list.Duration;

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", list.CategoryID);
            return View(listCreateVM);
        }

        // POST: List/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ListCreateVM listCreateVM)
        {
            if (ModelState.IsValid)
            {
                List list = new List(listCreateVM.ListID,listCreateVM.ListName, listCreateVM.ListDescription, listCreateVM.PplQty, listCreateVM.Location, listCreateVM.StartDate, listCreateVM.EndDate, listCreateVM.Duration, listCreateVM.CategoryID);
                list.UserID = User.Identity.GetUserId();
                db.Entry(list).State = EntityState.Modified;

                List<Item> Items = db.Items.ToList();
                List<ListDetail> listDetails = new List<ListDetail>();
                foreach (Item i in Items)
                {
                    var selectedlistDetails = db.ListDetails.Where(x => x.ListID == list.ListID).ToList();
                    ListDetail tmp_listDetail = new ListDetail(i.ItemID,list.ListID);
                    tmp_listDetail.List = list;
                    tmp_listDetail.Item = i;

                    // www.stackoverflow.com/questions/46351181/attaching-an-entity-of-type-xxx-enquirylineitem-failed-because-another-entity?rq=1

                    if (selectedlistDetails.Any(x => x.ItemID == i.ItemID) && listCreateVM.ListDetailsQTY.Any(x=>x.ItemID==i.ItemID && x.IsChecked==true))
                    {
                        ListDetail ld = db.ListDetails.Where(x => x.ListID == tmp_listDetail.ListID && x.ItemID == i.ItemID).FirstOrDefault();
                        ld.ItemQty = listCreateVM.ListDetailsQTY.Where(x => x.ItemID == i.ItemID && x.IsChecked == true).FirstOrDefault().ItemQty;
                        db.Entry(ld).Property(x => x.ItemQty).IsModified = true;
                    }
                    else if (selectedlistDetails.Any(x => x.ItemID == i.ItemID) && listCreateVM.ListDetailsQTY.Any(x => x.ItemID == i.ItemID && x.IsChecked == false))
                    {
                        ListDetail ld = db.ListDetails.Where(x => x.ListID == tmp_listDetail.ListID && x.ItemID == i.ItemID).FirstOrDefault();
                        db.ListDetails.Remove(ld);
                    } else if(listCreateVM.ListDetailsQTY.Any(x => x.ItemID == i.ItemID && x.IsChecked == true))
                    {
                        tmp_listDetail.ItemQty = listCreateVM.ListDetailsQTY.Where(x => x.ItemID == i.ItemID && x.IsChecked == true).FirstOrDefault().ItemQty;
                        db.ListDetails.Add(tmp_listDetail);
                    }
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", listCreateVM.CategoryID);
            return View(listCreateVM);
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
