using System;
using Core.Events;
using Core.Interfaces;

namespace NewWestlink.Infrastructure
{
    public class ClientExtension : IPreSaveExtensionPoint,  IListener<ClientUpdated>, IListener
    {
        public void Handle(ClientUpdated subject)
        {
            subject.Client.LastUpdated = DateTime.Now;
        }
    }
}