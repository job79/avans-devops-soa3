
using Domain;
using Domain.Account;
using Domain.ProjectManagement.BacklogItems;
using Domain.ProjectManagement.Discussions;
using Domain.ProjectManagement.Sprints;
using Domain.SourceManagement;
using DomainServices.ProjectManagement.Subscribers;
using Moq;

namespace DomainServices.Tests.Subscribers;

public class DiscussionSubscriberTests
{
    private Discussion _discussion;
    private User _user;
    
    [SetUp]
    public void Setup()
    {
        var tester = new Tester("Tester", "tester@gmail.com");
        var sprint = new ReleaseSprint(
            "Sprint 1",
            DateTime.Now,
            DateTime.Now,
            new ScrumMaster("Rens", "rens@gmail.com"),
            new GitRepository("AvansDevops")
        );
        var backlogItem = new BacklogItem("Make unit tests", "Implement unit test for backlogItems", 2, sprint, tester);
        this._user = new Developer("Job", "job@gmail.com");
        this._discussion = new Discussion("Moq?", new Post("How to use Moq?", this._user), backlogItem);
    }
    
    
    [Test]
    public void TestSendsMessage()
    {
        // Arrange
        var mock = new Mock<ISendMethod>();
        mock.Setup(s => s.SendMessage(It.IsAny<User>(), It.IsAny<string>()));
        var subscriber = new DiscussionSubscriber(this._user, mock.Object);
        
        // Act
        this._discussion.Subscribe(subscriber);
        this._discussion.AddPost(new Post("New post", this._user));
        
        // Assert
        mock.Verify(s => s.SendMessage(this._user, "Discussion \"Moq?\" has been updated! Total posts: 2"), Times.Once());
    }
}
