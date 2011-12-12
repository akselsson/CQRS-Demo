using System;
using CQRSlite.Commanding;

namespace CQRSCode.Commands
{
    public class AddItemToShoppingCart : Command
    {
        public AddItemToShoppingCart(Guid id, int exptectedVersion)
        {
            AggregateId = id;
            ExpectedVersion = exptectedVersion;
        }

        public string ProductId { get; set; }
    }
}