using Domain.Account;

namespace Domain.ProjectManagement.Tasks;

public class Task : Component
{
    public string Title { get; }
    public string Description { get; }
    
    ITaskState CurrentState { get; set; }
    public Todo Todo { get; }
    public Doing Doing { get; }
    public Done Done { get; }

    private User Assignee { get; }
    
    
    public Task(string title, string description)
    {
        this.Title = title;
        this.Description = description;
        
        Todo = new Todo(this);
        Doing = new Doing(this);
        Done = new Done(this);
        
        CurrentState = Todo;
    }
    
    public void ToDo()
    {
        CurrentState.ToTodo();
    }
    
    public void ToDoing()
    {
        CurrentState.ToDoing();
    }
    
    public void ToDone()
    {
        CurrentState.ToDone();
    }

    public void SetState(ITaskState taskState)
    {
        CurrentState = taskState;
    }

    public override void AcceptVisitor(Visitor visitor)
    {
        visitor.VisitTask(this);
    }
}