namespace Domain.ProjectManagement.Sprints;

public class Finished : ISprintState
{
    private Sprint _sprint;
    
    public Finished(Sprint sprint)
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
        _sprint.SetState(_sprint.Review);
    }

    public void ToClosed()
    {
        throw new InvalidOperationException();
    }
}