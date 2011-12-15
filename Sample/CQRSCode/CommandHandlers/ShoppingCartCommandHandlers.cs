using CQRSCode.Commands;
using CQRSCode.Domain;
using CQRSTests;
using CQRSlite;
using CQRSlite.Domain;

namespace CQRSCode.CommandHandlers
{
    public class ShoppingCartCommandHandlers : IHandles<CreateShoppingCart>
    {
        private readonly IRepository<ShoppingCart> _repository;

        public ShoppingCartCommandHandlers(IRepository<ShoppingCart> repository)
        {
            _repository = repository;
        }

        public void Handle(CreateShoppingCart message)
        {
            var cart = new ShoppingCart(message.AggregateId);
            _repository.Save(cart,message.ExpectedVersion);
        }
    }
}