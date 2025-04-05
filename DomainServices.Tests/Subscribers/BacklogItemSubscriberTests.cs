
using Domain;
using Domain.Account;
using Domain.ProjectManagement.BacklogItems;
using Domain.ProjectManagement.Sprints;
using Domain.SourceManagement;
using DomainServices.ProjectManagement.Subscribers;
using Moq;

namespace DomainServices.Tests.Subscribers;

public class BacklogItemSubscriberTests
{
    private BacklogItem _backlogItem;
    private Tester _tester;
    private ScrumMaster _scrumMaster;
    private Developer _developer;
    
    [SetUp]
    public void Setup()
    {
        this._tester = new Tester("Tester", "tester@gmail.com");
        this._scrumMaster = new ScrumMaster("Rens", "rens@gmail.com");
        this._developer = new Developer("Developer", "developer@gmail.com");
        var sprint = new ReleaseSprint(
            "Sprint 1",
            DateTime.Now,
            DateTime.Now,
            this._scrumMaster,
            new GitRepository("AvansDevops")
        );
        this._backlogItem = new BacklogItem("Make unit tests", "Implement unit test for backlogItems", 2, sprint, this._tester);
    }
    
    [Test]
    public void TestSendsMessageToTester()
    {
        // Arrange
        this._backlogItem.Tester = this._tester;
        
        var mock = new Mock<ISendMethod>();
        mock.Setup(s => s.SendMessage(It.IsAny<User>(), It.IsAny<string>()));
        var subscriber = new BacklogItemSubscriber(this._tester, mock.Object);
        
        // Act
        this._backlogItem.Subscribe(subscriber);
        this._backlogItem.ToDoing();
        
        // Assert
        mock.Verify(s => s.SendMessage(this._tester, "BacklogItem \"Make unit tests\" updated! Status: - -> Doing"), Times.Never());
    }
    
    [Test]
    public void TestSendsMessageToTesterWithReadyForTestingState()
    {
        // Arrange
        this._backlogItem.Tester = this._tester;
        
        var mock = new Mock<ISendMethod>();
        mock.Setup(s => s.SendMessage(It.IsAny<User>(), It.IsAny<string>()));
        var subscriber = new BacklogItemSubscriber(this._tester, mock.Object);
        
        // Act
        this._backlogItem.Subscribe(subscriber);
        this._backlogItem.ToDoing();
        this._backlogItem.ToReadyForTesting();
        
        // Assert
        mock.Verify(s => s.SendMessage(this._tester, "BacklogItem \"Make unit tests\" updated! Status: Doing -> ReadyForTesting"), Times.Once());
    }
    
    [Test]
    public void TestSendsMessageToScrumMasterWhenMovedFromTestingToTodo()
    {
        // Arrange
        var mock = new Mock<ISendMethod>();
        mock.Setup(s => s.SendMessage(It.IsAny<User>(), It.IsAny<string>()));
        var subscriber = new BacklogItemSubscriber(this._scrumMaster, mock.Object);
        
        // Act
        this._backlogItem.Subscribe(subscriber);
        this._backlogItem.ToDoing();
        this._backlogItem.ToReadyForTesting();
        this._backlogItem.ToTesting();
        this._backlogItem.ToTodo();
        
        // Assert
        mock.Verify(s => s.SendMessage(this._scrumMaster, "BacklogItem \"Make unit tests\" updated! Status: Testing -> Todo"), Times.Once());
    }
    
    [Test]
    public void TestSendsMessageToScrumMasterWhenMovedFromDoingToTodo()
    {
        // Arrange
        var mock = new Mock<ISendMethod>();
        mock.Setup(s => s.SendMessage(It.IsAny<User>(), It.IsAny<string>()));
        var subscriber = new BacklogItemSubscriber(this._scrumMaster, mock.Object);
        
        // Act
        this._backlogItem.Subscribe(subscriber);
        this._backlogItem.ToDoing();
        this._backlogItem.ToTodo();
        
        // Assert
        mock.Verify(s => s.SendMessage(this._scrumMaster, "BacklogItem \"Make unit tests\" updated! Status: Doing -> Todo"), Times.Never());
    }
    
    [Test]
    public void TestSendsMessageToDeveloper()
    {
        // Arrange
        var developer = new Developer("Job", "Job@gmail.com");
        
        var mock = new Mock<ISendMethod>();
        mock.Setup(s => s.SendMessage(It.IsAny<User>(), It.IsAny<string>()));
        var subscriber = new BacklogItemSubscriber(developer, mock.Object);
        
        // Act
        this._backlogItem.Subscribe(subscriber);
        this._backlogItem.ToDoing();
        
        // Assert
        mock.Verify(s => s.SendMessage(developer, "BacklogItem \"Make unit tests\" updated! Status: - -> Doing"), Times.Never());
    }
    
    
    [Test]
    public void TestSendsMessageToDeveloperOfBacklogItem()
    {
        // Arrange
        this._backlogItem.Developer = this._developer;
        
        var mock = new Mock<ISendMethod>();
        mock.Setup(s => s.SendMessage(It.IsAny<User>(), It.IsAny<string>()));
        var subscriber = new BacklogItemSubscriber(this._developer, mock.Object);
        
        // Act
        this._backlogItem.Subscribe(subscriber);
        this._backlogItem.ToDoing();
        
        // Assert
        mock.Verify(s => s.SendMessage(this._developer, "BacklogItem \"Make unit tests\" updated! Status: - -> Doing"), Times.Once());
    }
}
