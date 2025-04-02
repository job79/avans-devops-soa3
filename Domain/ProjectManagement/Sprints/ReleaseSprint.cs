using Domain.Account;

namespace Domain.ProjectManagement.Sprints;

public class ReleaseSprint : Sprint
{
    public ReleaseSprint(string name, DateTime startDate, DateTime endDate, ScrumMaster scrumMaster) : base(name, startDate, endDate, scrumMaster)
    {
    }
    
    public void ToRelease()
    {
        CurrentState.ToRelease();
    }
}