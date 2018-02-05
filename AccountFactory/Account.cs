

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
        var customOptions = new CustomOptions();
        options(customOptions);

 
        _custom.Process(customOptions);
        _user = _custom.GetUser;
        _result = _custom.Result;
    }

    public void Process(Action<FacebookOptions> options)
    { 
        var facebookOptions = new FacebookOptions();
        options(facebookOptions);

    
        _facebook.Process(facebookOptions);

        _user = _facebook.GetUser;
        _result = _facebook.Result;
    }

    public void Process(Action<TwitterOptions> options)
    {
        var twitterOptions = new TwitterOptions();
        options(twitterOptions);
 
        _twitter.Process(twitterOptions);

        _user = _twitter.GetUser;
        _result = _twitter.Result;
    }
    public bool IsFailed { get => _result.status == StatusEnum.Error; }
    public User GetUser => _user;
    public (StatusEnum status, IList<string> messages) Result => _result;
}