using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CQRSCode.CommandHandlers;
using CQRSCode.Commands;
using CQRSCode.Domain;
using CQRSCode.Events;
using CQRSlite.Eventing;
using CQRSlite.Extensions.TestHelpers;
using NUnit.Framework;

namespace CQRSTests
{
    //public class WhenSecondItemAdded : Specification<ShoppingCart, ShoppingCartCommandHandlers, AddItemToShoppingCart>
    //{
    //    private Guid _guid;
    //    protected override IEnumerable<Event> Given()
    //    {
    //        _guid = Guid.NewGuid();
    //        return new Event[] { new ShoppingCartCreated(_guid) { Version = 1 }, new ItemAddedToShoppingCart(_guid, Guid.NewGuid()) { Version = 2 } };
    //    }

    //    protected override AddItemToShoppingCart When()
    //    {
    //        return new AddItemToShoppingCart(_guid,Guid.NewGuid());
    //    }

    //    protected override ShoppingCartCommandHandlers BuildHandler()
    //    {
    //        return new ShoppingCartCommandHandlers(Repository);
    //    }

      

    //}

}
