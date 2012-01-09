namespace Core.Interfaces
{
    public interface IListener<in T> : IListener
    {
        void Handle(T subject);        
    }

    public interface IListener
    {        
    }
}
