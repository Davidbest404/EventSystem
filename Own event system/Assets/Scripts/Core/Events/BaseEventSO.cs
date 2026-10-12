using System.Collections.Generic;
using UnityEngine;

namespace MyGame.Core.Events
{
    public abstract class BaseEventSO<T> : ScriptableObject, IObservable<T>
    {
        readonly List<IGameEventListener<T>> _observers = new List<IGameEventListener<T>>();

        public void RegisterObserver(IGameEventListener<T> observer)
        {
            if (!_observers.Contains(observer)) _observers.Add(observer);
        }

        public void RemoveObserver(IGameEventListener<T> observer)
        {
            if (_observers.Contains(observer)) _observers.Remove(observer);
        }

        public void Notify(T payload)
        {
            for (int i = _observers.Count - 1; i >= 0; i--) _observers[i].OnEventRaised(payload);
        }
    }
}
