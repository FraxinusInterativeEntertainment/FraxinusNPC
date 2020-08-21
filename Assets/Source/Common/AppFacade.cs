﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class AppFacade : Facade, IFacade
{
    public const string STARTUP = "Startup";
    public const string LOGIN = "Login";

    private static AppFacade m_instance;

    public static AppFacade instance
    {
        get{
            if (m_instance == null)
            {
                m_instance = new AppFacade();
            }
            return m_instance;
        }
    }
    
    protected override void InitializeController()
    {
        base.InitializeController();
        RegisterCommand(STARTUP, typeof(StartupCommand));
        RegisterCommand(Const.Notification.LOAD_UI_ROOT_FORM, typeof(UICommand));
        RegisterCommand(Const.Notification.LOAD_UI_FORM, typeof(UICommand));
        RegisterCommand(Const.Notification.POP_WARNING, typeof(UICommand));
        RegisterCommand(Const.Notification.GO_TO_HOME_FORM, typeof(UICommand));
        RegisterCommand(Const.Notification.BACK_TO_LAST_FORM, typeof(UICommand));
        RegisterCommand(Const.Notification.SEND_ADMIN_LOGIN, typeof(LoginCommand));
    }

    public void startup()
    {
        SendNotification(STARTUP);
        SendNotification(Const.Notification.LOAD_UI_ROOT_FORM, Const.UIFormNames.WECHAT_LOGIN_FORM_NORMAL);
    }
}
