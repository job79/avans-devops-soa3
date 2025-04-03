namespace Domain.ProjectManagement.BacklogItems;

//State pattern

public interface IBacklogItemState
{
    public void ToTodo();
    public void ToDoing();
    public void ToReadyForTesting();
    public void ToTesting();
    public void ToTested();
    public void ToDone();
}