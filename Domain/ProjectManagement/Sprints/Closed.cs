namespace Domain.ProjectManagement.Sprints;

public class Closed : ISprintState
{
    private Sprint _sprint;
    
    public Closed(Sprint sprint)
    {
        _sprint = sprint;
    }
    
    public void ToInProgress()
    {
        throw new InvalidOperationException();
    }

    public void ToFinished()
    {
        throw new InvalidOperationException();
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