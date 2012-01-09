using Core.Interfaces;
using NewWestlink.Models;
using StructureMap.Configuration.DSL;

namespace NewWestlink.Infrastructure.StructureMapArtifacts
{
    public class RepositoryRegistry : Registry
    {
        public RepositoryRegistry()
        {
            For<IClient>().Use<Client>();   //.InterceptWith(new CustomInterceptor());
            For<IClientRepository>().Use<ClientRepository>();   //.InterceptWith(new CustomInterceptor());

            For<IReferenceDataRepository>().Use<ReferenceDataRepository>();   //.InterceptWith(new CustomInterceptor());

            For<IPreSaveExtensionPoint>()
             .Use<ClientExtension>()
             .Named("ClientExtension");

            For<IEventPublisher>()
                .TheDefaultIsConcreteType<EventPublisher>().Singleton();

            Scan(x =>
                     {
                         x.TheCallingAssembly();
                         x.AddAllTypesOf<IListener>();
                         x.WithDefaultConventions();
                     }
                );
        }
    }
}