﻿using System;
using System.Web.Mvc;
using CQRSCode.Commands;
using CQRSCode.ReadModel;
using CQRSlite.Commanding;

namespace CQRSWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICommandSender _commandSender;
        private readonly IReadModelFacade _readmodel;

        public HomeController(ICommandSender commandSender, IReadModelFacade readmodel)
        {
            _readmodel = readmodel;
            _commandSender = commandSender;
        }

        public ActionResult Index()
        {
            ViewData.Model = _readmodel.GetInventoryItems();

            return View();
        }

        public ActionResult Details(Guid id)
        {
            ViewData.Model = _readmodel.GetInventoryItemDetails(id);
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string name)
        {
            _commandSender.Send(new CreateInventoryItem(Guid.NewGuid(), name));

            return RedirectToAction("Index");
        }

        public ActionResult ChangeName(Guid id)
        {
            ViewData.Model = _readmodel.GetInventoryItemDetails(id);
            return View();
        }

        [HttpPost]
        public ActionResult ChangeName(Guid id, string name, int version)
        {
            var command = new RenameInventoryItem(id, name, version);
            _commandSender.Send(command);

            return RedirectToAction("Index");
        }

        public ActionResult Deactivate(Guid id, int version)
        {
            _commandSender.Send(new DeactivateInventoryItem(id, version));
            return RedirectToAction("Index");
        }

        public ActionResult CheckIn(Guid id)
        {
            ViewData.Model = _readmodel.GetInventoryItemDetails(id);
            return View();
        }

        [HttpPost]
        public ActionResult CheckIn(Guid id, int number, int version)
        {
            _commandSender.Send(new CheckInItemsToInventory(id, number, version));
            return RedirectToAction("Index");
        }

        public ActionResult Remove(Guid id)
        {
            ViewData.Model = _readmodel.GetInventoryItemDetails(id);
            return View();
        }

        [HttpPost]
        public ActionResult Remove(Guid id, int number, int version)
        {
            _commandSender.Send(new RemoveItemsFromInventory(id, number, version));
            return RedirectToAction("Index");
        }

        public ActionResult Testdata()
        {
            _commandSender.Send(new CreateInventoryItem(Guid.NewGuid(), "Kindle")); 
            _commandSender.Send(new CreateInventoryItem(Guid.NewGuid(), "Kindle Fire")); 
            _commandSender.Send(new CreateInventoryItem(Guid.NewGuid(), "Kindle Touch")); 
            _commandSender.Send(new CreateInventoryItem(Guid.NewGuid(), "Kindle 4")); 
            _commandSender.Send(new CreateInventoryItem(Guid.NewGuid(), "Nook")); 
            _commandSender.Send(new CreateInventoryItem(Guid.NewGuid(), "Nook Color"));
            return RedirectToAction("Index");

        }
    }
}
