using Domain.Account;

namespace Domain.ProjectManagement;

public class Project : CompositeComponent
{
    public string Name { get; }
    public User ProductOwner { get; }

    public Project(string name, User productOwner)
    {
        this.Name = name;
        this.ProductOwner = productOwner;
    }
    
    public override void AcceptVisitor(Visitor visitor)
    {
        visitor.VisitProject(this);
        base.AcceptVisitor(visitor);
    }
}