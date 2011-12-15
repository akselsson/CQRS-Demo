using System;
using CQRSTests;
using CQRSlite.Domain;

namespace CQRSCode.Domain
{
    public class ShoppingCart : AggregateRoot
    {
        public ShoppingCart(Guid aggregateId)
        {
            ApplyChange(new ShoppingCartCreated(aggregateId));
        }

        public ShoppingCart()
        {
        }

        private void Apply(ShoppingCartCreated @event)
        {
            Id = @event.Id;
        }
    }
}