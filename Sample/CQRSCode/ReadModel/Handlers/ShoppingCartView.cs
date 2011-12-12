using CQRSCode.Infrastructure;
using CQRSTests;
using CQRSlite;

namespace CQRSCode.ReadModel.Handlers
{
    public class ShoppingCartView : 
        IHandles<ShoppingCartCreated>,
        IHandles<ItemAddedToShoppingCart>,
        IHandles<FreeShippingApplied>
    {
        public void Handle(ShoppingCartCreated message)
        {
            InMemoryDatabase.ShoppingCart[message.Id] = new ShoppingCartDTO();
        }

        public void Handle(ItemAddedToShoppingCart message)
        {
            InMemoryDatabase.ShoppingCart[message.Id].Items++;
        }

        public void Handle(FreeShippingApplied message)
        {

            InMemoryDatabase.ShoppingCart[message.Id].FreeShipping = true;
        }
    }
}