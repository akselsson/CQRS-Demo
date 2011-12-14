using System;
using CQRSlite.Commanding;

namespace CQRSCode.Commands
{
    public class CreateShoppingCart : Command
    {
        public CreateShoppingCart(Guid id)
        {
            AggregateId = id;
            ExpectedVersion = -1;
        }
    }
}