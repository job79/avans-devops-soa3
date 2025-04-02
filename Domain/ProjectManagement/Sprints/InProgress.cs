namespace Domain.ProjectManagement.Sprints;

public class InProgress : ISprintState
{
    private Sprint _sprint;
    
    public InProgress(Sprint sprint)
    {
        _sprint = sprint;
    }
    
    public void ToInProgress()
    {
        throw new InvalidOperationException();
    }

    public void ToFinished()
    {
        _sprint.SetState(_sprint.Finished);
    }

    public void ToRelease()
    {
        throw new InvalidOperationException();
    }

    public void ToReview()
    {
        throw new InvalidOperationException();
    }

    public void ToClosed()
    {
        throw new InvalidOperationException();
    }
}