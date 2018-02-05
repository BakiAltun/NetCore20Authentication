

using System.Collections.Generic;
using NetCore20Auth;

public class Custom : ICustom
{
    private CustomOptions _options;
    private User _user;
    private IList<string> _messages;
    private StatusEnum _status;
 

    public void Process(CustomOptions options)
    {
        _messages.Add("");
        _status = StatusEnum.Success;

        throw new System.NotImplementedException();
    }
    public User GetUser => _user;
    public (StatusEnum status, IList<string> messages) Result => (_status, _messages);
}


public interface ICustom
{
    User GetUser { get; }

    (StatusEnum status, IList<string> messages) Result { get; }
 
    void Process(CustomOptions options);
}