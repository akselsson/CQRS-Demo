using System;
using CQRSlite.Domain;

namespace CQRSTests
{
    public class ShoppingCart : AggregateRoot
    {
        private int _count;

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
            _count++;
            
        }

        public void AddItem(string productId)
        {
            ApplyChange(new ItemAddedToShoppingCart(Id,productId));
            if (_count == 2)
            {
                ApplyChange(new FreeShippingApplied(Id));
            }
        }
    }
}