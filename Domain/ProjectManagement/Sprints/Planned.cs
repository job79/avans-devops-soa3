namespace Domain.ProjectManagement.Sprints;

//State pattern
public class Planned : ISprintState
{
    private readonly Sprint _sprint;
    
    public Planned(Sprint sprint)
    {
        _sprint = sprint;
    }
    
    public void ToInProgress()
    {
        _sprint.SetState(_sprint.InProgress);
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