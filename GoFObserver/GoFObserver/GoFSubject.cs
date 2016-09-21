using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace GoFObserver
{
    public abstract class GoFSubject<TSubjectType> where TSubjectType : class
    {
        private readonly List<IGoFObserver<TSubjectType>> _observers = new List<IGoFObserver<TSubjectType>>();

        public void Attach(IGoFObserver<TSubjectType> observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IGoFObserver<TSubjectType> observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this as TSubjectType);
            }
        }
    }
}
