using System;
using System.Collections.Generic;
using System.Linq;
using CQRSCode.CommandHandlers;
using CQRSCode.Commands;
using CQRSCode.Events;
using CQRSlite.Eventing;
using CQRSlite.Extensions.TestHelpers;
using NUnit.Framework;

namespace CQRSTests
{
    //public class WhenFirstItemAdded : Specification<CQRSCode.Domain.ShoppingCart, ShoppingCartCommandHandlers, AddItemToShoppingCart>
    //{
    //    private Guid _guid;
    //    protected override IEnumerable<Event> Given()
    //    {
    //        _guid = Guid.NewGuid();
    //        return new Event[] { new ShoppingCartCreated(_guid) { Version = 1 } };
    //    }

    //    protected override AddItemToShoppingCart When()
    //    {
    //        return new AddItemToShoppingCart(_guid,Guid.NewGuid());
    //    }

    //    protected override ShoppingCartCommandHandlers BuildHandler()
    //    {
    //        return new ShoppingCartCommandHandlers(Repository);
    //    }

    //    [Test]
    //    public void should_create_one_events()
    //    {
    //        Assert.AreEqual(1, PublishedEvents.Count);
    //    }

    //    [Test]
    //    public void should_create_item_added_even()
    //    {
    //        Assert.IsInstanceOf<ItemAddedToShoppingCart>(PublishedEvents.First());
    //    }

    //}
}