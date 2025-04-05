namespace Domain.ProjectManagement.Sprints;

//State pattern
public class Released : ISprintState
{
    private readonly Sprint _sprint;
    
    public Released(Sprint sprint)
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
        _sprint.SetState(_sprint.Released);
    }

    public void ToReview()
    {
        throw new InvalidOperationException();
    }

    public void ToClosed()
    {
        _sprint.SetState(_sprint.Closed);
    }
}