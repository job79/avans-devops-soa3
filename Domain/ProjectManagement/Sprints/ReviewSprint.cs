using Domain.Account;

namespace Domain.ProjectManagement.Sprints;

public class ReviewSprint : Sprint
{
    public ReviewSprint(string name, DateTime startDate, DateTime endDate, ScrumMaster scrumMaster) : base(name, startDate, endDate, scrumMaster)
    {
        
    }
    
    public void ToReview()
    {
        CurrentState.ToReview();
    }
}