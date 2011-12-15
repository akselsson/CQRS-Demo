using System;
using System.Collections.Generic;
using CQRSCode.Events;
using CQRSTests;
using CQRSlite.Domain;

namespace CQRSCode.Domain
{
    public class ShoppingCart : AggregateRoot
    {
        readonly List<Guid> _contents = new List<Guid>();

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

        private void Apply(ItemAddedToShoppingCart @event)
        {
           _contents.Add(@event.ProductId);
        }

        public void AddItem(Guid productId)
        {
            ApplyChange(new ItemAddedToShoppingCart(Id,productId));
        }
    }
}