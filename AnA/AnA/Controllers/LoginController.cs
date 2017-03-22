using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnA.ViewModel;
using AnA.Models;

namespace AnA.Controllers
{
    public class LoginController : Controller
    {
        private WEB_API2Entities db = new WEB_API2Entities();
        // GET: /Login/
        public ActionResult LoginPage()
        {
            return View();
        }

        //Post method /Login/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginPage(Ali_LoginViewModel User)
        {
            // Checking username password using database comparing.
            if(ModelState.IsValid)
            {
                try
                {
                    var details = db.ALI_LOGINDTLS.Single(A => A.UserName == User.UserName && A.Password == User.Password);
                    if (details.UserName != null)
                    {
                        return RedirectToAction("MainPage", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Your username or password is incorrect");
                    }
                }catch(Exception ex)
                {
                    ModelState.AddModelError("", "Your username or password is incorrect");
                    Console.WriteLine(ex);
                }
                
            }
            return View(User);
        }

        //Get Register form
        public ActionResult Register()
        {
            return View();
        }

        //Post Method / Register//
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Ali_RegisterViewModel NewUser)
        {
            if(ModelState.IsValid)
            {
                if(NewUser.Password == NewUser.ConfirmPassword)
                {
                    var empDetails = new ALI_LOGINDTLS();
                    empDetails.UserName = NewUser.UserName;
                    empDetails.Password = NewUser.Password;

                    db.ALI_LOGINDTLS.Add(empDetails);
                    db.SaveChanges();
                    //
                }
                else
                {
                    ModelState.AddModelError("", " Password and Confirm Password do not match");
                }
            }
            return View(NewUser);
        }
	}
}