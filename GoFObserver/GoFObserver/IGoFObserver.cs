namespace GoFObserver
{
    public interface IGoFObserver<in TSubjectType>
    {
        void Update(TSubjectType subject);
    }
}