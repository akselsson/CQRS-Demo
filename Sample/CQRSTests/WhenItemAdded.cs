using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CQRSCode.CommandHandlers;
using CQRSCode.Commands;
using CQRSlite.Eventing;
using CQRSlite.Extensions.TestHelpers;
using NUnit.Framework;

namespace CQRSTests
{
    public class WhenFirstItemAdded : Specification<ShoppingCart, ShoppingCartCommandHandlers, AddItemToShoppingCart>
    {
        private Guid _guid;
        protected override IEnumerable<Event> Given()
        {
            _guid = Guid.NewGuid();
            return new Event[] { new ShoppingCartCreated(_guid) { Version = 1 } };
        }

        protected override AddItemToShoppingCart When()
        {
            return new AddItemToShoppingCart(_guid, 1);
        }

        protected override ShoppingCartCommandHandlers BuildHandler()
        {
            return new ShoppingCartCommandHandlers(Repository);
        }

        [Test]
        public void should_create_one_events()
        {
            Assert.AreEqual(1, PublishedEvents.Count);
        }

        [Test]
        public void should_create_item_added_even()
        {
            Assert.IsInstanceOf<ItemAddedToShoppingCart>(PublishedEvents.First());
        }

    }

    public class WhenSecondItemAdded : Specification<ShoppingCart, ShoppingCartCommandHandlers, AddItemToShoppingCart>
    {
        private Guid _guid;
        protected override IEnumerable<Event> Given()
        {
            _guid = Guid.NewGuid();
            return new Event[] { new ShoppingCartCreated(_guid) { Version = 1 }, new ItemAddedToShoppingCart(_guid, "product 1") { Version = 2 } };
        }

        protected override AddItemToShoppingCart When()
        {
            return new AddItemToShoppingCart(_guid, 2);
        }

        protected override ShoppingCartCommandHandlers BuildHandler()
        {
            return new ShoppingCartCommandHandlers(Repository);
        }

        [Test]
        public void should_create_two_events()
        {
            Assert.AreEqual(2,PublishedEvents.Count);
        }

        [Test]
        public void should_create_item_added_even()
        {
            Assert.IsInstanceOf<ItemAddedToShoppingCart>(PublishedEvents.First());
        }

        [Test]
        public void should_apply_free_shipping()
        {
            Assert.IsInstanceOf<FreeShippingApplied>(PublishedEvents.ElementAt(1));
        }
    }
}
