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

namespace MVC_Lab.Controllers
{
    public class HomeController : Controller
    {
        #region GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        #endregion

        #region GET: /Home/About

        public ActionResult About()
        {
            return View();
        }

        #endregion

        #region GET: /Home/Unauthorized

        public ActionResult Unauthorized()
        {
            return View();
        }

        #endregion

    }
}
