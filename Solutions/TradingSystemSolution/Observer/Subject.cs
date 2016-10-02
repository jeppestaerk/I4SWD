using System.Collections.Generic;

namespace Observer
{
    public class Subject<T> where T : class
    {
        private readonly List<Observer<T>> _observers;

        public Subject() { _observers = new List<Observer<T>>(); }
        public void Attach(Observer<T> observer) { _observers.Add(observer); }
        public void Detach(Observer<T> observer) { _observers.Remove(observer); }
        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this as T);
            }
        }
    }
}
