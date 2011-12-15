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

        public ShoppingCartController(ICommandSender commandSender, IReadModelFacade readModel)
        {
            _commandSender = commandSender;
            _readModel = readModel;
        }

        public ActionResult Index()
        {
            CreateCart();
            ViewData.Model = _readModel.GetShoppingCart(CurrentCart.Value);
            return PartialView();
        }

        [HttpPost]
        public ActionResult Add(Guid productId)
        {
            

            return RedirectToAction("Index", "Home");
        }

        private void CreateCart()
        {
            Guid? cartId = CurrentCart;
            if (cartId == null)
            {
                cartId = Guid.NewGuid();
                _commandSender.Send(new CreateShoppingCart(cartId.Value));
                CurrentCart = cartId;
            }
        }

        private Guid? CurrentCart
        {
            get
            {
                return (Guid?)Session["CartId"];
            }
            set
            {
                Session["CartId"] = value;
            }
        }
    }
}