using Domain.Account;
using Domain.ProjectManagement.BacklogItems;
using Domain.ProjectManagement.Sprints;
using Domain.SourceManagement;

namespace Domain.Tests.ProjectManagement.BacklogItems;

public class BacklogStateTransitionTests
{
    private Sprint _sprint;
    private Tester _tester;
    
    [SetUp]
    public void Setup()
    {
        this._tester = new Tester("Tester", "tester@gmail.com");
        this._sprint = new ReleaseSprint(
            "Sprint 1",
            DateTime.Now,
            DateTime.Now,
            new ScrumMaster("Rens", "rens@gmail.com"),
            new GitRepository("AvansDevops")
        );
    }

    [Test]
    public void TestFromTodoToDoing()
    {
        // Arrange
        var backlogItem = new BacklogItem("Make unit tests", "Implement unit test for backlogItems",  2, _sprint, _tester);
        
        // Act
        backlogItem.ToDoing();

        // Assert
        Assert.That(backlogItem.CurrentState, Is.InstanceOf<Doing>());
    }
    
    [Test]
    public void TestFromTodoToDone()
    {
        // Arrange
        var backlogItem = new BacklogItem("Make unit tests", "Implement unit test for backlogItems",  2, _sprint, _tester);
        
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => backlogItem.ToDone());
    }
    
    [Test]
    public void TestFromDoingToReadyForTesting()
    {
        // Arrange
        var backlogItem = new BacklogItem("Make unit tests", "Implement unit test for backlogItems",  2, _sprint, _tester);
        backlogItem.SetState(backlogItem.Doing);

        // Act
        backlogItem.ToReadyForTesting();
        
        // Assert
        Assert.That(backlogItem.CurrentState, Is.InstanceOf<ReadyForTesting>());
    }
    
    [Test]
    public void TestFromDoingToDone()
    {
        // Arrange
        var backlogItem = new BacklogItem("Make unit tests", "Implement unit test for backlogItems",  2, _sprint, _tester);
        backlogItem.SetState(backlogItem.Doing);
        
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => backlogItem.ToDone());
    }

    [Test]
    public void TestFromReadyForTestingToTesting()
    {
        // Arrange
        var backlogItem = new BacklogItem("Make unit tests", "Implement unit test for backlogItems",  2, _sprint, _tester);
        backlogItem.SetState(backlogItem.ReadyForTesting);

        // Act
        backlogItem.ToTesting();
        
        // Assert
        Assert.That(backlogItem.CurrentState, Is.InstanceOf<Testing>());
    }
    
    [Test]
    public void TestFromReadyForTestingToDone()
    {
        // Arrange
        var backlogItem = new BacklogItem("Make unit tests", "Implement unit test for backlogItems",  2, _sprint, _tester);
        backlogItem.SetState(backlogItem.ReadyForTesting);
        
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => backlogItem.ToDone());
    }
    
    [Test]
    public void TestFromTestingToTested()
    {
        // Arrange
        var backlogItem = new BacklogItem("Make unit tests", "Implement unit test for backlogItems",  2, _sprint, _tester);
        backlogItem.SetState(backlogItem.Testing);

        // Act
        backlogItem.ToTested();
        
        // Assert
        Assert.That(backlogItem.CurrentState, Is.InstanceOf<Tested>());
    }
    
    [Test]
    public void TestFromTestingToTodo()
    {
        // Arrange
        var backlogItem = new BacklogItem("Make unit tests", "Implement unit test for backlogItems",  2, _sprint, _tester);
        backlogItem.SetState(backlogItem.Testing);

        // Act
        backlogItem.ToTodo();
        
        // Assert
        Assert.That(backlogItem.CurrentState, Is.InstanceOf<Todo>());
    }
    
    [Test]
    public void TestFromTestingToDone()
    {
        // Arrange
        var backlogItem = new BacklogItem("Make unit tests", "Implement unit test for backlogItems",  2, _sprint, _tester);
        backlogItem.SetState(backlogItem.Testing);
        
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => backlogItem.ToDone());
    }
    
    
    [Test]
    public void TestFromTestedToDone()
    {
        // Arrange
        var backlogItem = new BacklogItem("Make unit tests", "Implement unit test for backlogItems",  2, _sprint, _tester);
        backlogItem.SetState(backlogItem.Tested);
        
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => backlogItem.ToDone());
    }
    
    [Test]
    public void TestFromDoneToTesting()
    {
        // Arrange
        var backlogItem = new BacklogItem("Make unit tests", "Implement unit test for backlogItems",  2, _sprint, _tester);
        backlogItem.SetState(backlogItem.Done);
        
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => backlogItem.ToTesting());
    }
}