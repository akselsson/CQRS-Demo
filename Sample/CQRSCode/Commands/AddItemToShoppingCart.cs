using System;
using CQRSlite.Commanding;

namespace CQRSCode.Commands
{
    public class AddItemToShoppingCart : Command
    {
        public AddItemToShoppingCart(Guid cartId, Guid productId)
        {
            AggregateId = cartId;
            ProductId = productId;
            ExpectedVersion = -1;
        }

        public Guid ProductId { get; set; }
    }
}