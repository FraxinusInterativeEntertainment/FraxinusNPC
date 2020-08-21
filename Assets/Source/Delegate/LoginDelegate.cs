﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginDelegate
{
    private IResponder m_responder;
    private HttpService m_httpService;

    public LoginDelegate(IResponder _responder, LoginVO _loginVO,string _did)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", _loginVO.userName);
        form.AddField("password", _loginVO.password);
        form.AddField("did", _did);

        m_responder = _responder;
        m_httpService = new HttpService(Const.Url.CONTROL_CENTER_LOGIN, HttpRequestType.Post, form);
    }
    public void LoginService()
    {
        m_httpService.SendRequest<HttpResponse>(LoginCallback);
    }

    private void LoginCallback(HttpResponse _httpResponse)
    {
        if (_httpResponse.err_code == 0)
        {
            m_responder.OnResult(_httpResponse.err_msg);
        }
        else
        {
            m_responder.OnFault(_httpResponse.err_msg);
        }
    }


}
