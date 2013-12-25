using System.Linq;
using System.Web.Mvc;
using HappyBdayMyFriend.DataAccess.Contracts;
using HappyBdayMyFriend.Model;
using PagedList;

namespace HappyBirthdayMyFriend.Web.Mvc.Controllers
{
    public class GreetingsController : BaseController
    {
        private const int PageSize = 9;
        public GreetingsController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public ActionResult Show(int? page)
        {
            var seconds = GetSecondsRemain();
            if (seconds > 0)
            {
                return this.RedirectToAction("Index", "Home");
            }

            return ShowCards(page);
        }

        public ActionResult MyDearLordPleaseShowMeTheCards(int? page)
        {
            return ShowCards(page);
        }

        [NonAction]
        private ActionResult ShowCards(int? page)
        {
            int pageNumber = (page ?? 1);
            return View("Show", UnitOfWork.Cards.GetAll().OrderBy(c => c.Cover).ToPagedList(pageNumber, PageSize));
        }

        public ActionResult AddPlease()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult AddPlease(Card card)
        {
            var nextCover = UnitOfWork.Cards.GetAll().Any() ? UnitOfWork.Cards.GetAll().Max(c => c.Cover) + 1 : 1;
            card.Cover = nextCover;
            UnitOfWork.Cards.Add(card);
            UnitOfWork.Commit();
            return View();
        }

        public ActionResult EditMeCarefully(int id)
        {
            var card = UnitOfWork.Cards.GetAll().FirstOrDefault(c => c.Cover == id);
            return View("AddPlease", card);
        }

        [HttpPost]
        public ActionResult EditMeCarefully(Card card)
        {
            var existingCard = UnitOfWork.Cards.GetById(card.Id);
            existingCard.Message = card.Message;
            existingCard.Signature = card.Signature;
            UnitOfWork.Cards.Update(existingCard);
            UnitOfWork.Commit();
            return RedirectToAction("Show");
        }

        public void ClearAll()
        {
            var cards = UnitOfWork.Cards.GetAll().ToArray();
            foreach (var c in cards)
            {
                UnitOfWork.Cards.Delete(c);
            }
            UnitOfWork.Commit();
        }
	}
}