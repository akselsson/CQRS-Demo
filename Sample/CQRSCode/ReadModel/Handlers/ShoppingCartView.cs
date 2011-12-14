using CQRSCode.Events;
using CQRSCode.Infrastructure;
using CQRSCode.ReadModel.Dtos;
using CQRSTests;
using CQRSlite;

namespace CQRSCode.ReadModel.Handlers
{
    public class ShoppingCartView : 
        IHandles<ShoppingCartCreated>,
        IHandles<ItemAddedToShoppingCart>,
        IHandles<FreeShipping>
    {
        public void Handle(ShoppingCartCreated message)
        {
            InMemoryDatabase.ShoppingCart[message.Id] = new ShoppingCartDTO();
        }

        public void Handle(ItemAddedToShoppingCart message)
        {
            InMemoryDatabase.ShoppingCart[message.Id].Items++;
        }

        public void Handle(FreeShipping message)
        {

            //InMemoryDatabase.ShoppingCart[message.Id].FreeShipping = true;
        }
    }
}