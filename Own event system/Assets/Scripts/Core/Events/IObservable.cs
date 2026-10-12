namespace MyGame.Core.Events
{
    public interface IObservable<T>
    {
        void RegisterObserver(IGameEventListener<T> observer);
        void RemoveObserver(IGameEventListener<T> observer);
        void Notify(T payload);
    }
}