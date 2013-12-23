using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyBirthdayMyFriend.Web.Mvc.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var seconds = GetSecondsRemain();
            var model = seconds > 0 ? seconds : 3;
            return View(model);
        }
    }
}