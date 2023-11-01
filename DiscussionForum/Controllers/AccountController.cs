using DiscussionForum.DAL;
using DiscussionForum.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace DiscussionForum.Controllers
{
    public class AccountController : Controller
    {


        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new DiscussContext())
                {
                    var user = context.User_Details.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
                    if (user != null)
                    {
                        Session["UserId"] = user.UserId.ToString();
                        Session["FirstName"] = user.FirstName.ToString();
                        Session["LastName"] = user.LastName.ToString();
                        FormsAuthentication.SetAuthCookie(user.FirstName.ToString(), false);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            ModelState.AddModelError("", "Invalid email or password");
            return View(model);
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(UserModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password != model.ConfirmPassword)
                {
                    ModelState.AddModelError("", "Password and Confirm Password do not match");
                    return View(model);
                }


                using (var context = new DiscussContext())
                {

                    bool emailExists = context.User_Details.Any(u => u.Email == model.Email);
                    if (emailExists)
                    {
                        ModelState.AddModelError("", "Email already exist");
                        return View(model);
                    }
                    else
                    {
                        model.role = "User";
                        context.User_Details.Add(model);
                        context.SaveChanges();
                    }
                }

                ModelState.Clear();
                ViewBag.Message = "Registration Successful";
                return RedirectToAction("Login");
            }

            return View(model);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }





    }
}