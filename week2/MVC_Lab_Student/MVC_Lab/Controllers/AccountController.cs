/*
 * @author Infusion bootcamp instructors
 * @author Clinton Freeman <clintonfreeman@infusion.com>
 * @date 2014-06-10
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC_Lab.DAL;
using MVC_Lab.Models;

namespace MVC_Lab.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private InfusionRelayChatContext db = new InfusionRelayChatContext();

        #region GET: /Account/Register

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        #endregion

        #region POST: /Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User newUser, string returnUrl)
        {
            newUser.UserId = db.Users.Count();
            db.Users.Add(newUser);
            db.SaveChanges();
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        #endregion

        #region GET: /Account/Login

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        #endregion

        #region POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (isValidLogin(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View(model);
        }

        #endregion

        #region GET: /Account/LogOff

        [HttpGet]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                // Changed to About page since Home page is Lab 1 page without MVC navigation
                return RedirectToAction("About", "Home");
            }
        }

        /// <summary>
        /// Checks if user with given password exists in the database
        /// </summary>
        /// <param name="_username">User name</param>
        /// <param name="_password">User password</param>
        /// <returns>True if user exist and password is correct</returns>
        public bool isValidLogin(string _username, string _password)
        {
            // Mock implementation for lab
            return
                db.Users.Any(
                    u =>
                    u.UserName.Equals(_username, StringComparison.InvariantCultureIgnoreCase) &&
                    u.Password.Equals(_password));
        }
        #endregion

    }
}
