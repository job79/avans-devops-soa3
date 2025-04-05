using Domain.ProjectManagement.Tasks;
using Task = Domain.ProjectManagement.Tasks.Task;

namespace Domain.Tests.ProjectManagement.Tasks;

public class TaskStateTransitionTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestFromTodoToDoing()
    {
        // Arrange
        var task = new Task("Create accounts", "Create test accounts for the stakeholders.");
        
        // Act
        task.ToDoing();

        // Assert
        Assert.That(task.CurrentState, Is.InstanceOf<Doing>());
    }
    
    [Test]
    public void TestFromTodoToDone()
    {
        // Arrange
        var task = new Task("Create accounts", "Create test accounts for the stakeholders.");
        
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => task.ToDone());
    }
    
    [Test]
    public void TestFromDoingToDone()
    {
        // Arrange
        var task = new Task("Create accounts", "Create test accounts for the stakeholders.");
        task.SetState(task.Doing);

        // Act
        task.ToDone();
        
        // Assert
        Assert.That(task.CurrentState, Is.InstanceOf<Done>());
    }
    
    [Test]
    public void TestFromDoingToTodo()
    {
        // Arrange
        var task = new Task("Create accounts", "Create test accounts for the stakeholders.");
        task.SetState(task.Doing);
        
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => task.ToTodo());
    }
    
    [Test]
    public void TestFromDoneToDoing()
    {
        // Arrange
        var task = new Task("Create accounts", "Create test accounts for the stakeholders.");
        task.SetState(task.Done);
        
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => task.ToDoing());
    }
    
    [Test]
    public void TestFromDoneToTodo()
    {
        // Arrange
        var task = new Task("Create accounts", "Create test accounts for the stakeholders.");
        task.SetState(task.Done);
        
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => task.ToTodo());
    }

}