﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class LoginViewMediator : Mediator, IMediator
{
    public const string NAME = "LoginViewMediator";

    protected LoginView m_loginView { get { return m_viewComponent as LoginView; } }

    public LoginViewMediator(LoginView _view) : base(NAME, _view)
    {
        m_loginView.TryLogin += OnTryLogin;
        m_loginView.TryLogout += OnTryLogout;
    }

    public override System.Collections.Generic.IList<string> ListNotificationInterests()
    {
        return new List<string>()
        {
            Const.Notification.LOGIN_SUCCESS,
            Const.Notification.LOGIN_FAIL,
            Const.Notification.GAME_SERVER_LOGOUT_SUCCESS,
            Const.Notification.GAME_SERVER_LOGOUT
        };
    }

    public override void HandleNotification(INotification notification)
    {
        string name = notification.Name;
        object vo = notification.Body;

        switch (name)
        {
            case Const.Notification.LOGIN_SUCCESS:
                OnLoginSuccess();
                break;
            case Const.Notification.LOGIN_FAIL:
                OnLoginFailed(vo as string);
                break;
            case Const.Notification.GAME_SERVER_LOGOUT_SUCCESS:
                OnLogoutSuccess();
                break;
            case Const.Notification.GAME_SERVER_LOGOUT:
                OnLogoutSuccess();
                break;
        }
    }

    private void OnTryLogin()
    {
        SendNotification(Const.Notification.SEND_ADMIN_LOGIN, m_loginView.loginVO);
    }

    private void OnTryLogout()
    {
        SendNotification(Const.Notification.GAME_SERVER_LOGOUT);
        //m_loginView.ActivateLoginPanel();
    }

    private void OnLoginSuccess()
    {
        m_loginView.ActivateUserInfoPanel();
        m_loginView.SetLoginResultText("Login Success!");
        m_loginView.UpdateUserNameText();
    }

    private void OnLoginFailed(string _errMsg)
    {
        m_loginView.SetLoginResultText(_errMsg);
    }

    private void OnLogoutSuccess()
    {
        m_loginView.ActivateLoginPanel();
    }
}