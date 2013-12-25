using HappyBdayMyFriend.DataAccess.Contracts;
using System.Linq;
using System.Web.Mvc;

namespace HappyBirthdayMyFriend.Web.Mvc.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var seconds = GetSecondsRemain();
            var model = seconds > 0 ? seconds : 3;
            return View(model);
        }
    }
}