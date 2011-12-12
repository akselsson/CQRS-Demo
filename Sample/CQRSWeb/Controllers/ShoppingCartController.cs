using System;
using System.Web.Mvc;
using CQRSCode.Commands;
using CQRSCode.ReadModel;
using CQRSTests;
using CQRSlite.Commanding;

namespace CQRSWeb.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ICommandSender _commandSender;
        private readonly IReadModelFacade _readModel;

        public ShoppingCartController(ICommandSender commandSender,IReadModelFacade readModel)
        {
            _commandSender = commandSender;
            _readModel = readModel;
        }

        public ActionResult Index()
        {
            Guid? cartId = (Guid?)Session["CartId"];
            if (cartId == null)
            {
                return PartialView("Empty");
            }
            ViewData.Model = _readModel.GetShoppingCart(cartId.Value);
            return PartialView();
        }

        [HttpPost]
        public ActionResult Add(Guid productId)
        {
            Guid? cartId = (Guid?)Session["CartId"];
            if(cartId == null)
            {
                cartId = Guid.NewGuid();
                _commandSender.Send(new CreateShoppingCart(cartId.Value,-1));
                Session["CartId"] = cartId;
            }
            _commandSender.Send(new AddItemToShoppingCart(cartId.Value,-1));
            return RedirectToAction("Index", "Home");
        }
    }
}