using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiscussionForum.DAL;
using DiscussionForum.Models;

namespace DiscussionForum.Controllers
{
    public class AdminModelsController : Controller
    {
        private DiscussContext db = new DiscussContext();

        // GET: AdminModels
        public ActionResult Index()
        {
            return View(db.Admin.ToList());
        }

        // GET: AdminModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminModel adminModel = db.Admin.Find(id);
            if (adminModel == null)
            {
                return HttpNotFound();
            }
            return View(adminModel);
        }

        // GET: AdminModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Password")] AdminModel adminModel)
        {
            if (ModelState.IsValid)
            {
                db.Admin.Add(adminModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adminModel);
        }

        // GET: AdminModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminModel adminModel = db.Admin.Find(id);
            if (adminModel == null)
            {
                return HttpNotFound();
            }
            return View(adminModel);
        }

        // POST: AdminModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Password")] AdminModel adminModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminModel);
        }

        // GET: AdminModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminModel adminModel = db.Admin.Find(id);
            if (adminModel == null)
            {
                return HttpNotFound();
            }
            return View(adminModel);
        }

        // POST: AdminModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminModel adminModel = db.Admin.Find(id);
            db.Admin.Remove(adminModel);
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
