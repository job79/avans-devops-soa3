namespace Domain.ProjectManagement;

public abstract class Component
{
    public abstract void AcceptVisitor(Visitor visitor);
}