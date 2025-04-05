
using Domain;
using Domain.Account;
using Domain.ProjectManagement.BacklogItems;
using Domain.ProjectManagement.Discussions;
using Domain.ProjectManagement.Sprints;
using Domain.SourceManagement;
using Domain.Workflows;
using DomainServices.ProjectManagement.Subscribers;
using Moq;

namespace DomainServices.Tests.Subscribers;

public class SprintSubscriberTests
{
    private ReleaseSprint _sprint;
    private ScrumMaster _scrumMaster;
    
    [SetUp]
    public void Setup()
    {
        this._scrumMaster = new ScrumMaster("Rens", "rens@gmail.com");
        this._sprint = new ReleaseSprint(
            "Sprint 1",
            DateTime.Now,
            DateTime.Now,
            this._scrumMaster,
            new GitRepository("AvansDevops")
        );
    }
    
    [Test]
    public void TestSendMessageSprintCancelledMessage()
    {
        // Arrange
        var mock = new Mock<ISendMethod>();
        mock.Setup(s => s.SendMessage(It.IsAny<User>(), It.IsAny<string>()));
        var subscriber = new SprintSubscriber(this._scrumMaster, mock.Object);
        
        // Act
        this._sprint.Subscribe(subscriber);
        this._sprint.SetState(_sprint.Closed);
        
        // Assert
        mock.Verify(s => s.SendMessage(this._scrumMaster, "Sprint has been cancelled"), Times.Once());
    }
    
    [Test]
    public void TestSendMessageSprintIsSuccessful()
    {
        // Arrange
        var mock = new Mock<ISendMethod>();
        mock.Setup(s => s.SendMessage(It.IsAny<User>(), It.IsAny<string>()));
        var subscriber = new SprintSubscriber(this._scrumMaster, mock.Object);
        this._sprint.SetState(_sprint.Finished);
        
        // Act
        this._sprint.Subscribe(subscriber);
        this._sprint.ToReleased();
        
        // Assert
        mock.Verify(s => s.SendMessage(this._scrumMaster, "Sprint release pipeline was successful"), Times.Once());
    }
    
    
    [Test]
    public void TestSendMessageSprintPipelineFailed()
    {
        // Arrange
        var user = new Developer("Job", "Job@gmail.com");
        
        var mock = new Mock<ISendMethod>();
        mock.Setup(s => s.SendMessage(It.IsAny<User>(), It.IsAny<string>()));
        var subscriber = new SprintSubscriber(user, mock.Object);
        this._sprint.SetState(_sprint.Finished);
        
        var mockWorkflow = new Mock<WorkflowJob>(null!);
        mockWorkflow.Setup(s => s.Run())
            .Returns(new WorkflowResult(false, "Pipeline failed"));
        this._sprint.Repository.Workflows.Add(new Workflow([WorkflowTrigger.OnRelease], mockWorkflow.Object));
        
        // Act
        this._sprint.Subscribe(subscriber);
        this._sprint.ToReleased();
        
        // Assert
        mock.Verify(s => s.SendMessage(user, "Sprint release pipeline failed"), Times.Never());
    }
    
    
    [Test]
    public void TestSendMessageSprintPipelineFailedToScrumMaster()
    {
        // Arrange
        var mock = new Mock<ISendMethod>();
        mock.Setup(s => s.SendMessage(It.IsAny<User>(), It.IsAny<string>()));
        var subscriber = new SprintSubscriber(this._scrumMaster, mock.Object);
        this._sprint.SetState(_sprint.Finished);
        
        var mockWorkflow = new Mock<WorkflowJob>(null!);
        mockWorkflow.Setup(s => s.Run())
            .Returns(new WorkflowResult(false, "Pipeline failed"));
        this._sprint.Repository.Workflows.Add(new Workflow([WorkflowTrigger.OnRelease], mockWorkflow.Object));
        
        // Act
        this._sprint.Subscribe(subscriber);
        this._sprint.ToReleased();
        
        // Assert
        mock.Verify(s => s.SendMessage(this._scrumMaster, "Sprint release pipeline failed"), Times.Once());
    }
}
