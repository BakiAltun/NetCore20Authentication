

using System.Collections.Generic;
using NetCore20Auth;

public class Facebook : IFacebook
{
    private FacebookOptions _options;
    private User _user;
    private IList<string> _messages;
    private StatusEnum _status;
 
    public void Process(FacebookOptions options)
    {
        _options = options;
        
        throw new System.NotImplementedException();
    }

    public (StatusEnum status, IList<string> messages) Result => (_status, _messages);
    public User GetUser { get => _user; }
}

public interface IFacebook
{
    User GetUser { get; }

    (StatusEnum status, IList<string> messages) Result { get; }
 
    
    void Process(FacebookOptions options);
}