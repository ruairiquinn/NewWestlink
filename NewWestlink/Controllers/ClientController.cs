using System.Web.Mvc;
using NewWestlink.Infrastructure;
using NewWestlink.Models;
using StructureMap;

namespace NewWestlink.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        // GET: /Client/New
        public ActionResult Edit(string id)
        {
            if(id == null)
            {
                return View();
            }

            var client = _clientRepository.Find(id);

            return View("Edit", client);
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

            return RedirectToAction("List");
        }

        // GET: /Client/List
        public ActionResult List()
        {
            var clients = _clientRepository.GetAll();
            return View(clients);
        }
    }
}