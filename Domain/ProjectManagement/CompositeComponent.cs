namespace Domain.ProjectManagement;

// Composite pattern
public abstract class CompositeComponent : IComponent
{
    public List<IComponent> Components { get; } = new();
    
    public void Add(IComponent component)
    {
        Components.Add(component);
    }

    public virtual void AcceptVisitor(Visitor visitor)
    {
        foreach (IComponent component in Components)
        {
            component.AcceptVisitor(visitor);
        }
    }
}