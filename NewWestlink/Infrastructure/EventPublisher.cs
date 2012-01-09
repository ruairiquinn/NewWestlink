using System.Collections.Generic;
using Core.Interfaces;

namespace NewWestlink.Infrastructure
{
    public class EventPublisher : IEventPublisher
    {
        private readonly IList<object> _listeners;       

        public EventPublisher(IList<object> listeners)
        {
            _listeners = listeners;
        }

        public void PublishEvent<T>(T subject)
        {
            foreach (object listener in _listeners)
            {         
                var receiver = listener as IListener<T>;
                if (receiver != null)
                {
                    receiver.Handle(subject);
                }
            }
        }

        public void AddListener(object listener)
        {
            _listeners.Add(listener);
        }

        public void RemoveListener(object listener)
        {
            _listeners.Add(listener);
        }
    }
}