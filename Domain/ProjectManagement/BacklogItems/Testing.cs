namespace Domain.ProjectManagement.BacklogItems;

//State pattern
public class Testing : IBacklogItemState
{
    private readonly BacklogItem _backlogItem;
    
    public Testing(BacklogItem backlogItem)
    {
        _backlogItem = backlogItem;
    }
    
    public void ToTodo()
    {
        _backlogItem.SetState(_backlogItem.Todo);
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
        _backlogItem.SetState(_backlogItem.Tested);
    }

    public void ToDone()
    {
        throw new InvalidOperationException();
    }
}