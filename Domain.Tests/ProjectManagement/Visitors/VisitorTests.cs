using Domain.Account;
using Domain.ProjectManagement;
using Domain.ProjectManagement.BacklogItems;
using Domain.ProjectManagement.Discussions;
using Domain.ProjectManagement.Export;
using Domain.ProjectManagement.Sprints;
using Domain.ProjectManagement.Visitors;
using Domain.SourceManagement;
using DomainServices.ProjectManagement.Export;
using Moq;

namespace Domain.Tests.ProjectManagement.Visitors;

public class VisitorTests
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
    public void TestTotalStoryPointsVisitor()
    {
        // Arrange
        var backlogItem1 = new BacklogItem("Make unit tests", "Implement unit test for backlogItems", 2, _sprint, _tester);
        var backlogItem2 = new BacklogItem("Make unit tests", "Implement unit test for backlogItems", 3, _sprint, _tester);
        backlogItem1.Developer = _developer;
        backlogItem2.Developer = _developer;
        _sprint.Add(backlogItem1);
        _sprint.Add(backlogItem2);
        var exportMethod = new ExportPdf();
        var storyPointsVisitor = new TotalStoryPointsVisitor(exportMethod);

        // Act
        _sprint.AcceptVisitor(storyPointsVisitor);
        
        //Assert
        Assert.That(storyPointsVisitor.GetTotalStoryPoints(), Is.EqualTo(5));
    }
    
    [Test]
    public void TestBurnDownChartVisitor()
    {
        // Arrange
        var backlogItem1 = new BacklogItem("Make unit tests", "Implement unit test for backlogItems", 2, _sprint, _tester);
        var backlogItem2 = new BacklogItem("Make unit tests", "Implement unit test for backlogItems", 3, _sprint, _tester);
        backlogItem1.Developer = _developer;
        backlogItem2.Developer = _developer;
        _sprint.Add(backlogItem1);
        _sprint.Add(backlogItem2);
        var exportMethod = new ExportPdf();
        var storyPointsVisitor = new BurnDownChartVisitor(exportMethod);

        // Act
        _sprint.AcceptVisitor(storyPointsVisitor);
        
        //Assert
        Assert.That(storyPointsVisitor.GetTotalStoryPoints(), Is.EqualTo(5));
    }
    
    [Test]
    public void TestExportRapport()
    {
        // Arrange
        var backlogItem1 = new BacklogItem("Make unit tests", "Implement unit test for backlogItems", 2, _sprint, _tester);
        var backlogItem2 = new BacklogItem("Make unit tests", "Implement unit test for backlogItems", 3, _sprint, _tester);
        backlogItem1.Developer = _developer;
        backlogItem2.Developer = _developer;
        _sprint.Add(backlogItem1);
        _sprint.Add(backlogItem2);
    
        var mock = new Mock<IExportMethod>();
        mock.Setup(s => s.Export("", false, true));
        var storyPointsVisitor = new TotalStoryPointsVisitor(mock.Object);

        // Act
        _sprint.AcceptVisitor(storyPointsVisitor);
        storyPointsVisitor.Export(false, true);

        // Assert
        mock.Verify(s => s.Export(It.Is<string>(rapport => rapport.Contains("Total story points: 5")), false, true), Times.Once());
    }
}