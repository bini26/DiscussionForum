using System.Web.Mvc;

namespace DiscussionForum.Controllers
{
    public class TestPostController : Controller
    {
        // GET: TestPost
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Test(FormCollection colletion)
        {
            var comment = colletion["comment"];
            return View();
        }

    }
}