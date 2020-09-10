
   using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerMsg
{
    public string MsgType { get; set; }

    public ServerMsg(string _msgType)
    {
        MsgType = _msgType;
    }
}

