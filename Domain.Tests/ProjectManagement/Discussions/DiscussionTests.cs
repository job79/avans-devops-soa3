using Domain.Account;
using Domain.ProjectManagement;
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
    private Project _project;

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
    public void TestAddingPostToOpenSprint()
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
        Assert.That(discussion.Posts.Count, Is.EqualTo(2));
    }
    
    [Test]
    public void TestAddingPostToClosedSprint()
    {
        // Arrange
        var backlogItem = new BacklogItem("Make unit tests", "Implement unit test for backlogItems", 2, _sprint, _tester);
        var backlogItem2 = new BacklogItem("Make unit tests", "Implement unit test for backlogItems", 3, _sprint, _tester);
        

        // Act
        // var totalStory
        
        //Assert
        // Assert.That(discussion.Posts.Count, Is.EqualTo(1));
    }
}