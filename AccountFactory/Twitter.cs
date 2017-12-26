

using System.Collections.Generic;
using NetCore20Auth;

public class Twitter : ITwitter
{
    private TwitterOptions _options;
    public User _user;
    private IList<string> _messages;
    private StatusEnum _status;

    public void SetParameters(TwitterOptions options)
    {
        _options = options;
        _messages = new List<string>();
    }

    public void Process()
    {
        throw new System.NotImplementedException();
    }

    public User GetUser => _user;
    public (StatusEnum status, IList<string> message) Result => (_status, _messages);
}

public interface ITwitter
{
    User GetUser { get; } 
    (StatusEnum status, IList<string> message) Result { get; } 
    void SetParameters(TwitterOptions options);
    void Process();
}