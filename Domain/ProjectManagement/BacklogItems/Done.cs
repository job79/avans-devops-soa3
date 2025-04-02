using Domain.ProjectManagement.BacklogItems;

namespace Domain.ProjectManagement.BacklogItems;

public class Done : IBacklogItemState
{
    private BacklogItem _backlogItem;
    
    public Done(BacklogItem backlogItem)
    {
        _backlogItem = backlogItem;
    }
    
    public void ToTodo()
    {
        throw new InvalidOperationException();
    }

    public void ToDoing()
    {
        throw new InvalidOperationException();
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