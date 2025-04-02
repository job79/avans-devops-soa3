namespace Domain.ProjectManagement.Tasks;

public class Todo : ITaskState
{
    private Task _task;
    
    public Todo(Task task)
    {
        _task = task;
    }
    
    public void ToTodo()
    {
        throw new InvalidOperationException();
    }

    public void ToDoing()
    {
        _task.SetState(_task.Doing);
    }
    
    public void ToDone()
    {
        throw new InvalidOperationException();
    }
}