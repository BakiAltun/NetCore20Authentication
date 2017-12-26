using System;
using System.Collections.Generic;
using NetCore20Auth;

public interface IAccount
{
    User GetUser { get; }
    bool IsFailed { get; }
    (StatusEnum status, IList<string> messages) Result { get; }
    
    void Process(Action<CustomOptions> options);
    void Process(Action<FacebookOptions> options);
    void Process(Action<TwitterOptions> options);
}