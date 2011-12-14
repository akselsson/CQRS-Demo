using System;
using CQRSlite.Eventing;

namespace CQRSCode.Events
{
    public class ItemAddedToShoppingCart : Event
    {
        public ItemAddedToShoppingCart(Guid id, string productId)
        {
            ProductId = productId;
            Id = id;
        }

        public string ProductId { get; set; }
    }
}