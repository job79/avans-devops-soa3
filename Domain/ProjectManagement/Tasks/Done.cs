namespace Domain.ProjectManagement.Tasks;

//State pattern
public class Done : ITaskState
{
    public Done(Task task)
    {
    }
    
    public void ToTodo()
    {
        throw new InvalidOperationException();
    }

    public void ToDoing()
    {
        throw new InvalidOperationException();
    }
    
    public void ToDone()
    {
        throw new InvalidOperationException();
    }
}