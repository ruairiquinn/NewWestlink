using System.Collections.Generic;
using System.Linq;
using Core.Events;
using Core.Interfaces;
using NewWestlink.Models;
using Raven.Client;
using StructureMap;

namespace NewWestlink.Infrastructure
{
    public class ClientRepository : IClientRepository
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IDocumentStore _documentStore;

        public ClientRepository(IEventPublisher eventPublisher)
        {
            _eventPublisher = eventPublisher;
            _documentStore = ObjectFactory.GetInstance<IDocumentStore>();
        }

        public void Add(IClient client)
        {
            _eventPublisher.PublishEvent(new ClientUpdated { Client = client } );

            using (IDocumentSession session = _documentStore.OpenSession())
            {
                client.Id = "Client/";
                session.Store(client);                
                session.SaveChanges();
            }
        }

        public void Update(IClient client)
        {
            _eventPublisher.PublishEvent(new ClientUpdated { Client = client });

            using (IDocumentSession session = _documentStore.OpenSession())
            {
                session.Store(client);
                session.SaveChanges();
            }
        }

        public IQueryable<IClient> GetAll()
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                return session.Query<Client>();
            }
        }

        public IEnumerable<IClient> All()
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                return session.Query<Client>().AsEnumerable();
            }
        }

        public IClient Find(string id)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                return session.Load<Client>(id);
            }            
        }
        //using (IServiceClient client = new JsonServiceClient(base.JsonSyncReplyBaseUri))
        //    {
        //        var request = new GetCustomers { CustomerIds = new ArrayOfIntId { CustomerId } };
        //        var response = client.Send<GetCustomersResponse>(request);

        //        Assert.AreEqual(1, response.Customers.Count);
        //        Assert.AreEqual(CustomerId, response.Customers[0].Id);
        //    }
    }
}