namespace Domain.ProjectManagement.Tasks;

public class Doing : ITaskState
{
    private Task _task;
    
    public Doing(Task task)
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
        _task.SetState(_task.Doing);
    }
}