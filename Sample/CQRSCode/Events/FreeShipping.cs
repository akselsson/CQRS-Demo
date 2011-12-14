using System;
using CQRSlite.Eventing;

namespace CQRSCode.Events
{
    public class FreeShipping : Event
    {
        public FreeShipping(Guid id)
        {
            Id = id;
        }
    }
}