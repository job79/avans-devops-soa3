using Domain.Account;
using Domain.SourceManagement;

namespace Domain.ProjectManagement.Sprints;

public abstract class Sprint : CompositeComponent
{
   public string Name { get; } 
   public DateTime StartDate { get; }
   public DateTime EndDate { get; }
   public ScrumMaster ScrumMaster { get; set; }
   public Repository Repository { get;  }
   
   public ISprintState CurrentState { get; set; }
   public Planned Planned { get; }
   public InProgress InProgress { get; }
   public Finished Finished { get; }  
   public Released Released { get; }
   public Review Review { get; }
   public Closed Closed { get; }
   
   private readonly List<ISubscriber<Sprint>> _subscribers = new ();

   protected Sprint(string name, DateTime startDate, DateTime endDate, ScrumMaster scrumMaster, Repository repository)
   {
      this.Name = name;
      this.StartDate = startDate;
      this.EndDate = endDate;
      this.ScrumMaster = scrumMaster;
      this.Repository = repository;

      Planned = new Planned(this);
      InProgress = new InProgress(this);
      Finished = new Finished(this);
      Released = new Released(this);
      Review = new Review(this);
      Closed = new Closed(this);

      CurrentState = Planned;
   }
   
   public override void AcceptVisitor(Visitor visitor)
   {
       visitor.VisitSprint(this);
       base.AcceptVisitor(visitor);
   }
   
   public new void Add(IComponent component)
   {
       if(CurrentState is not Sprints.Planned)
       {
           throw new InvalidOperationException();
       }
       Components.Add(component);
   }

   public void ToInProgress()
   {
       CurrentState.ToInProgress();
   }

   public void ToFinished()
   {
       CurrentState.ToFinished();
   }

   public void ToClosed()
   {
       CurrentState.ToClosed();
   }
   
   public void SetState(ISprintState sprintState)
   {
       CurrentState = sprintState;
       this.Notify();
   }
   
   public void Subscribe(ISubscriber<Sprint> subscriber)
   {
       this._subscribers.Add(subscriber);
   }

   public void Unsubscribe(ISubscriber<Sprint> subscriber)
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