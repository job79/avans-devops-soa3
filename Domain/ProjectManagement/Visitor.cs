using Domain.ProjectManagement.BacklogItems;
using Domain.ProjectManagement.Sprints;
using Task = Domain.ProjectManagement.Tasks.Task;

namespace Domain.ProjectManagement;

public abstract class Visitor
{
    public void VisitProject(Project project)
    {
        Console.WriteLine("[Visitor] visiting project");
    }

    public void VisitSprint(Sprint sprint)
    {
        Console.WriteLine("[Visitor] visiting sprint");
    }

    public void VisitBacklogItem(BacklogItem backlogItem)
    {
        Console.WriteLine("[Visitor] visiting backlog item");
    }

    public void VisitTask(Task task)
    {
        Console.WriteLine("[Visitor] visiting task");
    }
}