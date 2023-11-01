using DiscussionForum.DAL;
using DiscussionForum.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DiscussionForum.Controllers.Admin
{
    public class VoteModelsController : Controller
    {
        private DiscussContext db = new DiscussContext();

        // GET: VoteModels
        public ActionResult Index()
        {
            var vote = db.Vote.Include(v => v.Answer).Include(v => v.User);
            return View(vote.ToList());
        }

        // GET: VoteModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoteModel voteModel = db.Vote.Find(id);
            if (voteModel == null)
            {
                return HttpNotFound();
            }
            return View(voteModel);
        }

        // GET: VoteModels/Create
        public ActionResult Create()
        {
            ViewBag.AnswerId = new SelectList(db.Answer, "AnswerId", "Answer");
            ViewBag.UserId = new SelectList(db.User_Details, "UserId", "FirstName");
            return View();
        }

        // POST: VoteModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VoteId,Vote,AnswerId,UserId")] VoteModel voteModel)
        {
            if (ModelState.IsValid)
            {
                db.Vote.Add(voteModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnswerId = new SelectList(db.Answer, "AnswerId", "Answer", voteModel.AnswerId);
            ViewBag.UserId = new SelectList(db.User_Details, "UserId", "FirstName", voteModel.UserId);
            return View(voteModel);
        }

        // GET: VoteModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoteModel voteModel = db.Vote.Find(id);
            if (voteModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnswerId = new SelectList(db.Answer, "AnswerId", "Answer", voteModel.AnswerId);
            ViewBag.UserId = new SelectList(db.User_Details, "UserId", "FirstName", voteModel.UserId);
            return View(voteModel);
        }

        // POST: VoteModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VoteId,Vote,AnswerId,UserId")] VoteModel voteModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voteModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnswerId = new SelectList(db.Answer, "AnswerId", "Answer", voteModel.AnswerId);
            ViewBag.UserId = new SelectList(db.User_Details, "UserId", "FirstName", voteModel.UserId);
            return View(voteModel);
        }

        // GET: VoteModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoteModel voteModel = db.Vote.Find(id);
            if (voteModel == null)
            {
                return HttpNotFound();
            }
            return View(voteModel);
        }

        // POST: VoteModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VoteModel voteModel = db.Vote.Find(id);
            db.Vote.Remove(voteModel);
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
