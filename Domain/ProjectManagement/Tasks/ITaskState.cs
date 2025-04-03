namespace Domain.ProjectManagement.Tasks;

//State pattern
public interface ITaskState
{
    public void ToTodo();
    public void ToDoing();
    public void ToDone();
}