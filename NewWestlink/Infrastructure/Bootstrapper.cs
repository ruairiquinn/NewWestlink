using System.Diagnostics;
using Core.Interfaces;
using NewWestlink.Infrastructure.StructureMapArtifacts;
using Raven.Client;
using Raven.Client.Document;
using StructureMap;

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

            RegisterListeners();

            ////return new Container(x =>
            ////{
            ////    x.For<IDocumentStore>().Add(documentStore);
            ////    x.For<IClientRepository>().Use<ClientRepository>();
            ////});
        }

        private static void RegisterListeners()
        {            
            var eventPublisher = ObjectFactory.GetInstance<IEventPublisher>();

            Debug.Print(ObjectFactory.WhatDoIHave());

            var listeners = ObjectFactory.GetAllInstances(typeof(IListener));

            foreach (var listener in listeners)
            {
                eventPublisher.AddListener(listener);
            }
        }
    }
}