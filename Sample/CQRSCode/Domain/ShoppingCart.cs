using System;
using System.Collections.Generic;
using CQRSCode.Events;
using CQRSTests;
using CQRSlite.Domain;

namespace CQRSCode.Domain
{
    public class ShoppingCart : AggregateRoot
    {
        readonly List<string> _contents = new List<string>();

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

        public void AddItem(string productId)
        {
            ApplyChange(new ItemAddedToShoppingCart(Id,productId));
        }
    }
}