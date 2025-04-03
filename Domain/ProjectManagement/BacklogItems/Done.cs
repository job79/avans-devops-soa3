using Domain.ProjectManagement.BacklogItems;

namespace Domain.ProjectManagement.BacklogItems;

//State pattern
public class Done : IBacklogItemState
{
    public Done(BacklogItem backlogItem)
    {
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