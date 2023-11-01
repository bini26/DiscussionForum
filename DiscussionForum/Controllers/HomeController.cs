using DiscussionForum.DAL;
using DiscussionForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DiscussionForum.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        DiscussContext discussContext = new DiscussContext();
        /*public ActionResult Index(String search)
        {
            return View(discussContext.Question.Where(x=> x.Body.StartsWith(search)));
        }*/
        public ActionResult Index(String search)
        {

            // List<AskQuestionModel> questions = GetQuestions();

            //return View(questions.Where(x => x.Body.StartsWith(search)||search==null ));
            return View(discussContext.Question.Where(x => x.Question.ToLower().Contains(search.ToLower()) || search == null));

        }
        public ActionResult AnswerView()
        {
            List<QuestionWithUserModel> questions = GetQuestions();
            return View(questions);
        }
        public List<QuestionWithUserModel> GetQuestions()
        {

            
            using (var context = new DiscussContext())
            {
                var result = context.Question
                    .Include("User") // Include the User entity in the query
                    .AsNoTracking() // Disable change tracking
                    .Select(q => new QuestionWithUserModel
                    {
                        QId = q.QId,
                        AskedDate = q.AskedDate,
                        Question = q.Question,
                        Title = q.Title,
                        Identity = q.Identity,
                        UserId = q.UserId,
                        User = q.User // Add this line to populate the User property
                    })
                    .ToList();

                return result;
            }

        }
    }

}

