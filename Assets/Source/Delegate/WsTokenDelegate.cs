using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WsTokenDelegate
{
    private IResponder m_responder;
    private HttpService m_httpService;

    public WsTokenDelegate(IResponder _responder)
    {
        m_responder = _responder;
        m_httpService = new HttpService(Const.Url.GET_WS_TOKEN, HttpRequestType.Get);
    }

    public void RequestForWsToken()
    {
        m_httpService.SendRequest<WsTokenResponse>(WsTokenCallback);
    }

    private void WsTokenCallback(WsTokenResponse _httpResponse)
    {
        if (_httpResponse.err_code == 0)
        {
            m_responder.OnResult(_httpResponse.ws_token);
        }
        else
        {
            m_responder.OnFault(_httpResponse.err_msg);
        }
    }
}

public class WsTokenResponse : HttpResponse
{ 
    public string ws_token;

    public WsTokenResponse(int _errCode, string _errMsg, string _token) : base(_errCode, _errMsg)
    {
        ws_token = _token;
    }
}
