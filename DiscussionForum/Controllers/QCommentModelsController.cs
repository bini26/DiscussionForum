using DiscussionForum.DAL;
using DiscussionForum.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DiscussionForum.Controllers.Admin
{
    public class QCommentModelsController : Controller
    {
        private DiscussContext db = new DiscussContext();

        // GET: QCommentModels
        public ActionResult Index()
        {
            var question_Comment = db.Question_Comment.Include(q => q.Question).Include(q => q.User);
            return View(question_Comment.ToList());
        }

        // GET: QCommentModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QCommentModel qCommentModel = db.Question_Comment.Find(id);
            if (qCommentModel == null)
            {
                return HttpNotFound();
            }
            return View(qCommentModel);
        }

        // GET: QCommentModels/Create
        public ActionResult Create()
        {
            ViewBag.QId = new SelectList(db.Question, "QId", "Title");
            ViewBag.UserId = new SelectList(db.User_Details, "UserId", "FirstName");
            return View();
        }

        // POST: QCommentModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QCommentId,UserId,QId,Comment")] QCommentModel qCommentModel)
        {
            if (ModelState.IsValid)
            {
                db.Question_Comment.Add(qCommentModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QId = new SelectList(db.Question, "QId", "Title", qCommentModel.QId);
            ViewBag.UserId = new SelectList(db.User_Details, "UserId", "FirstName", qCommentModel.UserId);
            return View(qCommentModel);
        }

        // GET: QCommentModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QCommentModel qCommentModel = db.Question_Comment.Find(id);
            if (qCommentModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.QId = new SelectList(db.Question, "QId", "Title", qCommentModel.QId);
            ViewBag.UserId = new SelectList(db.User_Details, "UserId", "FirstName", qCommentModel.UserId);
            return View(qCommentModel);
        }

        // POST: QCommentModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QCommentId,UserId,QId,Comment")] QCommentModel qCommentModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qCommentModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QId = new SelectList(db.Question, "QId", "Title", qCommentModel.QId);
            ViewBag.UserId = new SelectList(db.User_Details, "UserId", "FirstName", qCommentModel.UserId);
            return View(qCommentModel);
        }

        // GET: QCommentModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QCommentModel qCommentModel = db.Question_Comment.Find(id);
            if (qCommentModel == null)
            {
                return HttpNotFound();
            }
            return View(qCommentModel);
        }

        // POST: QCommentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QCommentModel qCommentModel = db.Question_Comment.Find(id);
            db.Question_Comment.Remove(qCommentModel);
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
