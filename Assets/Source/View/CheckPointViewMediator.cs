using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class CheckPointViewMediator : Mediator, IMediator
{
    public const string NAME = "CheckPointViewMediator";

    protected CheckPointView m_checkPointView { get { return m_viewComponent as CheckPointView; } }
    private LoginProxy m_loginProxy;

    public CheckPointViewMediator(CheckPointView _view) : base(NAME, _view)
    {
        m_loginProxy = Facade.RetrieveProxy(LoginProxy.NAME) as LoginProxy;
        m_checkPointView.GetActorInfo += TryGetActorInfo;
    }
    public override System.Collections.Generic.IList<string> ListNotificationInterests()
    {
        return new List<string>()
        {
            //TODO: 接收ws发送的Notication，这里有两种类型得CheckPoint（finish Or UnFinish）信息
            Const.Notification.FINISH_CHECK_POINT_INFO,
            Const.Notification.NEXT_CHECK_POINT_INFO
        };
    }
    public override void HandleNotification(INotification notification)
    {
        string name = notification.Name;
        object vo = notification.Body;

        switch (name)
        {
            case Const.Notification.FINISH_CHECK_POINT_INFO:
                UpdateFinishCheckPointInfo(vo as CheckPointInfos);
                break;
            case Const.Notification.NEXT_CHECK_POINT_INFO:
                UpdateNextCheckPointInfo(vo as CheckPointInfos);
                break;
        }
    }
    private void TryGetActorInfo()
    {
        m_checkPointView.ActorInfoInit(m_loginProxy.actorInfos);
    }
   private void UpdateFinishCheckPointInfo(CheckPointInfos checkPointInfos)
    {
        if (m_checkPointView.isWSFirstSend==false)
        {
            m_checkPointView.UpdateFinishedCheckPointInfo(checkPointInfos);
            m_checkPointView.isWSFirstSend = true;
        }
        else
        {
            SendNotification(Const.Notification.SEND_ACTOR_CHECK_POINT_RECORD, m_checkPointView.actorcheckPointRecord);
            m_checkPointView.CloseCoroutin();
            m_checkPointView.UpdateFinishedCheckPointInfo(checkPointInfos);
        }
   }
    private void UpdateNextCheckPointInfo(CheckPointInfos checkPointInfos)
    {
        if (m_checkPointView.isWSFirstSend == false)
        {
            m_checkPointView.UpdateUnFinishedCheckPointInfo(checkPointInfos);
            m_checkPointView.isWSFirstSend = true;
        }
        else
        {
            SendNotification(Const.Notification.SEND_ACTOR_CHECK_POINT_RECORD, m_checkPointView.actorcheckPointRecord);
            m_checkPointView.CloseCoroutin();
            m_checkPointView.UpdateUnFinishedCheckPointInfo(checkPointInfos);
        }
    }
}
