using DiscussionForum.DAL;
using DiscussionForum.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DiscussionForum.Controllers.Admin
{
    public class AnswerModelsController : Controller
    {
        private DiscussContext db = new DiscussContext();

        // GET: AnswerModels
        public ActionResult Index()
        {
            var answer = db.Answer.Include(a => a.Question).Include(a => a.User);
            return View(answer.ToList());
        }

        // GET: AnswerModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnswerModel answerModel = db.Answer.Find(id);
            if (answerModel == null)
            {
                return HttpNotFound();
            }
            return View(answerModel);
        }

        // GET: AnswerModels/Create
        public ActionResult Create()
        {
            ViewBag.QId = new SelectList(db.Question, "QId", "Title");
            ViewBag.UserId = new SelectList(db.User_Details, "UserId", "FirstName");
            return View();
        }

        // POST: AnswerModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnswerId,AnswerDate,QId,UserId,Answer")] AnswerModel answerModel)
        {
            if (ModelState.IsValid)
            {
                db.Answer.Add(answerModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QId = new SelectList(db.Question, "QId", "Title", answerModel.QId);
            ViewBag.UserId = new SelectList(db.User_Details, "UserId", "FirstName", answerModel.UserId);
            return View(answerModel);
        }

        // GET: AnswerModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnswerModel answerModel = db.Answer.Find(id);
            if (answerModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.QId = new SelectList(db.Question, "QId", "Title", answerModel.QId);
            ViewBag.UserId = new SelectList(db.User_Details, "UserId", "FirstName", answerModel.UserId);
            return View(answerModel);
        }

        // POST: AnswerModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnswerId,AnswerDate,QId,UserId,Answer")] AnswerModel answerModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(answerModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QId = new SelectList(db.Question, "QId", "Title", answerModel.QId);
            ViewBag.UserId = new SelectList(db.User_Details, "UserId", "FirstName", answerModel.UserId);
            return View(answerModel);
        }

        // GET: AnswerModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnswerModel answerModel = db.Answer.Find(id);
            if (answerModel == null)
            {
                return HttpNotFound();
            }
            return View(answerModel);
        }

        // POST: AnswerModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnswerModel answerModel = db.Answer.Find(id);
            db.Answer.Remove(answerModel);
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
