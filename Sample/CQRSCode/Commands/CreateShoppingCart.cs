using System;
using CQRSlite.Commanding;

namespace CQRSCode.Commands
{
    public class CreateShoppingCart : Command
    {
        public CreateShoppingCart(Guid id, int expectedVersion)
        {
            AggregateId = id;
            ExpectedVersion = expectedVersion;
        }
    }
}