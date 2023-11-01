using DiscussionForum.DAL;
using DiscussionForum.Models;
using System.Linq;
using System.Web.Mvc;

namespace DiscussionForum.Controllers
{
    [Authorize]
    public class VoteController : Controller
    {
        private DiscussContext db = new DiscussContext();

        [Authorize]
        // Upvote action
        [HttpPost]
        public ActionResult Upvote(int answerId)
        {
            var userId = int.Parse(Session["UserId"].ToString()); // Replace this with your actual user ID (you might get it from the current user's session or authentication)
            var vote = db.Vote.SingleOrDefault(v => v.AnswerId == answerId && v.UserId == userId);

            if (vote == null)
            {
                vote = new VoteModel
                {
                    AnswerId = answerId,
                    UserId = userId,
                    Vote = 1 // 1 for upvote
                };
                db.Vote.Add(vote);
            }
            else if (vote.Vote == 2) // If the user already downvoted, change the vote to upvote
            {
                vote.Vote = 1;
            }

            db.SaveChanges();

            // Get the upvote count for the answer
            int upvoteCount = db.Vote.Count(v => v.AnswerId == answerId && v.Vote == 1);

            // Get the downvote count for the answer
            int downvoteCount = db.Vote.Count(v => v.AnswerId == answerId && v.Vote == 2);

            return Json(new { success = true, upvoteCount, downvoteCount }, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        // Downvote action
        [HttpPost]
        public ActionResult Downvote(int answerId)
        {
            var userId = int.Parse(Session["UserId"].ToString()); // Replace this with your actual user ID (you might get it from the current user's session or authentication)
            var vote = db.Vote.SingleOrDefault(v => v.AnswerId == answerId && v.UserId == userId);

            if (vote == null)
            {
                vote = new VoteModel
                {
                    AnswerId = answerId,
                    UserId = userId,
                    Vote = 2 // 2 for downvote
                };
                db.Vote.Add(vote);
            }
            else if (vote.Vote == 1) // If the user already upvoted, change the vote to downvote
            {
                vote.Vote = 2;
            }

            db.SaveChanges();

            // Get the upvote count for the answer
            int upvoteCount = db.Vote.Count(v => v.AnswerId == answerId && v.Vote == 1);

            // Get the downvote count for the answer
            int downvoteCount = db.Vote.Count(v => v.AnswerId == answerId && v.Vote == 2);

            return Json(new { success = true, upvoteCount, downvoteCount }, JsonRequestBehavior.AllowGet);
        }
    }
}
