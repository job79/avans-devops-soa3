using Domain.Account;
using Domain.ProjectManagement.BacklogItems;
using Domain.ProjectManagement.Discussions;
using Domain.ProjectManagement.Sprints;
using Domain.SourceManagement;

namespace Domain.Tests.ProjectManagement.Discussions;

public class DiscussionTests
{
    private Sprint _sprint;
    private Tester _tester;
    private Developer _developer;

    [SetUp]
    public void Setup()
    {
        this._sprint = new ReleaseSprint(
            "Sprint 1",
            DateTime.Now,
            DateTime.Now,
            new ScrumMaster("Rens", "rens@gmail.com"),
            new GitRepository("AvansDevops")
        );
        this._tester = new Tester("Tester", "tester@gmail.com");
        this._developer = new Developer("Developer", "developer@gmail.com");
    }

    [Test]
    public void TestAddingPostToOpenBacklogItem()
    {
        // Arrange
        var backlogItem = new BacklogItem("Make unit tests", "Implement unit test for backlogItems", 2, _sprint, _tester);
        backlogItem.Developer = _developer;
        
        var post = new Post("Post", _developer);
        var secondPost = new Post("Second Post", _developer);
        var discussion = new Discussion("Discussion", post, backlogItem);

        // Act
        backlogItem.AddDiscussion(discussion);
        discussion.AddPost(secondPost);
        
        //Assert
        Assert.That(discussion.Posts, Has.Count.EqualTo(2));
    }
    
    [Test]
    public void TestAddingPostToClosedBacklogItem()
    {
        // Arrange
        var backlogItem = new BacklogItem("Make unit tests", "Implement unit test for backlogItems", 2, _sprint, _tester);
        _sprint.Add(backlogItem);
        
        var post = new Post("Post", _developer);
        var secondPost = new Post("Second Post", _developer);
        var discussion = new Discussion("Discussion", post, backlogItem);

        // Act & Assert
        backlogItem.AddDiscussion(discussion);
        backlogItem.SetState(backlogItem.Done);
        Assert.Throws<InvalidOperationException>(() => discussion.AddPost(secondPost));
        Assert.That(discussion.Posts, Has.Count.EqualTo(1));
    }
    
    [Test]
    public void TestAddingDiscussionToClosedBacklogItems()
    {
        // Arrange
        var backlogItem = new BacklogItem("Make unit tests", "Implement unit test for backlogItems", 2, _sprint, _tester);
        backlogItem.SetState(backlogItem.Done);
        _sprint.Add(backlogItem);
        
        var post = new Post("Post", _developer);
        var discussion = new Discussion("Discussion", post, backlogItem);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => backlogItem.AddDiscussion(discussion));
    }
}