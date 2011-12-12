using System;
using CQRSlite.Eventing;

namespace CQRSTests
{
    public class FreeShippingApplied : Event
    {
        public FreeShippingApplied(Guid id)
        {
            Id = id;
        }
    }
}