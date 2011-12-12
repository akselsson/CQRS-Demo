using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CQRSlite;
using CQRSlite.Commanding;
using CQRSlite.Domain;
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

    public class ShoppingCartCreated : Event
    {

        public ShoppingCartCreated(Guid id)
        {
            Id = id;
        }
    }

    public class FreeShippingApplied : Event
    {
        public FreeShippingApplied(Guid id)
        {
            Id = id;
        }
    }

    public class ItemAddedToShoppingCart : Event
    {
        public ItemAddedToShoppingCart(Guid id, string productId)
        {
            ProductId = productId;
            Id = id;
        }

        public string ProductId { get; set; }
    }

    public class AddItemToShoppingCart : Command
    {
        public AddItemToShoppingCart(Guid id, int exptectedVersion)
        {
            AggregateId = id;
            ExpectedVersion = exptectedVersion;
        }

        public string ProductId { get; set; }
    }

    public class ShoppingCartCommandHandlers : IHandles<AddItemToShoppingCart>
    {
        private readonly IRepository<ShoppingCart> _repository;

        public ShoppingCartCommandHandlers(IRepository<ShoppingCart> repository)
        {
            _repository = repository;
        }

        public void Handle(AddItemToShoppingCart message)
        {
            var cart = _repository.Get(message.AggregateId);
            cart.AddItem(message.ProductId);
            _repository.Save(cart,message.ExpectedVersion);
        }
    }

    public class ShoppingCart : AggregateRoot
    {
        private int _count;

        private void Apply(ShoppingCartCreated @event)
        {
            Id = @event.Id;
        }

        private void Apply(ItemAddedToShoppingCart @event)
        {
            _count++;
            
        }

        public void AddItem(string productId)
        {
            ApplyChange(new ItemAddedToShoppingCart(Id,productId));
            if (_count == 2)
            {
                ApplyChange(new FreeShippingApplied(Id));
            }
        }
    }
}
