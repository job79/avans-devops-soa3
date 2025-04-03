using Domain.ProjectManagement.BacklogItems;

namespace Domain.ProjectManagement.BacklogItems;

public class ReadyForTesting : IBacklogItemState
{
    private readonly BacklogItem _backlogItem;
    
    public ReadyForTesting(BacklogItem backlogItem)
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
        _backlogItem.SetState(_backlogItem.Testing);
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