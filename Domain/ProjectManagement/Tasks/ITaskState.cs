namespace Domain.ProjectManagement.Tasks;

public interface ITaskState
{
    public void ToTodo();
    public void ToDoing();
    public void ToDone();
}