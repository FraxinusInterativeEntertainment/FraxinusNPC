﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using Newtonsoft.Json;

public class ServerCommunicationProxy : Proxy, IProxy
{
    public const string NAME = "ServerCommunicationProxy";

    private WebSocketService m_wsService;
   
    public ServerCommunicationProxy() : base(NAME)
    {
        m_wsService = new WebSocketService();
    }

    public void ConnectFraxMotherShipWs(object _data)
    {
        m_wsService.Connect(Const.Url.WEB_SOCKET_SERVER_ADDRESS + (_data as string) + "/", Const.Url.WEB_SOCKET_HOST_URI, WebSocketMessageHandler, 
                            WebSocketCloseHandler, WebSocketOpenHandler, WebSocketErrorHandler);
    }

    public void SendMessage(object _data)
    {
        m_wsService.Send((string)_data);
    }

    private void WebSocketOpenHandler()
    {
        Debug.Log("Websocket Opened!");
    }

    private void WebSocketErrorHandler(string _message)
    {
        Debug.Log("Websocket closed: " + _message);
    }

    private void WebSocketCloseHandler(string _message)
    {
        Debug.Log("Websocket closed: " + _message);
    }

    private void WebSocketMessageHandler(string _message)
    {
        Debug.Log("Message Arrived: " + _message);
        JsonToMsgType(_message);
    }

    private string ToJson(object _data)
    {
        string json = JsonConvert.SerializeObject(_data);
        Debug.Log(json);
        return json;
    }
    public  void DebugMessage(string _msg)
    {
        JsonToMsgType(_msg);
    }
    private void JsonToMsgType(string _message)
    {
        ServerMsg obj = JsonConvert.DeserializeObject<ServerMsg>(_message);
        if (obj.MsgType == "checkpoint_finished")
        {
            Debug.Log("剧情推进：已完成");
            CheckPointInfos msgContent = JsonConvert.DeserializeObject<CheckPointInfos>(_message);
            AppFacade.instance.SendNotification(Const.Notification.FINISH_CHECK_POINT_INFO, msgContent);
        }
        else if (obj.MsgType == "next_checkpoint")
        {
            Debug.Log("剧情推进：");
            CheckPointInfos msgContent = JsonConvert.DeserializeObject<CheckPointInfos>(_message);
           
            AppFacade.instance.SendNotification(Const.Notification.NEXT_CHECK_POINT_INFO, msgContent);
        }
    }
    /*
    private string testWsSend()
    {
        string result = "None";

        Dictionary<string, DeviceLocationInfo> gameMap = new Dictionary<string, DeviceLocationInfo>();
        gameMap.Add("did00001", new DeviceLocationInfo(1, 1, "room1"));
        gameMap.Add("did00002", new DeviceLocationInfo(2, 2, "room2"));

        WsMessage wsMsg = new WsMessage("location", gameMap);

        result = WsMsgToJson(wsMsg);

        return result;
    }
    */
}

public class WsMessage
{
    public string MsgType { get; set; }
    public object MsgContent { get; set; }

    public WsMessage(string _msgType, object _msgContent)
    {
        MsgType = _msgType;
        MsgContent = _msgContent;
    }
}