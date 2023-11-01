using DiscussionForum.DAL;
using DiscussionForum.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DiscussionForum.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        DiscussContext context = new DiscussContext();
        public class QuestionCommentModel
        {
            public List<QCommentModel> Question_Comment { get; set; }
            public int Qid { get; set; }
        }

        [AllowAnonymous]
        public ActionResult Question_CommentView(int Qid)
        {
            //var QComment = context.Question_Comment.Where(q => q.QId == Qid).ToList();
            //return View(QComment);
            QuestionCommentModel qModel = new QuestionCommentModel();
            qModel.Question_Comment = context.Question_Comment.Where(a => a.QId == Qid).ToList();
            qModel.Qid = Qid;

            return View(qModel);

        }

        public class MyModel
        {
            public List<ACommentModel> Answer_Comment { get; set; }
            public int AId { get; set; }
        }

        [AllowAnonymous]
        public ActionResult See_Answer_Comment(int id)
        {
            MyModel model = new MyModel();
            model.Answer_Comment = context.Answer_Comment.Where(a => a.AnswerId == id).ToList();
            model.AId = id;

            return View(model);
        }

        [HttpPost]
        public ActionResult SubmitQuestionComment(FormCollection comment)
        {
           
            var v = comment["QId"];
            
            var qComment = new QCommentModel()
            {
                Comment = comment["Comment"],
                QId = int.Parse(comment["QId"]),
                UserId = int.Parse(Session["UserId"].ToString())

            };


            context.Question_Comment.Add(qComment);
            context.SaveChanges();
            return Json("DataSaved");
        }


        
        [HttpPost]
        public ActionResult SubmitAnswerComment(FormCollection Acomment)
        {
            var v = Acomment["AId"];
            var comment = Acomment["Comment"];
            var aComment = new ACommentModel()
            {
                Comment = Acomment["Comment"],
                AnswerId = int.Parse(Acomment["AId"]),
                UserId = int.Parse(Session["UserId"].ToString())

            };
            context.Answer_Comment.Add(aComment);
            context.SaveChanges();
            return Json("DataSaved");
        }
    }
}
