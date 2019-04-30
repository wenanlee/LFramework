using LFramework.Core.Module;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventModule : EventBase<int,EventModule,object> {
    public void Dispatcher(int key,params object[] args)
    {
        base.Dispatch(key, args);
    }
    public void Show()
    {

    }
}
