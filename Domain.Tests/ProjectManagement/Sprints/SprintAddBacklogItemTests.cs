using Domain.Account;
using Domain.ProjectManagement.BacklogItems;
using Domain.ProjectManagement.Sprints;
using Domain.SourceManagement;

namespace Domain.Tests.ProjectManagement.Sprints;

public class SprintAddBacklogItemTests
{
    private Sprint _sprint;
    private Tester _tester;
    
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
    }

    [Test]
    public void TestFromPlannedToInProgress()
    {
        // Arrange
        var backlogItem = new BacklogItem("Test", "Test", 1, _sprint, _tester);
        _sprint.ToInProgress();
        
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => _sprint.Add(backlogItem));
    }
}