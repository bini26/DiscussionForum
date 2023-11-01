using DiscussionForum.DAL;
using DiscussionForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DiscussionForum.Controllers
{
    public class AnswerController : Controller
    {
        DiscussContext context = new DiscussContext();
        // GET: AnswerView
        public ActionResult AnswerView()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult SubmitAnswer(FormCollection answer)
        {

            var answerModel = new AnswerModel()
            {
                Answer = answer["Answer"],
                QId = int.Parse(answer["QId"]),
                AnswerDate = DateTime.Now,
                UserId = int.Parse(Session["UserId"].ToString()),

            };
            context.Answer.Add(answerModel);
            context.SaveChanges();

           

            return Json("DataSaved");


            
        }

        public class QuestionAndAnswersViewModel
        {
            public QuestionModel Question { get; set; }
            public List<AnswerModel> Answers { get; set; }
        }

        [HttpGet]
        public ActionResult See_Other_Answers(int id)
        {
            var question = context.Question.FirstOrDefault(q => q.QId == id);
            var answers = context.Answer.Where(a => a.QId == id).ToList();
            // Calculate the vote counts for each answer
            foreach (var answer in answers)
            {
                answer.upvoteCount = context.Vote.Count(v => v.AnswerId == answer.AnswerId && v.Vote == 1);
                answer.downvoteCount = context.Vote.Count(v => v.AnswerId == answer.AnswerId && v.Vote == 2);
                
            }
            var viewModel = new QuestionAndAnswersViewModel
            {
                Question = question,
                Answers = answers
            };


            return View(viewModel);

        }
    }
}
