using System;
using System.Web.Mvc;
using HappyBdayMyFriend.DataAccess.Contracts;

namespace HappyBirthdayMyFriend.Web.Mvc.Controllers
{
    public class BaseController : Controller
    {
        protected IUnitOfWork UnitOfWork { get; set; }
        public int GetSecondsRemain()
        {
            var bd = new DateTime(2013, 12, 31);
            var now = DateTime.Now;
            return (int)(bd - now).TotalSeconds;
        }
	}
}