using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client;
using Raven.Client.Document;
using StructureMap;
using NewWestlink.Controllers;

namespace NewWestlink.Infrastructure
{
    public class Bootstrapper
    {
        public static void ConfigureDependencies()
        {
            var documentStore = new DocumentStore
            {
                ConnectionStringName = "RavenDB"
            }.Initialize();

            documentStore.Conventions.IdentityPartsSeparator = "-";

            ////var documentStore = new EmbeddableDocumentStore
            ////{
            ////    DataDirectory = "Data",
            ////    UseEmbeddedHttpServer = true
            ////};
            ////documentStore.Initialize();

            ObjectFactory.Initialize(x =>
            {
                x.For<IDocumentStore>().Add(documentStore);
                x.AddRegistry<RepositoryRegistry>();
            });

            ////return new Container(x =>
            ////{
            ////    x.For<IDocumentStore>().Add(documentStore);
            ////    x.For<IClientRepository>().Use<ClientRepository>();
            ////});
        }
    }
}