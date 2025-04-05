using Domain.Account;
using Domain.SourceManagement;
using Domain.Workflows;
using Moq;
using File = Domain.SourceManagement.File;

namespace Domain.Tests.SourceManagement;

public class SvnRepositoryTests
{
    private Repository _repository;
    private Commit _firstCommit;
    private Developer _developer;

    [SetUp]
    public void Setup()
    {
        this._repository = new SvnRepository("AvansDevops");
        this._developer = new Developer("Job", "Job@gmail.com");
        this._firstCommit = new Commit("1", "fix: bug", this._developer, [new File("test.txt", "test")], null);
        this._repository.Commit(this._firstCommit);
    }

    [Test]
    public void TestCommit()
    {
        // Arrange
        var commit = new Commit("1", "fix: bug", this._developer, [new File("test.txt", "test")], this._firstCommit);

        // Act
        this._repository.Commit(commit);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(this._repository.Commits, Has.Count.EqualTo(2));
            Assert.That(this._repository.Files, Has.Count.EqualTo(1));
        });
    }

    [Test]
    public void TestPush()
    {
        // Arrange
        var mock = new Mock<WorkflowJob>(null!);
        mock.Setup(s => s.Run())
            .Returns(new WorkflowResult(false, "Pipeline failed"));
        this._repository.Workflows.Add(new Workflow([WorkflowTrigger.OnPush], mock.Object));

        // Act
        this._repository.Push();

        // Assert
        mock.Verify(s => s.Run(), Times.Once());
    }
    
    [Test]
    public void AddBranch()
    {
        // Arrange
        var branch = new Branch("main", this._firstCommit);
        
        // Act
        this._repository.Branches.Add(branch);

        // Assert
        Assert.That(this._repository.Branches, Has.Count.EqualTo(1));
    }
}