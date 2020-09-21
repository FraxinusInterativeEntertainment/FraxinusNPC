using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class WebSocketTokenProxy : Proxy, IProxy, IResponder
{
    public const string NAME = "WebSocketTokenProxy";

    public WebSocketTokenProxy() : base(NAME) { }

    public void RequestForWSToken()
    {
        WsTokenDelegate wsTokenDelegate = new WsTokenDelegate(this);
        wsTokenDelegate.RequestForWsToken();
    }

    public void OnFault(object _data)
    {
        //TODO: Throw "not able to get ws token" error, retry
    }

    public void OnResult(object _data)
    {
        AppFacade.instance.SendNotification(Const.Notification.CONNECT_TO_WS_SERVER, _data);
    }
}
