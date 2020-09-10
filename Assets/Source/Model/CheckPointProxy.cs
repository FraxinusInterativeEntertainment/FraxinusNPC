using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class CheckPointProxy : Proxy, IProxy, IResponder
{
    public const string NAME = "CheckPointProxy";

    public CheckPointProxy() : base(NAME) { }

    public void SendActorCheckPointRecord(object _data)
    {
        CheckPointDelegate checkPointDelegate = new CheckPointDelegate(this,_data as ActorCheckpointRecord);
        checkPointDelegate.CheckPointRecordServerce();
    }
    public void OnResult(object _data)
    {
    }
    public void OnFault(object _data)
    {

    }
}
