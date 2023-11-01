using DiscussionForum.DAL;
using DiscussionForum.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DiscussionForum.Controllers.Admin
{
    [customAuthorization]
    public class QuestionModelsController : Controller
    {
        private DiscussContext db = new DiscussContext();

        // GET: QuestionModels
        public ActionResult Index()
        {
            var question = db.Question.Include(q => q.User);
            return View(question.ToList());
        }

        // GET: QuestionModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionModel questionModel = db.Question.Find(id);
            if (questionModel == null)
            {
                return HttpNotFound();
            }
            return View(questionModel);
        }

        // GET: QuestionModels/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.User_Details, "UserId", "FirstName");
            return View();
        }

        // POST: QuestionModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QId,Title,Question,Identity,AskedDate,UserId")] QuestionModel questionModel)
        {
            if (ModelState.IsValid)
            {
                db.Question.Add(questionModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.User_Details, "UserId", "FirstName", questionModel.UserId);
            return View(questionModel);
        }

        // GET: QuestionModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionModel questionModel = db.Question.Find(id);
            if (questionModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.User_Details, "UserId", "FirstName", questionModel.UserId);
            return View(questionModel);
        }

        // POST: QuestionModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QId,Title,Question,Identity,AskedDate,UserId")] QuestionModel questionModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.User_Details, "UserId", "FirstName", questionModel.UserId);
            return View(questionModel);
        }

        // GET: QuestionModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionModel questionModel = db.Question.Find(id);
            if (questionModel == null)
            {
                return HttpNotFound();
            }
            return View(questionModel);
        }

        // POST: QuestionModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuestionModel questionModel = db.Question.Find(id);
            db.Question.Remove(questionModel);
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
