using Domain.Account;
using Domain.ProjectManagement.BacklogItems;

namespace Domain.ProjectManagement.Discussions;

public class Discussion
{
   public string Title { get; } 
   public User Author => this.Posts[0].Author;
   public BacklogItem BacklogItem { get; }
   public List<Post> Posts { get; }
   private readonly List<ISubscriber<Discussion>> _subscribers = new ();

   public Discussion(string title, Post post, BacklogItem backlogItem)
   {
      this.Title = title;
      this.Posts = new List<Post> { post };
      this.BacklogItem = backlogItem;
   }

   public void AddPost(Post post)
   {
      if (this.BacklogItem.CurrentState is Done)
      {
         throw new InvalidOperationException();
      }
      
      this.Posts.Add(post);
      this.Notify();
   }

   public void Subscribe(ISubscriber<Discussion> subscriber)
   {
      this._subscribers.Add(subscriber);
   }

   public void Unsubscribe(ISubscriber<Discussion> subscriber)
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