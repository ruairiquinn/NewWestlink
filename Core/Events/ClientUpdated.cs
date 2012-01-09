using Core.Interfaces;

namespace Core.Events
{
    public class ClientUpdated
    {
        public IClient Client { get; set; }
    }
}