using Domain.Account;
using Domain.ProjectManagement.BacklogItems;
using Domain.ProjectManagement.Sprints;
using Domain.SourceManagement;

namespace Domain.Tests.ProjectManagement.Sprints;

public class SprintStateTransitionTests
{
    private Repository _repository;
    private ScrumMaster _scrumMaster;
    
    [SetUp]
    public void Setup()
    {
        _repository = new GitRepository("AvansDevops");
        _scrumMaster = new ScrumMaster("Rens", "rens@gmail.com");
 
    }

    [Test]
    public void TestFromPlannedToInProgress()
    {
        // Arrange
        var sprint = new ReleaseSprint("Sprint 1", DateTime.Now, DateTime.Now, _scrumMaster, _repository);
        
        // Act
        sprint.ToInProgress();

        // Assert
        Assert.That(sprint.CurrentState, Is.InstanceOf<InProgress>());
    }
    
    [Test]
    public void TestFromPlannedToClosed()
    {
        // Arrange
        var sprint = new ReleaseSprint("Sprint 1", DateTime.Now, DateTime.Now, _scrumMaster, _repository);
        
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => sprint.ToClosed());
    }
    
    [Test]
    public void TestFromInProgressToFinished()
    {
        // Arrange
        var sprint = new ReleaseSprint("Sprint 1", DateTime.Now, DateTime.Now, _scrumMaster, _repository);
        sprint.SetState(sprint.InProgress);
        
        // Act
        sprint.ToFinished();

        // Assert
        Assert.That(sprint.CurrentState, Is.InstanceOf<Finished>());
    }
    
    [Test]
    public void TestFromInProgressToClosed()
    {
        // Arrange
        var sprint = new ReleaseSprint("Sprint 1", DateTime.Now, DateTime.Now, _scrumMaster, _repository);
        sprint.SetState(sprint.InProgress);
        
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => sprint.ToClosed());
    }
    
    [Test]
    public void TestFromFinishedToRelease()
    {
        // Arrange
        var sprint = new ReleaseSprint("Sprint 1", DateTime.Now, DateTime.Now, _scrumMaster, _repository);
        sprint.SetState(sprint.Finished);
        
        // Act
        sprint.ToReleased();

        // Assert
        Assert.That(sprint.CurrentState, Is.InstanceOf<Released>());
    }
    
    [Test]
    public void TestFromFinishedToReview()
    {
        // Arrange
        var sprint = new ReviewSprint("Sprint 1", DateTime.Now, DateTime.Now, _scrumMaster, _repository);
        sprint.SetState(sprint.Finished);
        
        // Act
        sprint.ToReview();

        // Assert
        Assert.That(sprint.CurrentState, Is.InstanceOf<Review>());
    }
    
    [Test]
    public void TestFromFinishedToClosed()
    {
        // Arrange
        var sprint = new ReleaseSprint("Sprint 1", DateTime.Now, DateTime.Now, _scrumMaster, _repository);
        sprint.SetState(sprint.Finished);
        
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => sprint.ToClosed());
    }
    
    [Test]
    public void TestFromReleasedToClosed()
    {
        // Arrange
        var sprint = new ReleaseSprint("Sprint 1", DateTime.Now, DateTime.Now, _scrumMaster, _repository);
        sprint.SetState(sprint.Released);
        
        // Act
        sprint.ToClosed();

        // Assert
        Assert.That(sprint.CurrentState, Is.InstanceOf<Closed>());
    }

    
    [Test]
    public void TestFromReviewToClosed()
    {
        // Arrange
        var sprint = new ReviewSprint("Sprint 1", DateTime.Now, DateTime.Now, _scrumMaster, _repository);
        sprint.SetState(sprint.Review);
        sprint.ReviewDescription = "Description";
        
        // Act
        sprint.ToClosed();

        // Assert
        Assert.That(sprint.CurrentState, Is.InstanceOf<Closed>());
    }
   
    [Test]
    public void TestFromReleasedToInProgress()
    {
        // Arrange
        var sprint = new ReleaseSprint("Sprint 1", DateTime.Now, DateTime.Now, _scrumMaster, _repository);
        sprint.SetState(sprint.Released);
        
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => sprint.ToInProgress());
    }
    
    [Test]
    public void TestFromReviewToInProgress()
    {
        // Arrange
        var sprint = new ReviewSprint("Sprint 1", DateTime.Now, DateTime.Now, _scrumMaster, _repository);
        sprint.SetState(sprint.Review);
        
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => sprint.ToInProgress());
    }
    
    [Test]
    public void TestFromClosedToInProgress()
    {
        // Arrange
        var sprint = new ReviewSprint("Sprint 1", DateTime.Now, DateTime.Now, _scrumMaster, _repository);
        sprint.SetState(sprint.Closed);
        
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => sprint.ToInProgress());
    }
}