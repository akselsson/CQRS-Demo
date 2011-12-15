using CQRSCode.Events;
using CQRSCode.Infrastructure;
using CQRSCode.ReadModel.Dtos;
using CQRSTests;
using CQRSlite;

namespace CQRSCode.ReadModel.Handlers
{
    public class ShoppingCartView : 
        IHandles<ShoppingCartCreated>
    {
        public void Handle(ShoppingCartCreated message)
        {
            InMemoryDatabase.ShoppingCart[message.Id] = new ShoppingCartDTO();
        }
    }
}