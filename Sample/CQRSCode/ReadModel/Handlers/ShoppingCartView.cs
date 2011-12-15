using CQRSCode.Events;
using CQRSCode.Infrastructure;
using CQRSCode.ReadModel.Dtos;
using CQRSTests;
using CQRSlite;

namespace CQRSCode.ReadModel.Handlers
{
    public class ShoppingCartView : 
        IHandles<ShoppingCartCreated>,
        IHandles<ItemAddedToShoppingCart>
    {
        public void Handle(ShoppingCartCreated message)
        {
            InMemoryDatabase.ShoppingCart[message.Id] = new ShoppingCartDTO();
        }

        public void Handle(ItemAddedToShoppingCart message)
        {
            InMemoryDatabase.ShoppingCart[message.Id].Items++;
        }
    }
}