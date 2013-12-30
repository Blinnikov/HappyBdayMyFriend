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
            var bd = new DateTime(2013, 12, 31, 6, 35, 0, DateTimeKind.Utc);
            var now = DateTime.UtcNow;
            return (int)(bd - now).TotalSeconds;
        }
	}
}