using System;
using CQRSlite.Eventing;

namespace CQRSTests
{
    public class ShoppingCartCreated : Event
    {

        public ShoppingCartCreated(Guid id)
        {
            Id = id;
        }
    }
}