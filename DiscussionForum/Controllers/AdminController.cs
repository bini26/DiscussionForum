using DiscussionForum.DAL;
using DiscussionForum.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace DiscussionForum.Controllers
{
    [customAuthorization]
    public class AdminController : Controller
    {
        // GET: Admin

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminLogin(AdminModel model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new DiscussContext())
                {
                    var user = context.Admin.FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);
                    if (user != null)
                    {
                        Session["UserId"] = user.Id.ToString();
                        Session["UserName"] = user.UserName.ToString();
                        FormsAuthentication.SetAuthCookie(user.UserName.ToString(), false);

                        return RedirectToAction("Index", "Admin");
                    }
                }
            }

            ModelState.AddModelError("", "Invalid email or password");
            return View(model);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("AdminLogin");
        }
    }
}