using Domain.Account;
using Domain.ProjectManagement.BacklogItems;
using Domain.ProjectManagement.Sprints;
using Domain.SourceManagement;

namespace Domain.Tests.ProjectManagement.BacklogItems;

public class ActiveBacklogItemLimitTests
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
    public void TestAddingDeveloperToBacklogItem()
    {
        // Arrange
        var backlogItem = new BacklogItem("Make unit tests", "Implement unit test for backlogItems", 2, _sprint, _tester);
        backlogItem.Developer = _developer;

        // Act & Assert
        Assert.That(backlogItem.Developer, Is.EqualTo(_developer));
    }
    
    
    [Test]
    public void TestAddingDeveloperToMultipleBacklogItems()
    {
        // Arrange
        var backlogItem = new BacklogItem("Make unit tests", "Implement unit test for backlogItems", 2, _sprint, _tester);
        _sprint.Add(backlogItem);
        backlogItem.Developer = _developer;
        
        var backlogItem2 = new BacklogItem("Make unit tests", "Implement unit test for backlogItems", 2, _sprint, _tester);
        _sprint.Add(backlogItem2);
        
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => backlogItem2.Developer = _developer);
    }
    
    [Test]
    public void TestAddingDeveloperToMultipleBacklogItemsIgnoringDoneItems()
    {
        // Arrange
        var backlogItem = new BacklogItem("Make unit tests", "Implement unit test for backlogItems", 2, _sprint, _tester);
        _sprint.Add(backlogItem);
        backlogItem.Developer = _developer;
        backlogItem.SetState(backlogItem.Done);
        
        var backlogItem2 = new BacklogItem("Make unit tests", "Implement unit test for backlogItems", 2, _sprint, _tester);
        _sprint.Add(backlogItem2);
        backlogItem2.Developer = _developer;
        
        // Act & Assert
        Assert.That(backlogItem2.Developer, Is.EqualTo(_developer));
    }
}