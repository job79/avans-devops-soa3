namespace Domain.ProjectManagement;

public abstract class CompositeComponent : Component
{
    public List<Component> Components { get; } = new();
    
    public void Add(Component component)
    {
        Components.Add(component);
    }

    public override void AcceptVisitor(Visitor visitor)
    {
        foreach (Component component in Components)
        {
            component.AcceptVisitor(visitor);
        }
    }
}