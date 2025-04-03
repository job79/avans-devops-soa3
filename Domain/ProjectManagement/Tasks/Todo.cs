namespace Domain.ProjectManagement.Tasks;

//State pattern
public class Todo : ITaskState
{
    private readonly Task _task;
    
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