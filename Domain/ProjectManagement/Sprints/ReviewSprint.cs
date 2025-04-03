using Domain.Account;
using Domain.SourceManagement;

namespace Domain.ProjectManagement.Sprints;

public class ReviewSprint : Sprint
{
    private string? Review { get; set; }
    
    public ReviewSprint(string name, DateTime startDate, DateTime endDate, ScrumMaster scrumMaster, Repository repository) : base(name, startDate, endDate, scrumMaster, repository)
    {
        
    }
    
    public void ToReview()
    {
        CurrentState.ToReview();
    }
    
    public new void ToClosed()
    {
        if(this.Review != null)
        {
            CurrentState.ToClosed();
        }
    }
}