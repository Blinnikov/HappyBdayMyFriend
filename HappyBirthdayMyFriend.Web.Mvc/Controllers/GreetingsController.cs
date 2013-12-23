using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyBirthdayMyFriend.Web.Mvc.Controllers
{
    public class GreetingsController : BaseController
    {
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Show()
        {
            var seconds = GetSecondsRemain();
            if (seconds > 0)
            {
                return this.RedirectToAction("Index", "Home");
            }
            return View();
        }
	}
}