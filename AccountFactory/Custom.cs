

using System.Collections.Generic;
using NetCore20Auth;

public class Custom : ICustom
{
    private CustomOptions _options;
    private User _user;
    private IList<string> _messages;
    private StatusEnum _status;

    public void SetParameters(CustomOptions options)
    {
        _options = options;
        _messages = new List<string>();
    }

    public void Process()
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

    void SetParameters(CustomOptions options);

    void Process();
}