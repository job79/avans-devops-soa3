namespace Domain.ProjectManagement.Sprints;

//State pattern
public class Closed : ISprintState
{
    public Closed(Sprint sprint)
    {
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