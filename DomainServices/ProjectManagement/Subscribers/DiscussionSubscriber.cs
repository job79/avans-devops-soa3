using Domain;
using Domain.Account;
using Domain.ProjectManagement.Discussions;

namespace DomainServices.ProjectManagement.Subscribers;

//Observer pattern
public class DiscussionSubscriber : ISubscriber<Discussion>
{
    private readonly User _user;
    private readonly ISendMethod _sendMethod;
    
    public DiscussionSubscriber(User user, ISendMethod sendMethod)
    {
        this._user = user;
        this._sendMethod = sendMethod;
    }

    public void Update(Discussion discussion)
    {
        this._sendMethod.SendMessage(this._user, $"Discussion \"{discussion.Title}\" has been updated! Total posts: {discussion.Posts.Count}");
    }
}