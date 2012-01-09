namespace Core.Interfaces
{
    public interface IEventPublisher
    {
        void PublishEvent<T>(T subject);
        void AddListener(object listener);
        void RemoveListener(object listener);
    }
}