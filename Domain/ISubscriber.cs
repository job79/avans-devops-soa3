namespace Domain;

public interface ISubscriber<T>
{
    public void Update(T sprint);
}