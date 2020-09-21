using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class LoginProxy : Proxy, IProxy, IResponder
{
    public const string NAME = "LoginProxy";

    public LoginProxy() : base(NAME) { }
    public ActorInfo actorInfos;
    public void QrSendLogin(object _data)
    {
        //TODO:Add did,gameID
        SendLogin(_data, "TestUWB456", "2020921_1");
    }

    public void SendLogin(object _data,string _did,string _gameID)
    {
        LoginDelegate loginDelegate = new LoginDelegate(this, _data as LoginVO,_did,_gameID);
        loginDelegate.LoginService();
    }
    public void OnResult(object _data)
    {
        SendNotification(Const.Notification.LOAD_UI_ROOT_FORM, Const.UIFormNames.CHECK_POINT_FORM_NORMAL);
        AppFacade.instance.SendNotification(Const.Notification.SETUP_CONNECTION_WITH_SERVER);
        actorInfos = _data as ActorInfo;
    }

    public void OnFault(object _data)
    {
        SendNotification(Const.Notification.LOGIN_FAIL, _data);
    }
}
