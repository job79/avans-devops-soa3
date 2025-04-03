using Domain.ProjectManagement.BacklogItems;
using Domain.ProjectManagement.Sprints;
using Task = Domain.ProjectManagement.Tasks.Task;

namespace Domain.ProjectManagement;

// Visitor pattern
public abstract class Visitor
{
    public virtual void VisitProject(Project project)
    {
        Console.WriteLine("[Visitor] visiting project");
    }

    public virtual void VisitSprint(Sprint sprint)
    {
        Console.WriteLine("[Visitor] visiting sprint");
    }

    public virtual void VisitBacklogItem(BacklogItem backlogItem)
    {
        Console.WriteLine("[Visitor] visiting backlog item");
    }

    public virtual void VisitTask(Task task)
    {
        Console.WriteLine("[Visitor] visiting task");
    }
}