using System;
using CQRSlite.Eventing;

namespace CQRSCode.Events
{
    public class ItemAddedToShoppingCart : Event
    {
        public ItemAddedToShoppingCart(Guid id, Guid productId)
        {
            ProductId = productId;
            Id = id;
        }

        public Guid ProductId { get; set; }
    }
}