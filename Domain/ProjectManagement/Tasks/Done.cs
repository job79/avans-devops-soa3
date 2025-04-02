namespace Domain.ProjectManagement.Tasks;

public class Done : ITaskState
{
    private Task _task;
    
    public Done(Task task)
    {
        _task = task;
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