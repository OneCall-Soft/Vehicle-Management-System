using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vehicle_Management_System.Models;

namespace Vehicle_Management_System.Controllers
{
    public class LoginController : Controller
    {
         ILogin _logins = null;

        public LoginController() { }
        public LoginController(ILogin login)
        {
            _logins = login;
        }
        
        [HttpGet]
        // GET: Login
        public ActionResult Index()
        {
            @ViewBag.alertclass = "d-none";
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel login)
        {
            if (_logins.CheckUser(login))
            {
                @ViewBag.alertclass = "d-none";
                Session["user"] = "Shivaay";
                Session["loginid"] = "100";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.error = "invalid user & password!";
                @ViewBag.alertclass=" ";
                return View();
            }
        }

        [HttpGet]
        // GET: Login
        public ActionResult Registeration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registeration(LoginModel login)
        {
            if (_logins.CheckUser(login))
            {
                Session["user"] = "Shivaay";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.error = "invalid user & password!";
                @ViewBag.toastclass = " show";
                return View();
            }
        }

    }
}
