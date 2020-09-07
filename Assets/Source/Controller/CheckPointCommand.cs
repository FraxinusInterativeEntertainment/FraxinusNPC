using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class CheckPointCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        object obj = notification.Body;
        CheckPointProxy checkPointProxy;
        checkPointProxy = Facade.RetrieveProxy(CheckPointProxy.NAME) as CheckPointProxy;
        string name = notification.Name;

        switch (name)
        {
            case Const.Notification.SEND_ACTOR_CHECK_POINT_RECORD :
                checkPointProxy.SendActorCheckPointRecord(obj);
                break;
        }
    }
}
