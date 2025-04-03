namespace Domain.ProjectManagement;

// Composite pattern
public interface IComponent
{
    public void AcceptVisitor(Visitor visitor);
}