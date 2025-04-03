namespace Domain;

//Observer pattern
public interface ISubscriber<in T>
{
    public void Update(T sprint);
}