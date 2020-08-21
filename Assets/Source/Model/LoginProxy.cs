using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class LoginProxy : Proxy, IProxy, IResponder
{
    public const string NAME = "LoginProxy";

    public LoginProxy() : base(NAME) { }
    public void QrSendLogin(object _data)
    {
        //TODO:Add did
        SendLogin(_data, "");
    }

    public void SendLogin(object _data,string _did)
    {
        LoginDelegate loginDelegate = new LoginDelegate(this, _data as LoginVO,_did);
        loginDelegate.LoginService();
    }
    public void OnResult(object _data)
    {
        Debug.Log("login success");
        SendNotification(Const.Notification.LOGIN_SUCCESS, _data);
    }

    public void OnFault(object _data)
    {
        SendNotification(Const.Notification.LOGIN_FAIL, _data);
    }
}
