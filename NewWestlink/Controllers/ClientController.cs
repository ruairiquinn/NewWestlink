﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Core.Enumerations;
using Core.Interfaces;
using NewWestlink.Infrastructure;
using NewWestlink.Models;
using Telerik.Web.Mvc;

namespace NewWestlink.Controllers
{
    public class ClientController : Controller
    {
        #region Fields
        private const string EditActionName = "Edit";
        private const string ListActionName = "ListTelerik";
        private readonly BaseRavenRepository<Client> _clientRepository; 
        #endregion

        #region Constructor
        public ClientController(BaseRavenRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        } 
        #endregion

        #region Edit
        // GET: /Client/New
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return View();
            }

            var client = _clientRepository.GetByKey(id);

            return View(EditActionName, client);
        }

        [HttpPost]
        public ActionResult Edit(Client client)
        {
            if (client.Id == null)
            {
                _clientRepository.Add(client);
            }
            else
            {
                _clientRepository.Update(client);
            }

            return RedirectToAction(ListActionName);
        } 
        #endregion

        #region Lists
        // GET: /Client/List
        public ActionResult List()
        {
            return View(_clientRepository.All());
        }

        // GET: /Client/TelerikList
        public ActionResult ListTelerik()
        {
            return View(_clientRepository.All());
        }

        [GridAction]
        public ActionResult ListAsync()
        {
            var clients = _clientRepository.All();

            var clientModel = new GridModel(clients);
            return View(clientModel);
        } 
        #endregion


    }
}