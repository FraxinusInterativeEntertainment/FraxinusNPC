using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointDelegate
{
    private IResponder m_responder;
    private HttpService m_httpService;

    public CheckPointDelegate(IResponder _responder, ActorCheckpointRecord actorCheckpointRecord)
    {
        WWWForm form = new WWWForm();
        form.AddField("checkpoint_name", actorCheckpointRecord.checkpoint_name);
        form.AddField("timeRemain", actorCheckpointRecord.timeRemain.ToString());

        m_responder = _responder;
        Debug.Log(Const.Url.CONTROL_CENTER_LOGIN);
        m_httpService = new HttpService(Const.Url.UPDATE_ACTOR_CHECK_POINT_RECORD, HttpRequestType.Post, form);
    }
    public void CheckPointRecordServerce()
    {
        m_httpService.SendRequest<HttpResponse>(CheckPointRecordCallback);
    }
    private void CheckPointRecordCallback(HttpResponse _httpResponse)
    {

        if (_httpResponse.err_code == 0)
        {
            Debug.Log("发送ActorCheckoint信息成功");
        }
        else
        {
            Debug.Log("发送ActorCheckoint信息失败");
        }
    }
}