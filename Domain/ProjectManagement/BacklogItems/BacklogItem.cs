using Domain.Account;
using Domain.ProjectManagement.Discussions;
using Domain.ProjectManagement.Sprints;

namespace Domain.ProjectManagement.BacklogItems;

public class BacklogItem : CompositeComponent
{
    public string Title { get; }
    public string Description { get; }
    public int StoryPoints { get; }
    public User Tester { get; set; }
    public Sprint Sprint { get; }
    public List<Discussion> Discussions { get; } = new ();
    
    public IBacklogItemState CurrentState { get; private set; }
    public Todo Todo { get; set; }
    public Doing Doing { get; set; }
    public ReadyForTesting ReadyForTesting { get; set; }
    public IBacklogItemState Testing { get; set; }
    public Tested Tested { get; set; }
    public Done Done { get; set; }
    
    private readonly List<ISubscriber<BacklogItem>> _subscribers = new ();
    
    private User? _developer;

    public User? Developer
    {
	    get => _developer;
	    set
	    {
		    if (this.Sprint.Components.Count(x => x is BacklogItem b && b.Developer == value && b.CurrentState is not BacklogItems.Done) > 0)
		    {
			    throw new InvalidOperationException($"This developer is already working on another backlog item");
		    }
		    _developer = value;
	    }
    }

    public BacklogItem(string title, string description, int storyPoints, Sprint sprint, Tester tester)
    {
	    this.Title = title;
		this.Description = description;
		this.StoryPoints = storyPoints;
		this.Sprint = sprint;
		this.Tester = tester;

		Todo = new Todo(this);
		Doing = new Doing(this);
		ReadyForTesting = new ReadyForTesting(this);
		Testing = new Testing(this);
		Tested = new Tested(this);
		Done = new Done(this);

		CurrentState = Todo;
    }

    public override void AcceptVisitor(Visitor visitor)
    {
	    visitor.VisitBacklogItem(this);
	    base.AcceptVisitor(visitor);
    }
    
    public void ToTodo()
    {
	    CurrentState.ToTodo();
    }
    
    public void ToDoing()
    {
	    CurrentState.ToDoing();
    }
    
    public void ToReadyForTesting()
    {
	    CurrentState.ToReadyForTesting();
    }
    
    public void ToTesting()
    {
	    CurrentState.ToTesting();
    }
    
    public void ToTested()
    {
	    CurrentState.ToTested();
    }
    
    public void ToDone()
    {
	    CurrentState.ToDone();
    }

    public void SetState(IBacklogItemState backlogItemState)
    {
	    CurrentState = backlogItemState;
	    this.Notify();
    }

    public void AddDiscussion(Discussion discussion)
    {
	    if (this.CurrentState is Done)
	    {
		    throw new InvalidOperationException();
	    }
	    
	    this.Discussions.Add(discussion);
    }
    
    public void Subscribe(ISubscriber<BacklogItem> subscriber)
    {
	    this._subscribers.Add(subscriber);
    }

    public void Unsubscribe(ISubscriber<BacklogItem> subscriber)
    {
	    this._subscribers.Remove(subscriber);
    }
   
    private void Notify()
    {
	    foreach (var subscriber in this._subscribers)
	    {
		    subscriber.Update(this);
	    }
    }
}