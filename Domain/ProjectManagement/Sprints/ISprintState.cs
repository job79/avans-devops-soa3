namespace Domain.ProjectManagement.Sprints;

public interface ISprintState
{
    public void ToInProgress();
    public void ToFinished();
    public void ToRelease();
    public void ToReview();
    public void ToClosed();
}