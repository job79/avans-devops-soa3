namespace Domain.ProjectManagement.Tasks;

//State pattern
public class Doing : ITaskState
{
    private readonly Task _task;
    
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
        _task.SetState(_task.Done);
    }
}