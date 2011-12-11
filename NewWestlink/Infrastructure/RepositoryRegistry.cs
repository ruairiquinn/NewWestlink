using StructureMap.Configuration.DSL;

namespace NewWestlink.Infrastructure
{
    public class RepositoryRegistry : Registry
    {
        public RepositoryRegistry()
        {
            For<IClientRepository>().Use<ClientRepository>();            
        }
    }

}