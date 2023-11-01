using DiscussionForum.DAL;
using DiscussionForum.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DiscussionForum.Controllers.Admin
{
    public class ACommentModelsController : Controller
    {
        private DiscussContext db = new DiscussContext();

        // GET: ACommentModels
        public ActionResult Index()
        {
            var answer_Comment = db.Answer_Comment.Include(a => a.Answer).Include(a => a.User);
            return View("~/Views/Admin/Index.cshtml", answer_Comment.ToList());
        }

        // GET: ACommentModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACommentModel aCommentModel = db.Answer_Comment.Find(id);
            if (aCommentModel == null)
            {
                return HttpNotFound();
            }
            return View(aCommentModel);
        }

        // GET: ACommentModels/Create
        public ActionResult Create()
        {
            ViewBag.AnswerId = new SelectList(db.Answer, "AnswerId", "Answer");
            ViewBag.UserId = new SelectList(db.User_Details, "UserId", "FirstName");
            return View();
        }

        // POST: ACommentModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ACommentId,UserId,AnswerId,Comment")] ACommentModel aCommentModel)
        {
            if (ModelState.IsValid)
            {
                db.Answer_Comment.Add(aCommentModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnswerId = new SelectList(db.Answer, "AnswerId", "Answer", aCommentModel.AnswerId);
            ViewBag.UserId = new SelectList(db.User_Details, "UserId", "FirstName", aCommentModel.UserId);
            return View(aCommentModel);
        }

        // GET: ACommentModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACommentModel aCommentModel = db.Answer_Comment.Find(id);
            if (aCommentModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnswerId = new SelectList(db.Answer, "AnswerId", "Answer", aCommentModel.AnswerId);
            ViewBag.UserId = new SelectList(db.User_Details, "UserId", "FirstName", aCommentModel.UserId);
            return View(aCommentModel);
        }

        // POST: ACommentModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ACommentId,UserId,AnswerId,Comment")] ACommentModel aCommentModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aCommentModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnswerId = new SelectList(db.Answer, "AnswerId", "Answer", aCommentModel.AnswerId);
            ViewBag.UserId = new SelectList(db.User_Details, "UserId", "FirstName", aCommentModel.UserId);
            return View(aCommentModel);
        }

        // GET: ACommentModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACommentModel aCommentModel = db.Answer_Comment.Find(id);
            if (aCommentModel == null)
            {
                return HttpNotFound();
            }
            return View(aCommentModel);
        }

        // POST: ACommentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ACommentModel aCommentModel = db.Answer_Comment.Find(id);
            db.Answer_Comment.Remove(aCommentModel);
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
