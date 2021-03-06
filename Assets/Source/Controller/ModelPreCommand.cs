﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;

public class ModelPreCommand : SimpleCommand
{
    public override void Execute(PureMVC.Interfaces.INotification notification)
    {
       //注册Proxy
        Facade.RegisterProxy(new LoginProxy());
        Facade.RegisterProxy(new CheckPointProxy());
        Facade.RegisterProxy(new WebSocketTokenProxy());
        Facade.RegisterProxy(new ServerCommunicationProxy());
    }
}
