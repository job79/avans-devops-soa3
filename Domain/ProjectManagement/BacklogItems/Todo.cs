using Domain.ProjectManagement.BacklogItems;

namespace Domain.ProjectManagement.BacklogItems;

//State pattern
public class Todo : IBacklogItemState
{
    private readonly BacklogItem _backlogItem;
    
    public Todo(BacklogItem backlogItem)
    {
        _backlogItem = backlogItem;
    }
    
    public void ToTodo()
    {
        throw new InvalidOperationException();
    }

    public void ToDoing()
    {
        _backlogItem.SetState(_backlogItem.Doing);
    }

    public void ToReadyForTesting()
    {
        throw new InvalidOperationException();
    }

    public void ToTesting()
    {
        throw new InvalidOperationException();
    }

    public void ToTested()
    {
        throw new InvalidOperationException();
    }

    public void ToDone()
    {
        throw new InvalidOperationException();
    }
}