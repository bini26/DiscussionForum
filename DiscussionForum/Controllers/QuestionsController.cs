using DiscussionForum.DAL;
using DiscussionForum.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DiscussionForum.Controllers
{
    [Authorize]
    public class QuestionsController : Controller
    {
        DiscussContext _context = new DiscussContext();
        // GET: Questions

        [HttpGet]
        public ActionResult MyQuestion()
        {


            int myid = int.Parse(Session["UserId"].ToString());
            // int myid = 5;
            return View(_context.Question.Where(x => x.UserId == myid).ToList());
        }

        [HttpGet]
        public ActionResult Question()
        {
            var list = new List<String>() { "Public", "Private" };
            ViewBag.list = list;
            QuestionModel ques = new QuestionModel()
            {
                Identity = "Public"
            };
            return View();

        }

        [HttpPost]
        public ActionResult Question(QuestionModel model)
        {
            model.UserId = int.Parse(Session["UserId"].ToString());
            //model.UserId = 5;
            _context.Question.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Question HasBeen Submitted Sucessfully";
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionModel questionModel = _context.Question.Find(id);
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
            QuestionModel questionModel = _context.Question.Find(id);
            _context.Question.Remove(questionModel);
            _context.SaveChanges();
            return RedirectToAction("MyQuestion");
        }

        //// GET: QuestionModels/Edit/5
        //public ActionResult EditQuestion(int? id)
        //{
        //    var list = new List<String>() { "Public", "Private" };
        //    ViewBag.list = list;
        //    QuestionModel ques = new QuestionModel()
        //    {
        //        Identity = "Public"
        //    };

        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    QuestionModel questionModel = _context.Question.Find(id);
        //    if (questionModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.UserId = new SelectList(_context.User_Details, "UserId", "FirstName", questionModel.UserId);
        //    return View(questionModel);
        //}

        //// POST: QuestionModels/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult EditQuestionPost([Bind(Include = "QId,Title,Question,Identity,AskedDate,UserId")] QuestionModel questionModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Entry(questionModel).State = EntityState.Modified;
        //        _context.SaveChanges();
        //        return RedirectToAction("MyQuestion");
        //    }
        //    ViewBag.UserId = new SelectList(_context.User_Details, "UserId", "FirstName", questionModel.UserId);
        //    return View(questionModel);
        //}

    }
}