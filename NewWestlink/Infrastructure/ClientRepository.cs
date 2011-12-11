using System;
using System.Linq;
using NewWestlink.Models;
using Raven.Client;
using StructureMap;

namespace NewWestlink.Infrastructure
{
    class ClientRepository : IClientRepository
    {
        private readonly IDocumentStore _documentStore;

        public ClientRepository()
        {
            _documentStore = ObjectFactory.GetInstance<IDocumentStore>();
        }

        public void Add(Client client)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                client.Id = "Client/";
                session.Store(client);                
                session.SaveChanges();
            }
        }

        public void Update(Client client)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                session.Store(client);
                session.SaveChanges();
            }
        }

        public IQueryable<Client> GetAll()
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                return session.Query<Client>();
            }
        }

        public Client Find(string id)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                return session.Load<Client>(id);
            }            
        }
    }
}