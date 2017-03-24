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
        private Goodna_TempleEntities db = new Goodna_TempleEntities();
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
                    var details = db.M2000_WP_GOODNA_USER_ACCOUNTS.Single(A => A.USR_NAME == User.UserName && A.PSSWORD == User.Password);
                    if (details.USR_NAME != null)
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
                    var empDetails = new M2000_WP_GOODNA_USER_ACCOUNTS();
                    empDetails.USR_NAME = NewUser.UserName;
                    empDetails.PSSWORD = NewUser.Password;

                    db.M2000_WP_GOODNA_USER_ACCOUNTS.Add(empDetails);
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