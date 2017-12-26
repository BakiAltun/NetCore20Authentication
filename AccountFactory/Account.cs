

using System;
using System.Collections.Generic;
using NetCore20Auth;

public class Account : IAccount
{
    private readonly ICustom _custom;
    private readonly IFacebook _facebook;
    private readonly ITwitter _twitter;
    public Account(ICustom custom, IFacebook facebook, ITwitter twitter)
    {
        _custom = custom;
        _twitter = twitter;
        _facebook = facebook;
    }

    private User _user;
    private (StatusEnum status, IList<string> messages) _result;

    public void Process(Action<CustomOptions> options)
    {
        options = (x) =>
        {
            _custom.SetParameters(x);
        };

        _custom.Process();
        _user = _custom.GetUser;
        _result = _custom.Result;
    }

    public void Process(Action<FacebookOptions> options)
    {
        options = (x) =>
        {
            _facebook.SetParameters(x);
        };

        _facebook.Process();
        _user = _facebook.GetUser;
        _result = _facebook.Result;
    }

    public void Process(Action<TwitterOptions> options)
    {
        options = (x) =>
        {
            _twitter.SetParameters(x);
        };

        _twitter.Process();
        _user = _twitter.GetUser;
        _result = _twitter.Result;
    }
    public bool IsFailed { get => _result.status == StatusEnum.Error; } 
    public User GetUser => _user;
    public (StatusEnum status, IList<string> messages) Result => _result;
}