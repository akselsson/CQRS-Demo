using System;
using CQRSlite.Commanding;

namespace CQRSCode.Commands
{
    public class AddItemToShoppingCart : Command
    {
        public AddItemToShoppingCart(Guid id)
        {
            AggregateId = id;
            ExpectedVersion = -1;
        }

        public string ProductId { get; set; }
    }
}