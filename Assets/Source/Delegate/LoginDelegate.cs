using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginDelegate
{
    private IResponder m_responder;
    private HttpService m_httpService;

    public LoginDelegate(IResponder _responder, LoginVO _loginVO,string _did,string _gameID)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", _loginVO.userName);
        form.AddField("password", _loginVO.password);
        form.AddField("did", _did);
        form.AddField("game_id", _gameID);
        Debug.Log("username:" + _loginVO.userName + "  password:" + _loginVO.password + "  did:" + _did + "  game_id:" + _gameID);
        m_responder = _responder;
        Debug.Log(Const.Url.CONTROL_CENTER_LOGIN);
        m_httpService = new HttpService(Const.Url.CONTROL_CENTER_LOGIN, HttpRequestType.Post, form);

    }
    public void LoginService()
    {
        m_httpService.SendRequest<LoginResponse>(LoginCallback);
    }

    private void LoginCallback(LoginResponse _httpResponse)
    {
        
        if (_httpResponse.err_code == 0)
        {
            m_responder.OnResult(_httpResponse.actor_info);
            Debug.Log("登录返回的信息==" + _httpResponse.actor_info.character+ _httpResponse.actor_info.image+"EID:"+_httpResponse.actor_info.eid);
        }
        else
        {
            m_responder.OnFault(_httpResponse.err_msg);
            Debug.Log("LoginFault:" + _httpResponse.err_msg);
        }
    }


}
