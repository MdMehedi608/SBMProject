using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SBMProjectModel.DatabaseContext;
using SBMProjectModel.Models;

namespace SBMProjectApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: /Login/
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                using (SBMDbContext db = new SBMDbContext())
                {
                    var getUser = db.Logins.Where(x => x.UserName == login.UserName && x.Password == login.Password).FirstOrDefault();
                    if (getUser != null)
                    {
                        Session["UserId"] = login.UserId.ToString();
                        Session["UserName"] = login.UserName.ToString();
                        return RedirectToAction("Dasboard");
                    }
                }
            }
            return View(login);
        }

        public ActionResult Dasboard()
        {
            ViewBag.CallingForm = "Dashboard";
            ViewBag.CallingForm1 = "Dashboard";
            ViewBag.CallingViewPage = "#";
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }  
        }
        public ActionResult LogOut()
        {
            bool isCompleted = false;
            try
            {
                Session.Abandon();
                FormsAuthentication.SignOut();
                isCompleted = true;
            }
            catch (Exception e)
            {
                isCompleted = false;
                throw;
            }

            return Json(new {isCompleted = isCompleted, JsonRequestBehavior.AllowGet});
        }  
	}
}