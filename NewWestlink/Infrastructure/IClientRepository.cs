using System.Linq;
using NewWestlink.Models;

namespace NewWestlink.Infrastructure
{
    public interface IClientRepository
    {
        void Add(Client client);
        void Update(Client client);
        IQueryable<Client> GetAll();
        Client Find(string id);
    }
}