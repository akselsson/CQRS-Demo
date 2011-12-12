using System;
using CQRSlite.Eventing;

namespace CQRSTests
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