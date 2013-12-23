using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyBirthdayMyFriend.Web.Mvc.Controllers
{
    public class GreetingsController : Controller
    {
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Show()
        {
            return View();
        }
	}
}