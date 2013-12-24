using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyBirthdayMyFriend.Web.Mvc.Controllers
{
    public class BaseController : Controller
    {
        public int GetSecondsRemain()
        {
            var bd = new DateTime(2013, 12, 31);
            var now = DateTime.Now;
            return (int)(bd - now).TotalSeconds;
        }
	}
}