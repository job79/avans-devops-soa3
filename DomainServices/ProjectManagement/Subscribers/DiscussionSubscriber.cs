using Domain;
using Domain.Account;
using Domain.ProjectManagement.Discussions;

namespace DomainServices.ProjectManagement.Subscribers;

public class DiscussionSubscriber : ISubscriber<Discussion>
{
    private User _user;
    private ISendMethod _sendMethod;
    
    public DiscussionSubscriber(User user, ISendMethod sendMethod)
    {
        this._user = user;
        this._sendMethod = sendMethod;
    }

    public void Update(Discussion sprint)
    {
        this._sendMethod.SendMessage(this._user, $"Discussion \"{sprint.Title}\" has been updated! Total posts: {sprint.Posts.Count}");
    }
}